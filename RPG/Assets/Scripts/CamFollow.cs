using System;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform playerTransform;//Made this variable to contain the actual transformation of player aka where camera should be
    public GameObject playa;//This is the variable the Player gameobject gets assigned to

    public float speed;//How fast camera moves

    //Variables below are whats used to clamp camera
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private void Start()
    {
        playa = GameObject.Find("Player(Clone)");//Finds the GameObject called Player in hierarchy and assigns it to playa variable
        playerTransform = playa.transform;//The transformation gets set to whereever the Player is
        transform.position = playerTransform.position;//Player and camera are at the same position at the start of game
    }

    private void Update()
    {
        if (playerTransform != null)//Checks to make sure if player transform exists(because player can die)
        {
            float clampedX = Mathf.Clamp(playerTransform.position.x, minX, maxX);//This is a variable which clamps based off of minX and maxX
            float clampedY = Mathf.Clamp(playerTransform.position.y, minY, maxY);//This is a variable which clamps based off of minY and maxY

            transform.position = Vector2.Lerp(transform.position, new Vector2(clampedX, clampedY), speed);//Moves camera from 1 point to another based on speed
        }
    }
}
