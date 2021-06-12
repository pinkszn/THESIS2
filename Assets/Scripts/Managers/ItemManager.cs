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
    [SerializeField] ScriptableObject RecycleItem;

    [Space]
    [SerializeField] TextMeshProUGUI codexMaterialDescription;
    [SerializeField] TextMeshProUGUI codexMaterialName;
    [SerializeField] Sprite codexMaterialSprite;
    [Space]

    //ITEM PICKUPS
    public int plastic;
    public int aluminum;
    public int glass;
    public int paper;

    [Space]
    //RECYCLING ITEM OUTPUTS
    public int washedPlastic;
    public int shredPlastic;

    public int recycledPlastic;
    public int recycledAluminum;

    public int ruinedPlastic;
    public int ruinedAluminum;

    //amount of the crafted usable items, yung mga eco bombs and stuff, dagdag nlang
    [Space]
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
            GAME_MANAGER.instance.materialsRecycled += 1;
            return;
        }
        else
            //FindObjectOfType<Button>().interactable = false;
        return;
        //if kulang ng materials, disable button or just do nothing
        //if enough materials, add one to the amount of craftedItem amount, tas bawasan ang raw materials
	}
    #endregion

    #region Recycling Buttons
    public void ItemToRecycle()
    {
        /*
         * 
         */
    }

    public void SeperateButton()
    {
        /*
         * take seperated item out of player's inventory
         * add new materials to player's inventory
        */
    }
    public void CrushButton()
    {
        /*
         * take seperated item out of player's inventory
         * add new materials to player's inventory
        */
    }
    public void WashButton()//hard coded muna
    {
        if (plastic > 0)
        {
            plastic -= 1;
            washedPlastic += 1;
            Debug.Log("Plastic is washed");
        }
        else
        {
            plastic -= 1;
            ruinedPlastic += 1;
            Debug.Log("Plastic is ruined");
        }
    }
    public void ShredButton()//hard coded muna
    {
        if (washedPlastic > 0)
        {
            washedPlastic -= 1;
            shredPlastic += 1;
            Debug.Log("Plastic is shreded");
        }
        else 
        {
            plastic -= 1;
            ruinedPlastic += 1;
            Debug.Log("Plastic is ruined");
        }
    }
    public void SeparateButton()
    {
        /*
         * take seperated item out of player's inventory
         * add new materials to player's inventory
        */
    }
    public void TrashButton()
    {
        /*
        * material -=1 or max
        * add new materials to player's inventory
        */
    }
    public void ReuseButton()//hard coded muna
    {
        if (shredPlastic > 0)
        {
            shredPlastic -= 1;
            recycledPlastic += 1;
            Debug.Log("Recycled Plastic complete");
        }
    }
    #endregion

    #region Community Screen
    public void Donate()//Hard Code Muna
    {
        if (plastic > 0)
        {
            plastic -= 1;
        }
        /*
         * Show Item (sprite)
         * Donate Item Quantity (to follow)
         * Button that functions to sell whatever the data is above it
         */
    }
    #endregion
}
