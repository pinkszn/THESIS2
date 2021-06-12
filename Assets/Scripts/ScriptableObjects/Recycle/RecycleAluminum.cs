using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Aluminum", menuName = "RecycleItem/Aluminum")]
public class RecycleAluminum : RecycleItemsBase
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
		Debug.Log("Trashed" + name);
	}
	public override void Reuse()
	{
		Debug.Log("Reused" + name);
	}
}
