using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LowerThirdRender : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //find the text asset in children
        TMP_Text LowerThirdText = gameObject.GetComponentInChildren<TMP_Text>();

        //set the text to the value stored in player prefs
        LowerThirdText.text = PlayerPrefs.GetString("lowerThird");

        //force a update so that we can get the size
        LowerThirdText.ForceMeshUpdate();

        //Grab the length of the text from text element
        Vector2 textBoxSize = LowerThirdText.GetRenderedValues();


        Debug.Log(textBoxSize);

        //find the image asset - should be the first child
        GameObject imageObject = transform.GetChild(0).gameObject;

        //set the target width of the image - account for 20 margin left and right
        float targetBoxWidth = textBoxSize[0] + 40f;
        //set the size of the box
        imageObject.GetComponent<RectTransform>().sizeDelta = new Vector2(targetBoxWidth, 60);

    }

}
