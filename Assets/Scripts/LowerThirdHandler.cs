using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LowerThirdHandler : MonoBehaviour
{
    /**
    * Hide the title picker canvas and show the main UI
    **/
    public static bool LoadLowerThird(SceneData sceneData)
    {
        // Show the main canvas and the lower third panel inside it.
        var mainCanvas = GameObject.Find("MainCanvas");
        var lowerThirdPanel = mainCanvas.transform.Find("LowerThird");
        lowerThirdPanel.gameObject.SetActive(true);

        // Set the title to the lower third panel
        Text segmentTitle = GameObject.Find("SegmentTitle").GetComponent<Text>();
        segmentTitle.text = sceneData.segmentTitle;

        // Hide the title picker canvas forever
        GameObject.Find("TitlePickerCanvas").SetActive(false);
        return true;
    }
}
