using UnityEngine;
using System.Collections;

public class danger : MonoBehaviour {

	public GameObject[] dangers;
	GameObject currentDanger;
	
	
	void Start () {
		currentDanger = dangers [Random.Range (0, dangers.Length)];
		GameObject aux = Instantiate (currentDanger, transform.position, Quaternion.identity) as GameObject;
		aux.transform.parent = this.transform;

	}
	void Update () {
	
	}
}
