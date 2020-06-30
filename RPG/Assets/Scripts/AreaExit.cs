using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{

    public string areaToLoad;

    public string areaTransitionName;

    public AreaEntrance theEntrance;

    public float waitToLoad = 1f;
    private bool shouldLoadAfterFade;

    void Start()
    {
        theEntrance.transitionName = areaTransitionName;//Automatically sets theEntrance transitionName to whatever the AreaExit transition name is, saves time
    }

   
    void Update()
    {
        if (shouldLoadAfterFade)
        {
            waitToLoad -= Time.deltaTime;//Takes 1 second for waitToLoad to get down to 0
            if(waitToLoad <= 0)
            {
                shouldLoadAfterFade = false;
                SceneManager.LoadScene(areaToLoad);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)//So whenever something collides with this
    {
        if(collision.tag == "Player")
        {
            //SceneManager.LoadScene(areaToLoad);//Whatever the name/string of areaToLoad is is the scene that gets loaded
            shouldLoadAfterFade = true;
            UIFade.instance.FadeToBlack();

            PlayerController.instance.areaTransitionName = areaTransitionName; //Can access static variables from other scripts, this changes the areaTransitionName in PlayerController to whatever the areaTransitionName is in AreaExit
        }
    }
}
