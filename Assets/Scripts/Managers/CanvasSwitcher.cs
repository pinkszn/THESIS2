using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CanvasSwitcher : MonoBehaviour
{
    public CanvasType desiredCanvasType;

    CanvasManager canvasManager;
    Button menuButton;

    string sceneName;
    int index;

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

        SceneChanger(index);
        canvasManager.SwitchCanvas(desiredCanvasType);
    }



    void SceneChanger(int index)
    {
        SceneController.LoadScene(index, 1, 1);
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