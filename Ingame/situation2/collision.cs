using UnityEngine;
using System.Collections;

public class collision : MonoBehaviour {
	
   private bool desisao = true;
	
	void Start () {
		HUD.withoutAnswer = true;
		desisao = true;
	}
	
	void Update () {

	}
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "hand 1(Clone)")
        {
			HUD.rightAwnser = false;
			HUD.isOver = true;
			Debug.Log("S2:PERDEU");
            desisao = false;
        }
    }
}
