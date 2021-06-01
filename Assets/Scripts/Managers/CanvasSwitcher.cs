using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CanvasSwitcher : MonoBehaviour
{
    public CanvasType desiredCanvasType;

    CanvasManager canvasManager;
    Button menuButton;

    private void Start()
    {
        menuButton = GetComponent<Button>();
        menuButton.onClick.AddListener(OnButtonClicked);
        canvasManager = CanvasManager.Instance;
    }


    void OnButtonClicked()//Switches both scene and canvas
    {
        /*
         * On button Click
         * 1. IF scene requires change the load scene and switch canvas
         * 2. IF scene DOES NOT require change scene, just switch canvas
         */

        SceneController.LoadScene(1, 1, 2);
        canvasManager.SwitchCanvas(desiredCanvasType);
    }

    /*
     * To Do:
     * 1. Set a system for different buttons
     * Types of buttons
     * Recycling UI
     * Go Back
     * Quit Application
     * Retry Level
     */
}