using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public int item01; //eto yung mga amount ng raw materials na napipickup
    public int item02; //names will change depending sa pangalan ng mga raw materials (design team)

    public int craftedItem01; //amount of the crafted usable items, yung mga eco bombs and stuff, dagdag nlang 
    public int craftedItem02;

    //name of function subject to change
    public void CraftItem01() //eto yung icoconect dun sa button UI ng pag craft //copy paste nlang buong function pag mayroon pang ibang recipes
	{
        //if statement ng amount of raw materials na kelangan sa pag craft ng item na ito

        //if kulang ng materials, disable button or just do nothing
        //if enough materials, add one to the amount of craftedItem amount, tas bawasan ang raw materials

	}
}
