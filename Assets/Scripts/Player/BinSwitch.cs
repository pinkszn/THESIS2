using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinSwitch : MonoBehaviour
{
    int selectedWeapon = 0;

    // Update is called once per frame
    void Update()
    {
        WeaponSwitch();
    }

    void WeaponSwitch()  // might do some cleaning up with the if statements //Papalitan ko rin yung mga attackPoint.transform
    {
        int previousSelectedWeapon = selectedWeapon;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (selectedWeapon <= 0)
            {
                selectedWeapon = transform.childCount - 1;
            }
            else
            {
                selectedWeapon--;
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (selectedWeapon >= transform.childCount - 1)
            {
                selectedWeapon = 0;
            }
            else
            {
                selectedWeapon++;
            }
        }

        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }

    }

    void SelectWeapon()
    {
        int i = 0;

        foreach (Transform bin in transform)
        {
            if (i == selectedWeapon)
            {
                bin.gameObject.SetActive(true);
            }
            else
            {
                bin.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
