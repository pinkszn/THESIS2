using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RecycleItemsBase : ScriptableObject
{
    public Sprite icon;

    [Space]
    public new string name;

    [TextArea]
    public string description;

    public abstract void Seperate();
    public abstract void Crush();
    public abstract void Wash();
    public abstract void Shred();
    public abstract void Trash();
    //public abstract void Reuse(); //

    protected abstract void ResetRecycleProcess();
}
