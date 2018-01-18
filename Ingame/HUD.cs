using UnityEngine;
using System.Collections;
using System.Xml;

public class HUD : MonoBehaviour {

	public Vector4 _test;

	public static float timer;
	public static bool isOver;
	public static bool stopTimer;
	public static bool audioIsActive;
	public static bool rightAwnser;
	public static bool withoutAnswer;
	public static float[] mediaConcentration;
	public static float levelDificulty = 0;
	public static bool isMindWaveConnected = false;

	public GameObject[] situations;
	static bool[] situationRnd;

	public GameObject endGame;
	public Texture2D timerSprite;
	public Texture2D meditSprite;
	public GUIStyle textGS;
	public Texture2D pause1;
	public Texture2D pause2;
	public GUIStyle pauseGS;

	public int situationChoose;
	public bool situationLock;

	Texture2D pauseSprite;

	XmlDocument xml = new XmlDocument();

	float counterTimeGame = Screen.width;

	float meditatBox = 0;
	float concentratBox = 0;
	float meditationLerp = 0;
	
	Rect boxObjText = new Rect(0,0,0,0);
	string objText = "";
	Rect boxActText = new Rect(0,0,0,0);
	string actText = "";

	void Start () {
		mediaConcentration = new float[0];
		isOver = false;
		stopTimer = false;
		audioIsActive = true;
		rightAwnser = true;
		withoutAnswer = false;
		if(situationRnd == null){
			situationRnd = new bool[situations.Length];
		}
	
		pauseSprite = pause1;
		pauseGS.normal.background = pauseSprite;
		stopTimer = false;
		int rnd = Random.Range (0, situations.Length);
		while(situationRnd [rnd]){
			rnd = Random.Range (0, situations.Length);
		}

		if(situationLock){
			situations [situationChoose].SetActive (true);
		}
		else{
			situations [rnd].SetActive (true);
		}

		situationRnd [rnd] = true;
		bool roundSituations = true;
		foreach (bool item in situationRnd) {
			if(!item){
				roundSituations = false;
			}
		}
		if(roundSituations){
			levelDificulty += 0.2f;
			/*if(levelDificulty >= 1){
				levelDificulty = 1;
			}*/
			for (int i = 0; i < situationRnd.Length; i++) {
				situationRnd[i] = false;
			}
			situationRnd [rnd] = true;
		}

		xml.Load ("Assets/Resources/xmlSituations.xml");
		switch (GameObject.FindGameObjectWithTag("situations").name) {
		case "situation_1":
			timer = XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION1/HUD/timeToAwnser").InnerText) / ((1.5f*levelDificulty)+1);
			boxObjText = new Rect(XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION1/HUD/objectiveTxtBox/x").InnerText)
			                      ,XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION1/HUD/objectiveTxtBox/y").InnerText),0,0);
			objText = xml.SelectSingleNode("XMLSituations/SITUATION1/HUD/objectiveTxt").InnerText;
			boxActText = new Rect(XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION1/HUD/actionTxtBox/x").InnerText)
			                      ,XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION1/HUD/actionTxtBox/y").InnerText),0,0);
			actText = xml.SelectSingleNode("XMLSituations/SITUATION1/HUD/actionTxt").InnerText;
			break;
		/*case "situation_2":
			timer = XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION2/HUD/timeToAwnser").InnerText);
			boxObjText = new Rect(XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION2/HUD/objectiveTxtBox/x").InnerText)
			                      ,XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION2/HUD/objectiveTxtBox/y").InnerText),0,0);
			objText = xml.SelectSingleNode("XMLSituations/SITUATION2/HUD/objectiveTxt").InnerText;
			boxActText = new Rect(XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION2/HUD/actionTxtBox/x").InnerText)
			                      ,XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION2/HUD/actionTxtBox/y").InnerText),0,0);
			actText = xml.SelectSingleNode("XMLSituations/SITUATION2/HUD/actionTxt").InnerText;
			break;*/
		case "situation_3":
			timer = XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION3/HUD/timeToAwnser").InnerText);
			boxObjText = new Rect(XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION3/HUD/objectiveTxtBox/x").InnerText)
			                      ,XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION3/HUD/objectiveTxtBox/y").InnerText),0,0);
			objText = xml.SelectSingleNode("XMLSituations/SITUATION3/HUD/objectiveTxt").InnerText;
			boxActText = new Rect(XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION3/HUD/actionTxtBox/x").InnerText)
			                      ,XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION3/HUD/actionTxtBox/y").InnerText),0,0);
			actText = xml.SelectSingleNode("XMLSituations/SITUATION3/HUD/actionTxt").InnerText;
			break;
		case "situation_4":
			timer = XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION4/HUD/timeToAwnser").InnerText);
			boxObjText = new Rect(XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION4/HUD/objectiveTxtBox/x").InnerText)
			                      ,XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION4/HUD/objectiveTxtBox/y").InnerText),0,0);
			objText = xml.SelectSingleNode("XMLSituations/SITUATION4/HUD/objectiveTxt").InnerText;
			boxActText = new Rect(XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION4/HUD/actionTxtBox/x").InnerText)
			                      ,XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION4/HUD/actionTxtBox/y").InnerText),0,0);
			actText = xml.SelectSingleNode("XMLSituations/SITUATION4/HUD/actionTxt").InnerText;
			break;
		case "situation_5":
			timer = XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION5/HUD/timeToAwnser").InnerText);
			boxObjText = new Rect(XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION5/HUD/objectiveTxtBox/x").InnerText)
			                      ,XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION5/HUD/objectiveTxtBox/y").InnerText),0,0);
			objText = xml.SelectSingleNode("XMLSituations/SITUATION5/HUD/objectiveTxt").InnerText;
			boxActText = new Rect(XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION5/HUD/actionTxtBox/x").InnerText)
			                      ,XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION5/HUD/actionTxtBox/y").InnerText),0,0);
			actText = xml.SelectSingleNode("XMLSituations/SITUATION5/HUD/actionTxt").InnerText;
			break;
		case "situation_6":
			timer = XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION5/HUD/timeToAwnser").InnerText);
			boxObjText = new Rect(XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION5/HUD/objectiveTxtBox/x").InnerText)
			                      ,XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION5/HUD/objectiveTxtBox/y").InnerText),0,0);
			objText = xml.SelectSingleNode("XMLSituations/SITUATION5/HUD/objectiveTxt").InnerText;
			boxActText = new Rect(XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION5/HUD/actionTxtBox/x").InnerText)
			                      ,XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION5/HUD/actionTxtBox/y").InnerText),0,0);
			actText = xml.SelectSingleNode("XMLSituations/SITUATION5/HUD/actionTxt").InnerText;
			break;
		case "situation_7":
			timer = XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION7/HUD/timeToAwnser").InnerText) / ((3f * HUD.levelDificulty)+1f);
			boxObjText = new Rect(XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION7/HUD/objectiveTxtBox/x").InnerText)
			                      ,XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION7/HUD/objectiveTxtBox/y").InnerText),0,0);
			objText = xml.SelectSingleNode("XMLSituations/SITUATION7/HUD/objectiveTxt").InnerText;
			boxActText = new Rect(XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION7/HUD/actionTxtBox/x").InnerText)
			                      ,XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION7/HUD/actionTxtBox/y").InnerText),0,0);
			actText = xml.SelectSingleNode("XMLSituations/SITUATION7/HUD/actionTxt").InnerText;
			break;
		case "situation_9":
			timer = XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION7/HUD/timeToAwnser").InnerText);
			boxObjText = new Rect(XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION7/HUD/objectiveTxtBox/x").InnerText)
			                      ,XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION7/HUD/objectiveTxtBox/y").InnerText),0,0);
			objText = xml.SelectSingleNode("XMLSituations/SITUATION7/HUD/objectiveTxt").InnerText;
			boxActText = new Rect(XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION7/HUD/actionTxtBox/x").InnerText)
			                      ,XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION7/HUD/actionTxtBox/y").InnerText),0,0);
			actText = xml.SelectSingleNode("XMLSituations/SITUATION7/HUD/actionTxt").InnerText;
			break;
		}
	}

	void Update () {
		if(mediaConcentration.Length == 0){
			mediaConcentration = new float[1];
			mediaConcentration[0] = scriptInput.Meditation();
		}
		else{
			float[] aux = mediaConcentration;
			mediaConcentration = new float[mediaConcentration.Length+1];
			for (int i = 0; i < aux.Length; i++) {
				mediaConcentration[i] = aux[i];
			}
			mediaConcentration[mediaConcentration.Length-1] = scriptInput.Meditation();
		}

		if(!stopTimer){
			counterTimeGame -= (Screen.width*Time.deltaTime)/timer;
		}
		if(meditationLerp != Mindwave.getAttention()){
			meditationLerp = Mathf.Lerp(meditationLerp,Mindwave.getAttention(),0.05f);
			meditatBox = (Mathf.Lerp(meditationLerp,Mindwave.getAttention(),0.05f) / 100f) * -200f;
		}

		//meditatBox = (scriptInput.Meditation() / 100f) * -200f;
		concentratBox = (1 / 100f) * -200f;
		isMindWaveConnected = Mindwave.ConnectionStatus == 0;
		if(counterTimeGame <= 0){
			if (withoutAnswer){
				Debug.Log ("WA:ACERTOU");
				rightAwnser = true;
			}
			else{
				Debug.Log ("WA:ERROU");
				rightAwnser = false;
			}
			isOver = true;
		}
		if(isOver){
			this.gameObject.SetActive(false);
			GameObject.FindGameObjectWithTag("situations").SetActive(false);
			endGame.SetActive(true);
			isOver = false;
		}
	}

	void OnGUI(){
		GUI.Box (new Rect(1187,335,34,23),((int)meditationLerp).ToString());
		GUI.DrawTexture (new Rect(1200,328,10,meditatBox), meditSprite);
		GUI.DrawTexture (new Rect(1230,328,10,concentratBox), meditSprite);
		if (!stopTimer) {
			GUI.DrawTexture (new Rect(0,0,counterTimeGame,20), timerSprite);	
		}
		if(GUI.Button(new Rect(1160,28,pauseSprite.width,pauseSprite.height),"",pauseGS)){
			if(Time.timeScale == 0){
				Time.timeScale = 1;
				pauseSprite = pause1;
				pauseGS.normal.background = pauseSprite;
			}
			else{
				Time.timeScale = 0;
				pauseSprite = pause2;
				pauseGS.normal.background = pauseSprite;
			}
		}
		GUI.Box (boxObjText,objText,textGS);
		GUI.Box (boxActText,actText,textGS);
	}
}
