using UnityEngine;
using System.Collections;

public class statusToCross : MonoBehaviour {

	void Start(){
		switch (this.gameObject.name) {
		case "option_1":
			this.gameObject.name = "wrong";
			break;
		case "option_2":
			this.gameObject.name = "wrong";
			break;
		case "option_3":
			this.gameObject.name = "wrong";
			break;
		case "option_4":
			this.gameObject.name = "wrong";
			break;
		case "option_5":
			this.gameObject.name = "wrong";
			break;
		}
	}

	public void IsOkToCross(){
		this.gameObject.name = "right";
	}
	
	public void IsNotOkToCross(){
		this.gameObject.name = "wrong";
	}
}
