using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommunityUI : MonoBehaviour
{
    [SerializeField] private Button[] donateButtons;

    [SerializeField] private Slider[] donatedAmmount;

	private void Update()
    {
        UpdateCommunityBarValue();
        ButtonFunctionality();
    }

    void UpdateCommunityBarValue()
	{
        donatedAmmount[0].value = ItemManager.instance.DonatedEcoBricksAmount; //Donated Eco Brick 
        donatedAmmount[1].value = ItemManager.instance.DonatedCarpetAmount; //Donated Carpet
        donatedAmmount[2].value = ItemManager.instance.DonatedBaseballBat; //Donated Base Ball Bat 
        donatedAmmount[3].value = ItemManager.instance.DonatedSkateBoardAmount; //Donated Skate Board 
	}

    void ButtonFunctionality()
	{
        if(ItemManager.instance.DonatedEcoBricksAmount == ItemManager.instance.MaxDonatedEcoBricksAmount)
		{
            donateButtons[0].interactable = false;
		}
        if(ItemManager.instance.DonatedEcoBricksAmount != ItemManager.instance.MaxDonatedEcoBricksAmount)
		{
            donateButtons[0].interactable = true;
		}
        
        if(ItemManager.instance.DonatedCarpetAmount == ItemManager.instance.MaxDonatedCarpetAmount)
		{
            donateButtons[1].interactable = false;
		}
        if(ItemManager.instance.DonatedCarpetAmount != ItemManager.instance.MaxDonatedCarpetAmount)
		{
            donateButtons[1].interactable = true;
		}
        
        if(ItemManager.instance.DonatedBaseballBat == ItemManager.instance.MaxDonatedBaseballBat)
		{
            donateButtons[2].interactable = false;
		}
        if(ItemManager.instance.DonatedBaseballBat != ItemManager.instance.MaxDonatedBaseballBat)
		{
            donateButtons[2].interactable = true;
		}

        if (ItemManager.instance.DonatedSkateBoardAmount == ItemManager.instance.MaxDonatedSkateBoardAmount)
        {
            donateButtons[3].interactable = false;
        }
        if (ItemManager.instance.DonatedSkateBoardAmount != ItemManager.instance.MaxDonatedSkateBoardAmount)
        {
            donateButtons[3].interactable = true;
        }
    }




	#region Community Screen Button Functions
	public void DonateEcoBrick()//Hard Code Muna
    {
        if (ItemManager.instance.EcoBricks > 20)
        {
            ItemManager.instance.DonatedEcoBricksAmount += ItemManager.instance.EcoBricks;
            ItemManager.instance.EcoBricks -= 20;
            //Debug.Log("Donated all Eco Bricks");
            //AudioManager.instance.Play("DonateTemp");
        }
    }
    public void DonateCarpet()//Hard Code Muna
    {
        if (ItemManager.instance.Carpet > 20)
        {
            ItemManager.instance.DonatedCarpetAmount += ItemManager.instance.Carpet;
            ItemManager.instance.Carpet -= 20;
            //Debug.Log("Donated all Carpet");
            //AudioManager.instance.Play("DonateTemp");
        }
    }

    public void DonateSkateBoard()//Hard Code Muna
    {
        if (ItemManager.instance.SkateBoard > 20)
        {
            ItemManager.instance.DonatedSkateBoardAmount += ItemManager.instance.SkateBoard;
            ItemManager.instance.SkateBoard -= 20;
            //Debug.Log("Donated all Skate Boards");
            //AudioManager.instance.Play("DonateTemp");
        }
    }
    
    public void DonateBaseballBat()//Hard Code Muna
    {
        if (ItemManager.instance.BaseballBat > 20)
        {
            ItemManager.instance.DonatedBaseballBat += ItemManager.instance.BaseballBat;
            ItemManager.instance.BaseballBat -= 20;
            //Debug.Log("Donated all Skate Boards");
            //AudioManager.instance.Play("DonateTemp");
        }
    }
    #endregion
}
