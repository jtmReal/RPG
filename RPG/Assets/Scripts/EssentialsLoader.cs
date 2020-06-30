using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialsLoader : MonoBehaviour
{

    public GameObject UIScreen;
    public GameObject player;
    
    void Start()
    {
        if(UIFade.instance == null)
        {
            Instantiate(UIScreen);
        }
        if (PlayerController.instance == null)
        {
            Instantiate(player);
        }
    }

    
    void Update()
    {
        
    }
}
