using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum CanvasType
{
    MainMenu,
    GameUI,
    EndScreen
}

public class CanvasManager : Singleton<CanvasManager>
{
    List<CanvasController> canvasControllerList;
    CanvasController lastActiveCanvas;

    protected override void Awake()
    {
        base.Awake();
        canvasControllerList = GetComponentsInChildren<CanvasController>().ToList();
        canvasControllerList.ForEach(x => x.gameObject.SetActive(false)); //deactivates everything
        SwitchCanvas(CanvasType.MainMenu);
    }

    public void SwitchCanvas(CanvasType _type)
    {
        if(lastActiveCanvas != null)
        {
            lastActiveCanvas.gameObject.SetActive(false);
        }

        CanvasController desiredCanvas = canvasControllerList.Find(x => x.canvasType == _type);
        if (desiredCanvas != null)
        {
            desiredCanvas.gameObject.SetActive(true);
        }
        else { Debug.LogWarning("desired Canvas not found!"); }
    }
}
 