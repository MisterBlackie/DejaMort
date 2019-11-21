using System;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System.Text;

[RequireComponent(typeof(ItemManagerComponent))]
public class CraftManager : MonoBehaviour
{
    string craftsFile = "Assets/crafts.json";
    ItemManagerComponent itemManager;

    public List<Craft> crafts { get; private set; } = new List<Craft>();

    public void registerCraft(Craft craft)
    {
        crafts.Add(craft);
    }

    public void LoadCrafts()
    {
        try
        {
            using (StreamReader sr = new StreamReader(craftsFile))
            {
                string content;
                content = sr.ReadToEnd();
                crafts = JsonConvert.DeserializeObject<List<Craft>>(content);
                if (crafts == null)
                    crafts = new List<Craft>();
            }
        }
        catch (IOException ex)
        {
            Debug.Log(ex.Message);
        }
    }

    public void SaveCrafts()
    {
        try
        {
            if (File.Exists(craftsFile))
                File.Delete(craftsFile);

            using (FileStream writer = File.Create(craftsFile))
            {
                string json = JsonConvert.SerializeObject(crafts, Formatting.Indented);
                writer.Write(Encoding.ASCII.GetBytes(json), 0, json.Length);
            }
        }
        catch (IOException ex)
        {
            Debug.Log(ex.Message);
        }
    }

    public GameObject CraftItem(IItem itemOne, IItem itemTwo)
    {
        try
        {
            Craft result = checkForCraft(itemOne, itemTwo);
            GameObject obj = itemManager.GetPrefabOfItem(result.result);

            return Instantiate(obj);
        }
        catch (CraftNotFoundException ex) // Si aucun craft n'est trouvé
        {
            throw ex;
        }
    }

    public Craft checkForCraft(IItem itemOne, IItem itemTwo)
    {
        foreach (Craft c in crafts)
        {
            if ((c.itemOne == itemOne.itemUniqueCode || c.itemOne == itemTwo.itemUniqueCode) &&
                (c.itemTwo == itemOne.itemUniqueCode || c.itemTwo == itemTwo.itemUniqueCode))
                return c;
        }

        throw new CraftNotFoundException();
    }

    public void Awake()
    {
        LoadCrafts();
        //Craft c = new Craft(Wood.UniqueCode, MetalPile.UniqueCode, BasicSword.UniqueCode);
        //Craft f = new Craft(MetalPile.UniqueCode, Batterie.UniqueCode, Flashlight.UniqueCode);
        //registerCraft(f);
        //registerCraft(c);
        //registerCraft(new Craft( , , ));
        //registerCraft(new Craft( , , ));
        //registerCraft(new Craft( , , ));
        //registerCraft(new Craft( , , ));
        //registerCraft(new Craft( , , ));
        //SaveCrafts();
    }

    private void Start()
    {
        itemManager = GetComponent<ItemManagerComponent>();
    }

    private void OnApplicationQuit()
    {
        SaveCrafts();
    }
}

public class CraftNotFoundException : Exception
{

}