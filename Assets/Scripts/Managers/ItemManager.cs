using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemManager : Singleton<ItemManager>
{
    [SerializeField] TextMeshProUGUI[] CraftingText; //UI for values of crafting
    [SerializeField] TextMeshProUGUI[] ItemText; // UI for current values of usable items

    public int Plastic; //eto yung mga amount ng raw materials na napipickup
    public int item02; //names will change depending sa pangalan ng mga raw materials (design team)

    public int EcoBricks; //amount of the crafted usable items, yung mga eco bombs and stuff, dagdag nlang 
    public int Carpet;
    public int UltraBin;
    public int SkateBoard;
    public int Soap;

    public void InitializeData() //call this function when starting a level
	{
        //item01 = PlayerPrefs.GetInt("Item01");
	}

    //name of function subject to change
    public void CraftEcoBricks() //eto yung icoconect dun sa button UI ng pag craft //copy paste nlang buong function pag mayroon pang ibang recipes
	{
        //if statement ng amount of raw materials na kelangan sa pag craft ng item na ito
        if (Plastic > 1) //values subject to change
        {
            Plastic -= 1;
            EcoBricks += 1;
            return;
        }
        else
            return;

        //if kulang ng materials, disable button or just do nothing
        //if enough materials, add one to the amount of craftedItem amount, tas bawasan ang raw materials
	}
}
