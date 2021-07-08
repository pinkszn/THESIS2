using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinSwitchUI : MonoBehaviour
{
    BinSwitch binSwitch;

    [SerializeField] GameObject[] binColorUI;

	private void Update()
	{
        if(binSwitch != null)
		{
            BinColorSwitch();
        }

        if(binSwitch == null)
		{
            binSwitch = GameObject.FindGameObjectWithTag("PLAYER").GetComponentInChildren<BinSwitch>();
        }            

        
    }

	void BinColorSwitch()
    {
        for(int i = 0; i < binColorUI.Length; i++)
		{
            if(i == binSwitch.selectedWeapon)
			{
                binColorUI[i].SetActive(true);
			}
            else
			{
                binColorUI[i].SetActive(false);
			}
		
		}
    }
}
