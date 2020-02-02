using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleHandler : MonoBehaviour
{
    public string title;

    /**
    * Choose a title for your segment
    **/
    public void ChooseTitle()
    {
        //save lower Third Text to player prefs    
        PlayerPrefs.SetString("lowerThird", title);
        //Switch scene
        SceneManager.LoadSceneAsync("GameUI");
    }
}
