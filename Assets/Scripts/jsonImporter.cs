using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

namespace JoeyDinger.SamScaife
{

    public class JsonImporter
    {
        // Pass the file in here instead of in the constructor
        //read All from json File
        public List<DialogueNode> ReadJSON(TextAsset jsonDataFile) {
            //set up list for response
            List<DialogueNode> response = new List<DialogueNode>();

            //convert data file to string
            string jsonString = jsonDataFile.ToString();

            //parse json
            var parsedJSON = JSON.Parse(jsonString);

            //loop through the json and set up Dialog Nodes
            foreach (JSONNode node in parsedJSON) {
                //create a new dialog
                DialogueNode dialogue = new DialogueNode(node["title"], node["body"], node["tags"]);
                //process the node
                dialogue.Setup();
                //add node to the list
                response.Add(dialogue);
            }

            //pass the response back
            return response;
        }
    }
}
