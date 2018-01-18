using UnityEngine;
using System.Collections;

public class situation5 : MonoBehaviour {

	public Animation char_Animator;	
	public GameObject[] situationsOption;
	Animation situationActived_animation;

	int rndSituation;

	void Start(){
		rndSituation = Random.Range (0,situationsOption.Length);
		situationsOption [rndSituation].SetActive (true);
		situationActived_animation = situationsOption [rndSituation].GetComponent<Animation> ();
	}

	void Update () {

		if(scriptInput.Blink()){
			//situationActived_animation.Stop();
			if(situationsOption [rndSituation].name == "right"){
				char_Animator.Play();
			}
			else{
				HUD.rightAwnser = false;
				HUD.isOver = true;
			}
		}
	}

	public void AnimationIsOver(){
		HUD.rightAwnser = true;
		HUD.isOver = true;
		Debug.Log("CERTO");
	}
}
