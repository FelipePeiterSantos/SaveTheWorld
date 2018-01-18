using UnityEngine;
using System.Collections;

public class endGame : MonoBehaviour {

	public int _1, _2, _3, _4;

	public GUIStyle gS_score;
	public GUIStyle gS_text;
	static int totalScore = 0;
	public int points;
	float counterNextSituation = 3;
	float averageMeditation = 0;

	void Start () {
		if(HUD.rightAwnser){
			points = 100;
		}
		else {
			points = 0;
		}

		for (int i = 0; i < HUD.mediaConcentration.Length; i++) {
			averageMeditation += HUD.mediaConcentration[i];
		}
		averageMeditation = averageMeditation / HUD.mediaConcentration.Length;

	}


	void Update () {
		if(points > 0){
			--points;
			++totalScore;
		}
		else{
			counterNextSituation -= Time.deltaTime;
			if(counterNextSituation <= 0){
				Application.LoadLevel("Gameplay");
			}
		}
	}

	void OnGUI(){
		GUI.Label (new Rect(682,635,0,0),"Concentraçao media: " + ((int)averageMeditation).ToString(),gS_text);
		GUI.Box (new Rect(Screen.width/2,Screen.height/2+155,0,0),totalScore.ToString(),gS_score);
		GUI.Box (new Rect(Screen.width/2,445+155,0,0),"Level Completo: "+points,gS_text);
	}
}
