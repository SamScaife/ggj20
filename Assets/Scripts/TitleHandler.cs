using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleHandler : MonoBehaviour
{
    public string title;
    public GameObject sceneDataContainer;
    private SceneData sceneData;

    /**
    * Initialization - store the sceneData.
    **/
    void Start()
    {
        sceneData = sceneDataContainer.transform.GetComponent<SceneData>();
    }

    /**
    * Choose a title for your segment
    **/
    public void ChooseTitle()
    {
        sceneData.segmentTitle = title;

        // A title has been chosen: disable all buttons
        Button[] buttons = sceneDataContainer.transform.GetComponentsInChildren<Button>();
        foreach (Button button in buttons)
        {
            button.interactable = false;
        }
        // Load the lower third panel
        LowerThirdHandler.LoadLowerThird(sceneData);
    }
}
