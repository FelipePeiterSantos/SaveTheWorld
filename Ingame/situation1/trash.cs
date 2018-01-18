using UnityEngine;
using System.Collections;
using System.Xml;

public class trash : MonoBehaviour {

	public int _1 = 1;
	public int _2 = 1;

	public string trashType;
	public GUIStyle guiStyle;

	XmlDocument xmlSituation = new XmlDocument();
	int _xLabel;
	int _yLabel;

	void Start(){
		xmlSituation.Load ("Assets/Resources/xmlSituations.xml");
	}

	void OnGUI(){
		Vector3 posTxt = Camera.main.WorldToScreenPoint (transform.position);
		GUI.Box (new Rect (posTxt.x-60,Screen.height - posTxt.y,120,26),xmlSituation.SelectSingleNode ("XMLSituations/SITUATION1/trashLabels/"+trashType).InnerText,guiStyle);
	}

	public void selectTrash(GameObject aux){
		if (aux.gameObject.name == this.gameObject.name) {
		}
	}
}
