using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager_Reference : MonoBehaviour
{


    public string playerTag;
    public static string _playerTag;

    public string ennemiTag;
    public static string _ennemieTag;

    public static GameObject player;
    private void OnEnable()
    {
        if (playerTag == "")
        {
            Debug.Log("Enter player or Ennemie Tag");
        }
        _playerTag = playerTag;
        _ennemieTag = ennemiTag;

        player = GameObject.FindGameObjectWithTag(_playerTag);
    }
}
