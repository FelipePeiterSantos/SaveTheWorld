using UnityEngine;
using System.Collections;

public class situation4 : MonoBehaviour {

	public GameObject sit1,sit2;

	float aux = 0;


	void Start(){
		if(this.gameObject.tag == "situations"){
			int rnd = Random.Range(0,2);
			if(rnd == 1){
				sit1.SetActive(true);
				sit2.SetActive(false);
			}
			else{
				sit1.SetActive(false);
				sit2.SetActive(true);
			}
		}
	}

	void Update () {
		if(this.gameObject.tag != "situations"){
			if(scriptInput.Meditation() >= (10 + (HUD.levelDificulty*30))){

				if(aux < 1){
					aux += 0.01f;
				}
			}
			else{
				if(aux > 0){
					aux -= 0.01f;
				}
			}
			GetComponent<Animator>().speed = aux;
		}
	}

	public void End(){
		HUD.rightAwnser = true;
		HUD.isOver = true;
		Debug.Log("CERTO");
	}
}
