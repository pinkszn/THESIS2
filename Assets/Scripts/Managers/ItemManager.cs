using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemManager : Singleton<ItemManager>
{
    //[SerializeField] TextMeshProUGUI[] CraftingText; //UI for values of crafting
    [SerializeField] TextMeshProUGUI[] ItemText; // UI for current values of usable items
    [SerializeField] Button[] CraftingButtons;

    [Space]
    //ITEM PICKUPS
    public int plastic;
    public int aluminum;
    public int glass;
    public int paper;

    [Space]
    //RECYCLING ITEM OUTPUTS
    public int recycledPlastic;
    public int recycledAluminum;
    public int recycledPaper;
    public int recycledGlass;

    //amount of the crafted usable items, yung mga eco bombs and stuff, dagdag nlang
    [Space]
    public int EcoBricks;
    public int Carpet;
    public int BaseballBat;
    public int Soap;

    [Space]
    public int SkateBoard;
    public int UltraBin;

    [Space]
    public int DonatedEcoBricksAmount;
    public int DonatedCarpetAmount;
    public int DonatedUltraBinAmount;
    public int DonatedSkateBoardAmount;
    public int DonatedSoapAmount;

	public void InitializeData() //call this function when starting a level
	{
        //item01 = PlayerPrefs.GetInt("Item01");
        plastic = PlayerPrefs.GetInt("plastic");
		aluminum = PlayerPrefs.GetInt("aluminum");
    }

	private void Update()
	{
        UpdateGameUI();
        ControlButtons();
	}

	void UpdateGameUI() // Hard Code ko muna
	{
        ItemText[0].SetText("x" + EcoBricks.ToString());
        ItemText[1].SetText("x" + Carpet.ToString());
        ItemText[2].SetText("x" + BaseballBat.ToString());
        ItemText[3].SetText("x" + Soap.ToString());
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
    #region Crafting Buttons
    public void CraftEcoBricks() //eto yung icoconect dun sa button UI ng pag craft //copy paste nlang buong function pag mayroon pang ibang recipes
	{
        //if statement ng amount of raw materials na kelangan sa pag craft ng item na ito
        if (plastic > 0) //values subject to change
        {
            //FindObjectOfType<Button>().interactable = true;
            plastic -= 1;
            //recycledPlastic -= 2;
            EcoBricks += 1;
            GAME_MANAGER.instance.currentMaterialsRecycled += 1;
            return;
        }
        else
            //FindObjectOfType<Button>().interactable = false;
        return;
        //if kulang ng materials, disable button or just do nothing
        //if enough materials, add one to the amount of craftedItem amount, tas bawasan ang raw materials
	}
    #endregion

    #region Community Screen
    public void DonateEcoBrick()//Hard Code Muna
    {
        if (EcoBricks > 0)
        {
            DonatedEcoBricksAmount += EcoBricks;
            EcoBricks = 0;
            Debug.Log("Donated all Eco Bricks");
            AudioManager.instance.Play("DonateTemp");
        }
    }
    public void DonateCarpet()//Hard Code Muna
    {
        if (Carpet > 0)
        {
            DonatedCarpetAmount += Carpet;
            Carpet = 0;
            Debug.Log("Donated all Carpet");
            AudioManager.instance.Play("DonateTemp");
        }
    }
    public void DonateUltraBin()//Hard Code Muna
    {
        if (UltraBin > 0)
        {
            DonatedUltraBinAmount += UltraBin;
            UltraBin = 0;
            Debug.Log("Donated all Ultra Bins");
            AudioManager.instance.Play("DonateTemp");
        }
    }
    public void DonateSkateBoard()//Hard Code Muna
    {
        if (SkateBoard > 0)
        {
            DonatedSkateBoardAmount += SkateBoard;
            SkateBoard = 0;
            Debug.Log("Donated all Skate Boards");
            AudioManager.instance.Play("DonateTemp");
        }
    }
    public void DonateSoap()//Hard Code Muna
    {
        if (Soap > 0)
        {
            DonatedSoapAmount += Soap;
            Soap = 0;
            Debug.Log("Donated all Soap");
            AudioManager.instance.Play("DonateTemp");
        }
    }
    #endregion


}
