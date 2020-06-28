using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public Rigidbody2D theRB;//Since this is public I can go into the actual Inspector and add any Rigidbody2D component to this variable
    public float moveSpeed;

    public Animator myAnim;

    public string areaTransitionName;

    public static PlayerController instance;//static meaning there can only 1 version of this PlayerController(script)
    void Start()
    {
        if(instance == null)//no other players existing
        {
            instance = this;//1st player gets everything associated with this script
        }
        else//any other players existing
        {
            Destroy(gameObject);//Destroys new player
        }

        DontDestroyOnLoad(gameObject);//Don't destroy gameobject when loading into new scene
    }

    void Update()
    {
        theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;//Moves Player in specific direction depending on key pressed

        //These 2 Float values below decide which direction the player is moving aka the move animation
        myAnim.SetFloat("moveX", theRB.velocity.x);//This sets the float parameter called moveX to whatever the current x velocity is of the Rigidbody2D
        myAnim.SetFloat("moveY", theRB.velocity.y);//This sets the float parameter called moveY to whatever the current x velocity is of the Rigidbody2D

        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)//Controls Idle Animations for whenever player stops
        {
            myAnim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));//So if lastMoveX is -1 it faces left, if lastmoveX is 1 it faces right
            myAnim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));//So if lastMoveY is -1 it faces down, if lastmoveY is 1 it faces up
        }
    }
}
