using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommunityUI : MonoBehaviour
{
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
