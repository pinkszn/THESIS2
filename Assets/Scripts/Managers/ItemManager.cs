using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemManager : Singleton<ItemManager>
{
    [SerializeField] TextMeshProUGUI[] CraftingText; //UI for values of crafting
    [SerializeField] TextMeshProUGUI[] ItemText; // UI for current values of usable items
    [SerializeField] Button[] CraftingButtons;

    //ITEM PICKUPS /FROM COMPOUND
    public int plastic;
    public int aluminum;
    public int recycledPlastic;
    public int recycledAluminum;
    public int ruinedPlastic;
    public int ruinedAluminum;

    //amount of the crafted usable items, yung mga eco bombs and stuff, dagdag nlang
    public int EcoBricks;
    public int Carpet;
    public int UltraBin;
    public int SkateBoard;
    public int Soap;

	public void InitializeData() //call this function when starting a level
	{
        //item01 = PlayerPrefs.GetInt("Item01");
        plastic = PlayerPrefs.GetInt("plastic");
		aluminum = PlayerPrefs.GetInt("aluminum");
    }

	private void Update()
	{
        UpdateUI();
        ControlButtons();
	}

	void UpdateUI() // Hard Code ko muna
	{
        ItemText[0].SetText("x" + EcoBricks.ToString());
        ItemText[1].SetText("x" + Carpet.ToString());
        ItemText[2].SetText("x" + UltraBin.ToString());
        ItemText[3].SetText("x" + SkateBoard.ToString());
        ItemText[4].SetText("x" + Soap.ToString());
	}

    void ControlButtons() //Hard Code rin muna to, looking for a better solution
	{
        if(plastic > 0)
		{
            CraftingButtons[0].interactable = true;
            //CraftingButtons[0].image.overrideSprite = buttonActive; //Use this pag may button sprites na tayo
		}
        else
		{
            CraftingButtons[0].interactable = false;
            //CraftingButtons[0].image.overrideSprite = buttonInactive; //Use this pag may button sprites na tayo
        }
    }

	//name of function subject to change

	public void CraftEcoBricks() //eto yung icoconect dun sa button UI ng pag craft //copy paste nlang buong function pag mayroon pang ibang recipes
	{
        //if statement ng amount of raw materials na kelangan sa pag craft ng item na ito
        if (plastic > 0) //values subject to change
        {
            //FindObjectOfType<Button>().interactable = true;
            plastic -= 1;
            //recycledPlastic -= 2;
            EcoBricks += 1;
            GAME_MANAGER.instance.materialsRecycled += 1;
            return;
        }
        else
            //FindObjectOfType<Button>().interactable = false;
        return;
        //if kulang ng materials, disable button or just do nothing
        //if enough materials, add one to the amount of craftedItem amount, tas bawasan ang raw materials
	}
}
