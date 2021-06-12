using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName= "RecycleItem", menuName = "RecycleItem" )]
public class RecycleItems : ScriptableObject
{
    public Sprite icon;

    [Space]
    public new string name;

    [TextArea]
    public string description;
}
