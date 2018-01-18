using UnityEngine;
using System.Collections;

public class scriptInput : MonoBehaviour {

	static float meditation = 50;

	public static bool Blink(){
		/*if(Input.GetKeyDown(KeyCode.Space)){
			return true;
		}
		else{
			return false;
		}*/
		return Mindwave.getBlink ();
	}
	public static float Meditation(){
		/*if(Input.GetKey(KeyCode.A)){
			if(meditation <= 100){
				meditation += Random.Range(-0.8f,1f);
			}
		}
		else if(meditation >= 0){
			meditation -= Random.Range(-0.8f,1f);
		}
		return meditation;*/
		return Mindwave.getAttention ();
	}
}
