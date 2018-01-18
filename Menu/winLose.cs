using UnityEngine;
using System.Collections;

public class winLose : MonoBehaviour {

	public GameObject win;
	public GameObject lose;
	public GameObject score;
	public GUIStyle guiStyle;

	public Animator anim1WIN;
	public Animator anim2WIN;
	public Animator anim1LOSE;
	public Animator anim2LOSE;
	

	void Start () {

		if(this.gameObject.name == "endGame"){
			if(HUD.rightAwnser){
				win.SetActive(true);
				anim1WIN.SetBool("var",true);
				anim2WIN.SetBool("var",true);
			}
			else{
				lose.SetActive(true);
				anim1LOSE.SetBool("var",false);
				anim2LOSE.SetBool("var",false);
			}
		}

		else if(this.gameObject.name == "win"){
			Invoke("GoToScore",5f);
		}

		else if(this.gameObject.name == "lose"){
			Invoke("GoToScore",5f);
		}
	}
	public void GoToScore(){
		this.gameObject.SetActive (false);
		score.SetActive (true);
	}

	void OnGUI (){
		if(this.gameObject.name == "win"){
			GUI.Label(new Rect(Screen.width/2,Screen.height/2,100,100),"ACERTOU!!", guiStyle);
			GUI.Label(new Rect(Screen.width/2,Screen.height/2,10,10),"+");

		}
		if(this.gameObject.name == "lose"){
			GUI.Label(new Rect(Screen.width/2,Screen.height/2,100,100),"ERROU!!", guiStyle);
		}
	}
}
