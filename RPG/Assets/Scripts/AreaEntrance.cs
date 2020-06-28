using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntrance : MonoBehaviour
{

    public string transitionName;


    void Start()
    {
        if(transitionName == PlayerController.instance.areaTransitionName)//So if the areaTransitionName on player is equal to this AreaEntrance transition name then
        {
            PlayerController.instance.transform.position = transform.position;//Players location is equal to the AreaEntrance location
        }
    }

    void Update()
    {
        
    }
}
