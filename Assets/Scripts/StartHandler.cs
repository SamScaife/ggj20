using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartHandler : MonoBehaviour
{
    public GameObject instructionsCanvas;

    // Start is called before the first frame update
    void Start()
    {
        instructionsCanvas.SetActive(false);
    }

    public void ShowInstructions()
    {
        instructionsCanvas.SetActive(true);
        Canvas canvas = gameObject.transform.parent.GetComponent<Canvas>();
        canvas.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("LowerThirdTitlePickerSceneOne");
    }

    public void QuitGame() {
        //Quit the game
        Application.Quit();
    }
}
