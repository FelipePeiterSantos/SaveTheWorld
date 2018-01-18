using UnityEngine;
using System;
using System.Collections;
using System.Xml;

public class GUI_Interface : MonoBehaviour {

	public int _1 = 0;
	public int _2 = 0;
	public bool lockLayout = false;
	public int layoutNum = 0;

	public GUIStyle guiStyle;
	public Texture2D title;
	public GameObject world3D;
	public Sprite BG1;
	public Sprite BG2;
	public Sprite BG3;
	public GameObject BG;
	public Texture2D logo;
	public GUIStyle gS_Logo;
	public Font fontTitle;

	public Texture2D limiar;
	public Texture2D sd;
	public Texture2D sd1;
	public Texture2D rightArrow;
	public Texture2D leftArrow;
	Texture2D auxSD;

	public GameObject[] char_anim;
	public Texture2D unconnectedMindwave;
	public Texture2D connectedMindwave;

	public static bool isMindwaveConnected = false;
	public static int statusInterface = 0; //0 = Logo, 1 = Menu Principal, 2 = CONFIGURAÇOES, 3 = CREDITOS, 4 = JOGAR, 5 = GAMEOVER
	XmlDocument xml = new XmlDocument();
	string[] layoutIndex = new string[]{"BTlayout/layout1/","BTlayout/layout2/","BTlayout/layout3/"};
	int randLayout;
	float alphaLogo = 0;
	float cdLogo = 3f;

	void Start () {
		GameObject mindWave_gameObject = new GameObject ();
		mindWave_gameObject.name = "MindWave_Plugin";
		mindWave_gameObject.AddComponent<Mindwave>();
		DontDestroyOnLoad (mindWave_gameObject);

		world3D = Instantiate (world3D,new Vector3(0,0,0),Quaternion.Euler(270,0,0)) as GameObject;
		world3D.renderer.enabled = false;
		world3D.transform.parent = this.transform;
		for (int i = 0; i < char_anim.Length; i++) {
			char_anim[i] = Instantiate(char_anim[i],new Vector3(0,0,0),Quaternion.identity) as GameObject;
			char_anim[i].name = "anim"+i;
			char_anim[i].SetActive(false);
			char_anim[i].transform.parent = transform;
		}
		
		xml.Load("Assets/Resources/xmlMenu.xml");
		if(lockLayout){
			randLayout = layoutNum;
		}
		else{
			randLayout = UnityEngine.Random.Range(0,layoutIndex.Length);
		}
		auxSD = sd;
	}

