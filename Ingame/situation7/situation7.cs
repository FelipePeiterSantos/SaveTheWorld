using UnityEngine;
using System.Collections;
using System.Xml;

public class situation7 : MonoBehaviour {
	public GameObject selectArrow;
	public GameObject[] choices;
	public GameObject char_anim;

	float counterArrow = 0;
	float counterArrow_xml = 2;

	int selected;

	void Start(){
		bool flag = true;
		for (int i = 0; i < choices.Length; i++) {
			if(choices[i].gameObject.name == "awnser"){
				flag = false;
			}
		}
		if(flag){
			HUD.withoutAnswer = true;
			HUD.timer = 7;
		}
	}

	void Update(){

		counterArrow += Time.deltaTime;
		if(selectArrow){
			if(counterArrow < counterArrow_xml){
				selectArrow.transform.position = choices[0].transform.position + new Vector3(0,2.5f,0);
				selected = 0;
			}
			else if(counterArrow < counterArrow_xml * 2){
				selectArrow.transform.position = choices[1].transform.position + new Vector3(0,2.5f,0);
				selected = 1;
			}
			else if(counterArrow < counterArrow_xml * 3){
				selectArrow.transform.position = choices[2].transform.position + new Vector3(0,2.5f,0);
				selected = 2;
			}
			else{
				counterArrow = 0;
			}
		}

		if(scriptInput.Blink()){
			char_anim.GetComponent<Animator>().SetInteger("selected",selected+1);
			char_anim.transform.GetChild(0).GetComponent<Animator>().SetBool("wheel",true);
			HUD.stopTimer = true;
			Destroy(selectArrow.gameObject);
		}
	}
	public void AnimationIsOver(){
		if(choices[selected].gameObject.name == "awnser"){
			HUD.rightAwnser = true;
				HUD.isOver = true;
				Debug.Log("CERTO");
			
		}
		else{
			HUD.rightAwnser = false;
				HUD.isOver = true;
				Debug.Log("ERRADO");
		}
	}
}