using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;

namespace JoeyDinger.SamScaife {
    public class DialogueInstanceManager : MonoBehaviour
    {
        //link up to ingame instances that will change
        private TMP_Text speaker;
        private TMP_Text body;
        private GameObject verticalButtonsContainer;
        private GameObject horizontalButtonsContainer;
        private GameObject buttonsContainer;
        //the button prefab
        private GameObject buttonPrefab;
        //the DialogueManger
        public DialogueManager dialogueManager = null;

        void Awake()
        {
            //set up ingame component links
            TMP_Text[] childTMPComponents = gameObject.GetComponentsInChildren<TMP_Text>();
            //speaker is the first child
            speaker = childTMPComponents[0];
            //body is the second child
            body = childTMPComponents[1];
            //vertical button container is the third child
            verticalButtonsContainer = transform.GetChild(2).gameObject;
            // Horizontal button container comes next
            horizontalButtonsContainer = transform.GetChild(3).gameObject;

            //find the putton prefab and load it ready for use
            buttonPrefab = Resources.Load("Prefabs/Button") as GameObject;
        }

        //populate the dialogue instance with data
        public void Render(DialogueNode data) {
            if (data != null) {
                //set the speaker
                speaker.text = data.speaker;
                //set the body text
                body.text = data.body;

                //clear any existing buttons from vertical container
                foreach (Transform vChild in verticalButtonsContainer.transform)
                {
                    GameObject.Destroy(vChild.gameObject);
                }
                //clear any existing buttons from horizontal container
                foreach (Transform hChild in horizontalButtonsContainer.transform)
                {
                    GameObject.Destroy(hChild.gameObject);
                }

                //add the buttons
                foreach (DialogueAction action in data.actions) {
                    if (data.tags == "vertical") 
                    {
                        buttonsContainer = verticalButtonsContainer;
                        horizontalButtonsContainer.SetActive(false);
                        verticalButtonsContainer.SetActive(true);
                    }
                    else
                    {
                        buttonsContainer = horizontalButtonsContainer;
                        horizontalButtonsContainer.SetActive(true);
                        verticalButtonsContainer.SetActive(false);
                    }
                    //create a new button
                    GameObject newButton = Instantiate(buttonPrefab, buttonsContainer.transform,false);
                    //change the buttons text
                    newButton.transform.GetChild(0).GetComponent<TMP_Text>().text = action.text;
                    //set up event listener
                    Button buttonComponent = newButton.GetComponent<Button>();
                    buttonComponent.onClick.AddListener(delegate { HandleButtonClicked(action); });

                    var charLength = action.text.Length;

                    // Set button size to char length + 20 each side for padding
                    float targetWidth = (charLength * 20) + 40;
                    //set min size of 160 width
                    if (targetWidth < 160f) {
                        targetWidth = 160f;
                    }
                    newButton.GetComponent<RectTransform>().sizeDelta = new Vector2(targetWidth, 60);
                }
            }
        }

        public void HandleButtonClicked(DialogueAction action) {
            // Check if we need to end the scene
            if (action.targetNode == "endScene") {
                SceneManager.LoadScene(dialogueManager.GetComponent<DialogueManager>().nextScene);
            }
            //trigger a dialoge change
            dialogueManager.ChangeDialogue(action.targetNode);
        }


    }

}