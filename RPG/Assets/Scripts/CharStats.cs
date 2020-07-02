using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour
{

    public string charName;
    public int playerLevel = 1;
    public int currentEXP;
    public int[] expToNextLevel;//values in this list are the amount of exp needed per level until max
    public int maxLevel = 100;
    public int baseEXP = 1000;

    public int currentHP;
    public int maxHP = 100;
    public int currentMP;//Magic Power
    public int maxMP = 30;
    public int[] mpLvlBonus;
    public int strength;
    public int defense;
    public int wpnPwr; //Weapon Power
    public int armrPwr;//Armor Power
    public string equippedWpn; //Equipped Weapon
    public string equippedArmr; //Equipped Armor
    public Sprite charImage;

    void Start()
    {
        expToNextLevel = new int[maxLevel];//So as of right now max level is 100 so this would be low long the array is
        expToNextLevel[1] = baseEXP;

        for(int i = 2; i < expToNextLevel.Length; i++)//Starts at 2 because base is already determined, keeps going until less than length of expToNextLevel
        {
            expToNextLevel[i] = Mathf.FloorToInt(expToNextLevel[i - 1] * 1.05f);
        }

        for(int i = 5; i < mpLvlBonus.Length; i = i + 5)
        {
            mpLvlBonus[i] = 5;
        }
    }


    void Update()
    {
        //The 4 lines of code bellow were created for testing purposes to see if exp system worked
        if(Input.GetKey(KeyCode.K))//Could use GetKey to hold button down, GetKeyDown only works once button is pressed
        {
            AddExp(500);
        }
    }

    public void AddExp(int expToAdd)
    {
        currentEXP += expToAdd;

        if (playerLevel < maxLevel)
        {
            if (currentEXP > expToNextLevel[playerLevel])
            {
                currentEXP -= expToNextLevel[playerLevel];

                playerLevel++;

                //determine whether to add to str or def based on odd or even
                if (playerLevel % 2 == 0)//evem number
                {
                    strength++;
                }
                else
                {
                    defense++;
                }

                maxHP = Mathf.FloorToInt(maxHP * 1.05f);//health goes up by 1.05 everytime player levels up
                currentHP = maxHP;//HP is restored whenever player levels up

                maxMP = maxMP + mpLvlBonus[playerLevel];
                currentMP = maxMP;
            }
        }

        if(playerLevel >= maxLevel)
        {
            currentEXP = 0;
        }
    }
}
