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
        private GameObject buttonsContainer;
        //the button prefab
        private GameObject buttonPrefab;
        //the DialogueManger
        public DialogueManager dialogueManager = null;

        private void Start()
        {
            //set up ingame component links
            TMP_Text[] childTMPComponents = gameObject.GetComponentsInChildren<TMP_Text>();
            //speaker is the first child
            speaker = childTMPComponents[0];
            //body is the second child
            body = childTMPComponents[1];
            //button container is the third child
            buttonsContainer = transform.GetChild(2).gameObject;

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

            //clear any existing buttons
            foreach (Transform child in buttonsContainer.transform)
            {
                GameObject.Destroy(child.gameObject);
            }

            //add the buttons
            foreach (DialogueAction action in data.actions) {
                //create a new button
                GameObject newButton = Instantiate(buttonPrefab,buttonsContainer.transform,false);
                //change the buttons text
                newButton.transform.GetChild(0).GetComponent<TMP_Text>().text = action.text;
                //set up event listener
                Button buttonComponent = newButton.GetComponent<Button>();
                buttonComponent.onClick.AddListener(delegate { HandleButtonClicked(action); });
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