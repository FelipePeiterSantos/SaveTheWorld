using UnityEngine;
using System.Collections;
using System.Xml;

public class situation1 : MonoBehaviour {

	XmlDocument xmlSituation = new XmlDocument ();

	public GameObject[] trashPF;
	public GameObject[] trashHoldingPF;
	public GameObject glow;
	public GameObject trashHold;

	int selectTrash = 1;
	double switchSelect;
	float counter = 0;
	bool counterResultTrash = false;
	float resultTrash = 0;
	bool notSelected = true;
	GameObject trashInHand;
	GameObject trashGlowing;

	GameObject[] trashInScreen = new GameObject[3];
	Vector3 pos1;
	Vector3 pos2;
	Vector3 pos3;

	void Start () {
		xmlSituation.Load ("Assets/Resources/xmlSituations.xml");
		string url = "XMLSituations/SITUATION1/posTrash";
		pos1 = new Vector3 (XmlConvert.ToInt32(xmlSituation.SelectSingleNode(url+"1/x").InnerText),XmlConvert.ToInt32(xmlSituation.SelectSingleNode(url+"1/y").InnerText),0);
		pos2 = new Vector3 (XmlConvert.ToInt32(xmlSituation.SelectSingleNode(url+"2/x").InnerText),XmlConvert.ToInt32(xmlSituation.SelectSingleNode(url+"2/y").InnerText),0);
		pos3 = new Vector3 (XmlConvert.ToInt32(xmlSituation.SelectSingleNode(url+"3/x").InnerText),XmlConvert.ToInt32(xmlSituation.SelectSingleNode(url+"3/y").InnerText),0);
		switchSelect = XmlConvert.ToDouble(xmlSituation.SelectSingleNode("XMLSituations/SITUATION1/timerSwitch").InnerText);

		trashInScreen[0] = trashPF[Random.Range(0,trashPF.Length)];
		trashInScreen[1] = trashPF[Random.Range(0,trashPF.Length)];
		trashInScreen[2] = trashPF[Random.Range(0,trashPF.Length)];
		while (trashInScreen[1] == trashInScreen[0]) {
			trashInScreen[1] = trashPF[Random.Range(0,trashPF.Length)];
		}
		while (trashInScreen[2] == trashInScreen[0] || trashInScreen[2] == trashInScreen[1]) {
			trashInScreen[2] = trashPF[Random.Range(0,trashPF.Length)];
		}

		GameObject aux_1 = Instantiate (trashInScreen [0], pos1, Quaternion.identity) as GameObject;
		aux_1.transform.parent = this.transform;
		aux_1 = Instantiate (trashInScreen [1], pos2, Quaternion.identity) as GameObject;
		aux_1.transform.parent = this.transform;
		aux_1 = Instantiate (trashInScreen [2], pos3, Quaternion.identity) as GameObject;
		aux_1.transform.parent = this.transform;
		trashGlowing = Instantiate (glow,new Vector3(0,0,0),Quaternion.identity) as GameObject;
		trashGlowing.transform.parent = this.transform;

		trashInHand = Instantiate (trashHoldingPF [Random.Range(0,trashHoldingPF.Length)], trashHold.transform.position, Quaternion.identity) as GameObject;
		trashInHand.transform.SetParent (trashHold.transform);

		HUD.withoutAnswer = true;
		foreach (var aux1 in trashInScreen) {
			if(trashInHand.gameObject.tag == aux1.gameObject.tag){
				HUD.withoutAnswer = false;
			}
		}

		if(HUD.withoutAnswer){
			HUD.timer = (float)XmlConvert.ToDouble(xmlSituation.SelectSingleNode("XMLSituations/SITUATION1/timeCounter").InnerText);
		}


	}

	void Update(){
		if(notSelected){
			counter += Time.deltaTime;
			if(counter < switchSelect){
				selectTrash = 1;
				trashGlowing.transform.position = pos1;
			}
			else if(counter < switchSelect*2){
				selectTrash = 2;
				trashGlowing.transform.position = pos2;
			}
			else if(counter < switchSelect*3){
				selectTrash = 3;
				trashGlowing.transform.position = pos3;
			}
			else{
				counter = 0;
			}
		}

		if(scriptInput.Blink()){
			HUD.stopTimer = true;
			counterResultTrash = true;
			notSelected = false;
			if(selectTrash == 1){
				trashHold.GetComponent<Animator>().SetInteger("trashSelected",1);
			}
			else if (selectTrash == 2){
				trashHold.GetComponent<Animator>().SetInteger("trashSelected",2);
			}
			else if (selectTrash == 3){
				trashHold.GetComponent<Animator>().SetInteger("trashSelected",3);
			}
		}

		if(counterResultTrash){
			resultTrash += Time.deltaTime;
			if(resultTrash >= 3){ //3 = Seconds of animation
				if(trashInScreen[selectTrash-1].gameObject.tag == trashInHand.gameObject.tag){
					Debug.Log ("S1:CERTO");
					HUD.rightAwnser = true;
					HUD.isOver = true;
				}
				else{
					HUD.rightAwnser = false;
					Debug.Log ("S1:ERROU");
					HUD.isOver = true;
				}
				counterResultTrash = false;
			}
		}
		else if(HUD.isOver){

			if(HUD.withoutAnswer){
				HUD.rightAwnser = true;
				Debug.Log ("S1:CERTO");
			}
			else{
				HUD.rightAwnser = false;
				Debug.Log ("S1:ERROU");
			}
		}
	}
}
