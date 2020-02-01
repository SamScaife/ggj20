using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace JoeyDinger.SamScaife {
    public class DialogueManager : MonoBehaviour
    {
        //theJSON file to load. has a default to stop error message
        [SerializeField]
        private TextAsset jsonDataFIle = null;

        //the list of dialogue to work through
        public List<DialogueNode> Dialogue;

        // Where to go when the endScene action is triggered
        public string nextScene;

        //class to handle json importing
        private JsonImporter jsonImporter;

        //GameObject to show dialogue
        [SerializeField]
        private DialogueInstanceManager dialogueInstance = null;

        // Use this for initialization
        void Start()
        {
            //set up the jsonImporter
            jsonImporter = new JsonImporter(jsonDataFIle);

            //read the json
            Dialogue = jsonImporter.ReadJSON();

            //render the first text node
            dialogueInstance.Render(Dialogue[0]);
        }

        //Swap dialogue text - triggered via events
        public void ChangeDialogue(string target)
        {
            //find the target dialogue
            DialogueNode dialogueToRender = Dialogue.Find(node => node.title == target);

            //render the target node
            dialogueInstance.Render(dialogueToRender);
        }

       



    }
}
