using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoader : MonoBehaviour
{

    public GameObject player;

    void Start()
    {
        if(PlayerController.instance == null)//player hasnt loaded into scene
        {
            Instantiate(player);
        }
    }

    void Update()
    {
        
    }
}
