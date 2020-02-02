using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;


namespace JoeyDinger.SamScaife {
    public class DialogueManager : MonoBehaviour
    {
        //theJSON file to load. has a default to stop error message
        [SerializeField]
        public TextAsset jsonDataFIle = null;

        //the list of dialogue to work through
        public List<DialogueNode> Dialogue;

        // Where to go when the endScene action is
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
            jsonImporter = new JsonImporter();

            //read the json
            Dialogue = jsonImporter.ReadJSON(jsonDataFIle);

            //render the first text node
            dialogueInstance.Render(Dialogue[0]);
        }

        public void ChangeJsonFile(string newFileName)
        {
            TextAsset newFile = Resources.Load("Data/" + newFileName) as TextAsset;
            jsonDataFIle = newFile;
            
            //read the json
            Dialogue = jsonImporter.ReadJSON(newFile);

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
