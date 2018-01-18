using UnityEngine;
using System.Collections;

public class spawnChoices : MonoBehaviour {

	public GameObject[] choices;
	// Use this for initialization
	void Awake () {
		int rnd = Random.Range (0, choices.Length+1);
		if(rnd <= choices.Length-1){
			GameObject aux = Instantiate (choices[rnd],transform.position,Quaternion.identity) as GameObject;
			aux.transform.parent = this.transform;
			aux.gameObject.name = choices[rnd].gameObject.name;
			if(choices[rnd].gameObject.name == "poste"){
				aux.transform.position += new Vector3(0,2,0); 
			}
			else if(choices[rnd].gameObject.name == "buraco"){
				aux.transform.position += new Vector3(0,-2,0);
			}
			else if (choices[rnd].gameObject.name == "rampa"){
				this.gameObject.name = "awnser";
			}
		}
	}

	void Update () {
	
	}
}
