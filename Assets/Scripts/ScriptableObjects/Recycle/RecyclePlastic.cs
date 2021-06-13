using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Plastic", menuName = "RecycleItem/Plastic")]
public class RecyclePlastic : RecycleItemsBase
{
	bool isWashed = false;
	bool isShreded = false;

    public override void Seperate()
	{
		Debug.Log("Seperated Plastic");
	}
    public override void Crush()
	{
		Debug.Log("Crushed Plastic");
		Debug.Log("Nothing Happened");
	}
    public override void Wash()
	{
		Debug.Log("Washed Plastic");

		if (ItemManager.instance.plastic > 0)
		{
			ItemManager.instance.plastic -= 1;
			ItemManager.instance.washedPlastic += 1;
			isWashed = true;
			Debug.Log("Plastic is washed");
		}
		else
		{
			ItemManager.instance.plastic -= 1;
			ItemManager.instance.ruinedPlastic += 1;
			Debug.Log("Plastic is ruined");
		}
	}
	public override void Shred()
	{
		Debug.Log("Shreded Plastic");

		if (ItemManager.instance.washedPlastic > 0 && isWashed)
		{
			ItemManager.instance.washedPlastic -= 1;
			ItemManager.instance.shredPlastic += 1;
			Debug.Log("Plastic is shreded");
		}
		else
		{
			ItemManager.instance.plastic -= 1;
			ItemManager.instance.ruinedPlastic += 1;
			ResetRecycleProcess();
			Debug.Log("Plastic is ruined");
		}
	}
    public override void Trash()
	{
		Debug.Log("Plastic is ruined");
	}
 //   public override void Reuse()
	//{
	//	Debug.Log("Reused Plastic");

	//	if (ItemManager.instance.shredPlastic > 0)
	//	{
	//		ItemManager.instance.shredPlastic -= 1;
	//		ItemManager.instance.recycledPlastic += 1;
	//		Debug.Log("Recycled Plastic complete");
	//	}
	//}

	protected override void ResetRecycleProcess()
	{
		isWashed = false;
		isShreded = false;
	}
}
