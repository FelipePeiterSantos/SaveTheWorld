using UnityEngine;
using System.Collections;

public class situation3 : MonoBehaviour {
	
	void Update () {
		if(scriptInput.Meditation() >= 40){
			stopChar.speedAnimation(false);
		}
		else{
			stopChar.speedAnimation(true);
		}
	}
}
