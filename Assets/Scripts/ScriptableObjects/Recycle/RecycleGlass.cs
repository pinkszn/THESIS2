using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Glass", menuName = "RecycleItem/Glass")]
public class RecycleGlass : RecycleItemsBase
{
	public override void Seperate()
	{
		Debug.Log("Seperated " + name);
	}
	public override void Crush()
	{
		Debug.Log("Crushed " + name);
	}
	public override void Wash()
	{
		Debug.Log("Washed " + name);
	}
	public override void Shred()
	{
		Debug.Log("Shreded " + name);
	}
	public override void Trash()
	{
		Debug.Log("Trashed " + name);
	}
	//public override void Reuse()
	//{
	//	Debug.Log("Reused " + name);
	//}

	protected override void ResetRecycleProcess()
	{

	}
}
