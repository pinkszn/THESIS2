using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Paper", menuName = "RecycleItem/Paper")]
public class RecyclePaper : RecycleItemsBase
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
