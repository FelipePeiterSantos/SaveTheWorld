using UnityEngine;
using System.Collections;
using System.Xml;
using System.Collections.Generic;

public class jogo : MonoBehaviour {

	XmlDocument xml = new XmlDocument();

	public GameObject armP;
	//public GameObject charP;
    private Vector3 positionfObjects;

    public List<GameObject> objectsS;

    private GameObject rotater;
    private bool backToPosition = false;
    private bool stopUp = false;
//    private float contador = 0f;

	public static int statusSet = 0;
    private float _plataformScale;
    
	void Start () {
        xml.Load("Assets/Resources/XMLSituations.xml");
		positionObjects ();
        rotater = GameObject.Find("hand 1(Clone)");
      
	}
	
	void Update () {

      //  contador += Time.deltaTime;
       // if (Input.GetKey(KeyCode.Space))//) || (Mindwave.getMeditation()) > 50f || tempoContagem >= 10f)
		if(scriptInput.Meditation() > 80)
        {
            backToPosition = false;
            if (stopUp == false)
            {
                if (rotater.gameObject.transform.localScale.x <= 1f)
                {
                    rotater.gameObject.transform.localScale += new Vector3(Mathf.Clamp(_plataformScale, 0.1f, 0.5f), 0, 0) * Time.deltaTime;
                                      
                }
               else if (rotater.gameObject.transform.localScale.x >= 1f)
                {
                    stopUp = false;
                }
            }
        }

        
		else if (scriptInput.Meditation() < 50 && rotater.gameObject.transform.localScale.x >= 0.2f)//(Input.GetKeyUp(KeyCode.Space))//) || (Mindwave.getMeditation()) > 50f || tempoContagem >= 10f)
        {
           backToPosition = true;
           
        }

        if (backToPosition)
        {
            rotater.gameObject.transform.localScale -= new Vector3(Mathf.Clamp(_plataformScale, 1f, 5f), 0, 0) * Time.deltaTime;

            if (rotater.gameObject.transform.localScale.x <= 0.2f)
            {
				backToPosition = false;
            }
        }
       /* if (contador >= 10f)
        {
            Debug.Log("Ganhou");
            contador = 0;
        }*/
	}

	void positionObjects(){
		
        switch (statusSet) {
        case 0:

           // GameObject aux =  Instantiate(charP, new Vector3(XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION2/char/x").InnerText), XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION2/char/y").InnerText), 0), Quaternion.identity) as GameObject;
			//aux.transform.parent = this.transform;
			GameObject aux = Instantiate(armP, new Vector3(XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION2/arm/x").InnerText), XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION2/arm/y").InnerText), 0), Quaternion.identity) as GameObject;
			aux.transform.parent = this.transform;
            GameObject teste =  objectsS[Random.Range(0, objectsS.Count)];
			aux = Instantiate(teste, new Vector3(XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION2/objects/x").InnerText), XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION2/objects/y").InnerText), 0), Quaternion.identity) as GameObject;
			aux.transform.parent = this.transform;
        break;

        }
	}
}
