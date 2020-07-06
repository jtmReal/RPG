using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    [Header("Item Type")]
    public bool isItem;
    public bool isWeapon;
    public bool isArmour;

    [Header("Item Details")]
    public string itemName;
    public string description;
    public int value;//How much its worth
    public Sprite itemSprite;

    [Header ("Item Details")]
    public int amountToChange;//Such as how much health, magic, strength, etc. is changed
    public bool affectHP, affectMP, affectStr;

    [Header("Item Weapon/Armor Details")]
    public int weaponStrength;

    public int armourStrength;

    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
