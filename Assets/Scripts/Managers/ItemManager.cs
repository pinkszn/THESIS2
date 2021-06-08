using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemManager : Singleton<ItemManager>
{
    [SerializeField] TextMeshProUGUI[] CraftingText; //UI for values of crafting
    [SerializeField] TextMeshProUGUI[] ItemText; // UI for current values of usable items

    public int plastic;
    public int aluminum;
    public int recycledPlastic;
    public int recycledAluminum;
    public int ruinedPlastic;
    public int ruinedAluminum; 

    public int EcoBricks; //amount of the crafted usable items, yung mga eco bombs and stuff, dagdag nlang 
    public int Carpet;
    public int UltraBin;
    public int SkateBoard;
    public int Soap;

	protected override void Awake()
	{
        base.Awake();
	}

	public void InitializeData() //call this function when starting a level
	{
        //item01 = PlayerPrefs.GetInt("Item01");
        plastic = PlayerPrefs.GetInt("plastic");
        aluminum = PlayerPrefs.GetInt("aluminum");
    }

    //name of function subject to change
    public void CraftEcoBricks() //eto yung icoconect dun sa button UI ng pag craft //copy paste nlang buong function pag mayroon pang ibang recipes
	{
        //if statement ng amount of raw materials na kelangan sa pag craft ng item na ito
        if (plastic > 1) //values subject to change
        {
            recycledPlastic -= 2;
            EcoBricks += 1;
            return;
        }
        else
            return;
        //if kulang ng materials, disable button or just do nothing
        //if enough materials, add one to the amount of craftedItem amount, tas bawasan ang raw materials
	}
}
