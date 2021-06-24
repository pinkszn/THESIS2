using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSwitch : MonoBehaviour
{
    int selectedWeapon = 0;

    // Update is called once per frame
    void Update()
    {
        ItemSwitchCheck();
    }

    void ItemSwitchCheck()  // might do some cleaning up with the if statements //Papalitan ko rin yung mga attackPoint.transform
    {
       int previousSelectedWeapon = selectedWeapon;

       if (Input.GetKeyDown(KeyCode.Alpha1) && transform.childCount >= 1) // Eco Brick
        {
            selectedWeapon = 0;
            //attackType = "Recyclable";
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2) //Carpet
        {
            selectedWeapon = 1;
            //attackType = "Decomposable";
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3) //Soap
        {
            selectedWeapon = 2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4) //Soap
        {
            selectedWeapon = 3;
        }

        if (Input.GetKeyDown(KeyCode.Alpha5) && transform.childCount >= 5) //Soap
        {
            selectedWeapon = 4;
        }

        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectItem();
        }

    }

    void SelectItem()
    {
        int i = 0;

        foreach (Transform item in transform)
        {
            if (i == selectedWeapon)
            {
                item.gameObject.SetActive(true);
            }
            else
            {
                item.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
