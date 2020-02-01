using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.Text.RegularExpressions;


namespace JoeyDinger.SamScaife
{
    [Serializable]
    public class DialogueNode
    {
		public string title;
		public string body;
		public string speaker;
		public Speaker speakerID;
		public List<DialogueAction> actions;

		public DialogueNode(string _title, string _body)
		{
			title = _title;
			body = _body;
		}

		//pull out data from the body and clean it up
		public void Setup() {
			//set up the speaker
			SetupSpeaker();

			//set up the actions
			//initialise the list
			actions = new List<DialogueAction>();
			SetupActions();

			//set up functions
			SetupFunctions();

			//clean off white space from the body
			body.Trim();

			//trim new lines from end
			body = TrimTrailingNewLines(body);
		}

		public void SetupSpeaker() {
			//set up speaker
			//query to match anything inbetween {}
			var speakerRegex = new Regex("{(.*?)}");
			//find a match 
			Match speakerMatch = speakerRegex.Match(body);
			if (speakerMatch.Success)
			{
				//found a speaker

				//set the speaker name
				// speaker = speakerMatch.Groups[1].ToString();

				//set the speaker ID
				switch (speakerMatch.Value) {
					case "{None}":
						speakerID = Speaker.None;
						speaker = "";
						break;
					case "{Player}":
						speakerID = Speaker.Player;
						speaker = "Player";
						break;
					case "{JoeyDinger}":
						speakerID = Speaker.JoeyDinger;
						speaker = "Joey Dinger";
						break;
					case "{Audience}":
						speakerID = Speaker.None;
						speaker = "Audience";
						break;
					case "{DwightBishop}":
						speakerID = Speaker.DwightBishop;
						speaker = "Dwight Bishop";
						break;
					case "{ILanaBishop}":
						speakerID = Speaker.IlanaBishop;
						speaker = "Ilana Bishop";
						break;
					case "{CoreyMcCormack}":
						speakerID = Speaker.CoreyMcCormack;
						speaker = "Corey McCormack";
						break;
					case "{CareyMcMormack}":
						speakerID = Speaker.CareyMcMormack;
						speaker = "Carey McCormack";
						break;
					case "{StudioExec}":
						speakerID = Speaker.StudioExec;
						speaker = "Studio Executive";
						break;
				}

				//Remove the speaker from the body and the first new line
				body = body.Remove(0, speakerMatch.Value.Length +1);
			}
			else
			{
				//did not find a speaker
				throw new Exception("Unable to find speaker in node " + title);
			}
		}

		public void SetupActions() {
			//set up the actions

			//query to match anything inbetween[[]] - @ before string make it ignore \ as an ecape character
			var actionRegex = new Regex(@"\[\[(.*?)\]\]");

			//find all matches 
			MatchCollection actionMatches = actionRegex.Matches(body);
			if (actionMatches.Count > 0) {
				//found a match
				//loop through matches
				foreach (Match match in actionMatches) {
					//create a new action to be populated
					DialogueAction newDialogueAction = new DialogueAction();
				
					//split the text and target	
					string[] parameters = match.Groups[1].ToString().Split(new Char[] {'|'});

					//updated the dialogue action properties
					newDialogueAction.text = parameters[0];
					newDialogueAction.targetNode = parameters[1];
		
					//add the action to actions array
					actions.Add(newDialogueAction);

					//remove the action from the body
					body = body.Replace(match.Value, "");
				}
			} 
			else 
			{
				//@todo does this need to be handled?
				//Debug.Log("did not find any actions in " + title);
			}


		}
		public void SetupFunctions() {
			//set up functions

			//query to match anything inbetween <<>>
			var functionRegex = new Regex("<<(.*?)>>");

			//find all matches
			MatchCollection functionMatches = functionRegex.Matches(body);
			if (functionMatches.Count > 0) {
				//found a match
				//loop through matches
				foreach (Match match in functionMatches) {
					//TODO: handle the functions

					//remove the action from the body
					body = body.Replace(match.Value, "");
				}
			}
		}

		//remove \n from the end of a string
		public string TrimTrailingNewLines(string targetString) {
			while (targetString.EndsWith("\n"))
			{
				//remove the last character (which should be a new line)
				targetString = targetString.Substring(0, targetString.Length - 1);
			}
			return targetString;
		}
	}
}

//enum for speakers
public enum Speaker {None, StudioExec, Player, JoeyDinger, Audience, DwightBishop, IlanaBishop, CoreyMcCormack, CareyMcMormack}
