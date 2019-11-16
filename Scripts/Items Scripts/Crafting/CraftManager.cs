using System;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System.Text;

public class CraftManager : MonoBehaviour
{
    public GameObject prefab;
    private static string craftsFile = "crafts.json";

    public static List<Craft> crafts { get; private set; } = new List<Craft>();

    public static void registerCraft(Craft craft)
    {
        crafts.Add(craft);
    }

    public static void LoadCrafts()
    {
        try
        {
            using (StreamReader sr = new StreamReader(craftsFile))
            {
                string content;
                content = sr.ReadToEnd();
            }
        }
        catch (IOException ex)
        {
            Debug.Log(ex.Message);
        }
    }

    public static void SaveCrafts()
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

    //public static GameObject craftItem(IItem itemOne, IItem itemTwo)
    //{
    //    try
    //    {
    //        Craft result = checkForCraft(itemOne, itemTwo);
    //        return Instantiate(result.result);
    //    }
    //    catch (CraftNotFoundException ex) // Si aucun craft n'est trouvé
    //    {
    //        throw ex;
    //    }
    //}

    public static Craft checkForCraft(IItem itemOne, IItem itemTwo)
    {
        foreach (Craft c in crafts)
        {
            if (c.itemOne == itemOne.itemName || c.itemOne == itemTwo.itemName &&
                c.itemTwo == itemOne.itemName || c.itemTwo == itemTwo.itemName)
                return c;
        }

        throw new CraftNotFoundException();
    }

    public void Awake()
    {
        LoadCrafts();
        GameObject obj = Instantiate(prefab);
        string wood = new Wood().itemName;
        string metal = new MetalPile().itemName;
       // Craft c = new Craft(wood, metal, obj);
      //  registerCraft(c);
        //registerCraft(new Craft( , , ));
        //registerCraft(new Craft( , , ));
        //registerCraft(new Craft( , , ));
        //registerCraft(new Craft( , , ));
        //registerCraft(new Craft( , , ));
        SaveCrafts();
    }

    private void OnApplicationQuit()
    {
        SaveCrafts();
    }
}

public class CraftNotFoundException : Exception
{

}