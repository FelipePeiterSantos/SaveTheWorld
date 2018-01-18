using UnityEngine;
using System.Collections;

public class stopChar : MonoBehaviour {
	
	static Animator anim;
	static bool animIsOver = false;
	public GameObject animChar;

	void Start () {
		anim = GetComponent<Animator> ();
		anim.speed = 0.65f + (1.35f * HUD.levelDificulty);
		animIsOver = false;
		HUD.withoutAnswer = true;
	}

	void Update(){
		animChar.GetComponent<Animator> ().SetFloat("anim",anim.speed);
	}

	public static void speedAnimation(bool aux){

		if(animIsOver){
			anim.speed = 0;
		}
		else if(aux){
			if(anim.speed < (0.65f + (1.35f * HUD.levelDificulty))){
				anim.speed += 0.005f;
			}

		}
		else if(!aux){
			if(anim.speed > 0){
				anim.speed -= 0.005f + (0.005f * HUD.levelDificulty);//0.01
			}
		}
	}
	public void isOver(){
		Debug.Log("S3:ACERTOU");
		HUD.rightAwnser = true;
		HUD.isOver = true;
	}
	public void OnTriggerEnter2D(Collider2D coll){
		if(coll.gameObject.tag == "danger"){
			Debug.Log ("S3:ERROU");
			HUD.rightAwnser = false;
			HUD.isOver = true;
		}
	}
}
