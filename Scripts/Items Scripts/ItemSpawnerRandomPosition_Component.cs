using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnerRandomPosition_Component : MonoBehaviour
{
    public int nombreDeFlag = 200;
    public GameObject ObjectToSpawn;
    public Terrain myTerrain;
    public LayerMask TerrainLayer;
    public static float terrainLeft, terrainRight, terrainBottom, terrainTop, terrainWidth, terrainLenght, terrainHeight;

   // public static ArrayList flag = new ArrayList();
  //  public static ArrayList positions = new ArrayList();
   // public static ArrayList rotation = new ArrayList();

    public void Awake()
    {
        terrainLeft = myTerrain.transform.position.x;
        terrainBottom = myTerrain.transform.position.z;
        terrainWidth = myTerrain.terrainData.size.x;
        terrainLenght = myTerrain.terrainData.size.z;
        terrainHeight = myTerrain.terrainData.size.y;
        terrainRight = terrainLeft + terrainWidth;
        terrainTop = terrainBottom + terrainLenght;

        InstantiatePosition(0.2f);
    }

    public void InstantiatePosition(float addedHeight)
    {
        var i = 0;
        float terrainHeight = 0f;
        RaycastHit hit;
        float randomPositionx, randomPositiony, randomPositionz;
        Vector3 randomPosition = Vector3.zero;

        do
        {
            i++;

            randomPositionx = Random.Range(terrainLeft, terrainRight);
            randomPositionz = Random.Range(terrainBottom, terrainTop);
            if (Physics.Raycast(new Vector3(randomPositionx, 9999f, randomPositionz), Vector3.down, out hit, Mathf.Infinity, TerrainLayer))
            {
                terrainHeight = hit.point.y;
            }
            randomPositiony = terrainHeight + addedHeight;

            randomPosition = new Vector3(randomPositionx, randomPositiony, randomPositionz);

            Instantiate(ObjectToSpawn, randomPosition, Quaternion.identity);
        } while (i != nombreDeFlag);
    }
}