	void OnGUI () {
		int x;
		int y;
		int h;
		int w;
		string txt;

		switch (statusInterface) {
		case 0:
			GUI.color = new Vector4(1,1,1,alphaLogo);

			GUI.DrawTexture(new Rect(Screen.width/2-logo.width/2,Screen.height/2-logo.height/2,logo.width,logo.height),logo);

			if(alphaLogo < 1 && cdLogo == 3){
				alphaLogo += 0.005f;
			}
			else if(alphaLogo > 1 && cdLogo > 0){
				cdLogo -= Time.deltaTime;
			}
			else {
				alphaLogo -= 0.005f;
				if(alphaLogo < 0){
					statusInterface = 1;
				}
			}
			break;
		case 1:
			isMindwaveConnected = Mindwave.ConnectionStatus == 0;
			if(isMindwaveConnected){
				GUI.DrawTexture (new Rect(1180,0,connectedMindwave.width,connectedMindwave.height),connectedMindwave);
			}
			else{
				GUI.DrawTexture (new Rect(1180,0,unconnectedMindwave.width,unconnectedMindwave.height),unconnectedMindwave);
			}
		
			x = Convert.ToInt32(xml.SelectSingleNode(layoutIndex[randLayout]+"BTplay/x").InnerText);
			y = Convert.ToInt32(xml.SelectSingleNode(layoutIndex[randLayout]+"BTplay/y").InnerText);
			h = Convert.ToInt32(xml.SelectSingleNode(layoutIndex[randLayout]+"BTplay/h").InnerText);
			w = Convert.ToInt32(xml.SelectSingleNode(layoutIndex[randLayout]+"BTplay/w").InnerText);
			txt = xml.SelectSingleNode(layoutIndex[randLayout]+"BTplay/text").InnerText;
			if(button(x,y,h,w,txt)){
				statusInterface = 4;
				Application.LoadLevel("Gameplay");
			}


			x = Convert.ToInt32(xml.SelectSingleNode(layoutIndex[randLayout]+"BTconfig/x").InnerText);
			y = Convert.ToInt32(xml.SelectSingleNode(layoutIndex[randLayout]+"BTconfig/y").InnerText);
			h = Convert.ToInt32(xml.SelectSingleNode(layoutIndex[randLayout]+"BTplay/h").InnerText);
			w = Convert.ToInt32(xml.SelectSingleNode(layoutIndex[randLayout]+"BTplay/w").InnerText);
			txt = xml.SelectSingleNode(layoutIndex[randLayout]+"BTconfig/text").InnerText;
			if(button(x,y,h,w,txt)){
				statusInterface = 2;
			}

			x = Convert.ToInt32(xml.SelectSingleNode(layoutIndex[randLayout]+"BTcredit/x").InnerText);
			y = Convert.ToInt32(xml.SelectSingleNode(layoutIndex[randLayout]+"BTcredit/y").InnerText);
			h = Convert.ToInt32(xml.SelectSingleNode(layoutIndex[randLayout]+"BTplay/h").InnerText);
			w = Convert.ToInt32(xml.SelectSingleNode(layoutIndex[randLayout]+"BTplay/w").InnerText);
			txt = xml.SelectSingleNode(layoutIndex[randLayout]+"BTcredit/text").InnerText;
			if(button(x,y,h,w,txt)){
				statusInterface = 3;
			}

			x = Convert.ToInt32(xml.SelectSingleNode(layoutIndex[randLayout]+"BTquit/x").InnerText);
			y = Convert.ToInt32(xml.SelectSingleNode(layoutIndex[randLayout]+"BTquit/y").InnerText);
			h = Convert.ToInt32(xml.SelectSingleNode(layoutIndex[randLayout]+"BTplay/h").InnerText);
			w = Convert.ToInt32(xml.SelectSingleNode(layoutIndex[randLayout]+"BTplay/w").InnerText);
			txt = xml.SelectSingleNode(layoutIndex[randLayout]+"BTquit/text").InnerText;
			if(button(x,y,h,w,txt)){
				
			}

			if(randLayout == 0){
				GUI.DrawTexture(new Rect(115,35,969,112),title);
				world3D.renderer.enabled = true;
				world3D.transform.position = new Vector2(-4,-2);
				BG.GetComponent<SpriteRenderer>().sprite = BG1;
				char_anim[randLayout].SetActive(true);
				char_anim[randLayout].transform.position = new Vector2(0,-1);
			}
			else if(randLayout == 1){
				GUI.DrawTexture(new Rect(35,35,969,112),title);
				world3D.renderer.enabled = true;
				world3D.transform.position = new Vector2(4,-3);
				BG.GetComponent<SpriteRenderer>().sprite = BG2;
				char_anim[randLayout].SetActive(true);
				char_anim[randLayout].transform.position = new Vector2(2,0);
			}
			else if(randLayout == 2){
				GUI.DrawTexture(new Rect(115,35,969,112),title);
				world3D.renderer.enabled = true;
				world3D.transform.position = new Vector2(0,-1);
				BG.GetComponent<SpriteRenderer>().sprite = BG3;
				char_anim[randLayout].SetActive(true);
				char_anim[randLayout].transform.position = new Vector2(-5,-3);
			}

			break;
		case 2:
			isMindwaveConnected = Mindwave.ConnectionStatus == 0;
			if(isMindwaveConnected){
				GUI.DrawTexture (new Rect(1150,100,connectedMindwave.width,connectedMindwave.height),connectedMindwave);
			}
			else{
				GUI.DrawTexture (new Rect(1150,100,unconnectedMindwave.width,unconnectedMindwave.height),unconnectedMindwave);
			}
			GUIStyle titleGS = new GUIStyle();
			titleGS.font = fontTitle;
			titleGS.fontSize = 45;
			GUI.Label(new Rect(345,40,1000,1000),"MENU DE CONFIGURACAO",titleGS);
			world3D.renderer.enabled = true;
			world3D.transform.position = new Vector2(6,-2);
			GUI.DrawTexture(new Rect(100,325,limiar.width,limiar.height),limiar);
			GUIStyle blankTexture = new GUIStyle();
			blankTexture.normal.background = Texture2D.blackTexture;
			if(GUI.Button(new Rect(75,75,auxSD.width,auxSD.height),auxSD,blankTexture)){
				if(HUD.audioIsActive){
					auxSD = sd;
					HUD.audioIsActive = false;
				}
				else if(!HUD.audioIsActive){
					auxSD = sd1;
					HUD.audioIsActive = true;
				}
			}
			if(GUI.Button(new Rect(525,345,rightArrow.width,rightArrow.height),rightArrow,blankTexture)){

			}
			if(GUI.Button(new Rect(280,345,leftArrow.width,leftArrow.height),leftArrow,blankTexture)){
				
			}


			if(button(305,575,450,75,"RESETAR TOP SCORE")){

			}

			if(button(1175,55,185,55,"VOLTAR")){
				statusInterface = 1;
				int aux = randLayout;
				while (aux == randLayout){
					randLayout = UnityEngine.Random.Range(0,layoutIndex.Length);
				}

			}

			foreach(GameObject item in char_anim){
				item.SetActive(false);
			}
			break;
		case 3:
			if(button(Screen.width/2,Screen.height/2,158,42,"VOLTAR")){
				statusInterface = 1;
				int aux = randLayout;
				while (aux == randLayout){
					randLayout = UnityEngine.Random.Range(0,layoutIndex.Length);
				}
			}
			foreach(GameObject item in char_anim){
				item.SetActive(false);
			}
			break;
		case 5:
			if(button(Screen.width/2,Screen.height/2,158,42,"MENU PRINCIPAL")){
				statusInterface = 1;
				int aux = randLayout;
				while (aux == randLayout){
					randLayout = UnityEngine.Random.Range(0,layoutIndex.Length);
				}
			}
			foreach(GameObject item in char_anim){
				item.SetActive(false);
			}
			break;
		}
	}

	public bool button (int x, int y, int w, int h, string txt){
		return GUI.Button(new Rect(x-w/2,y-h/2,w,h), txt, guiStyle);
	}
}