using UnityEngine;
using System.Collections;
using System.Xml;
using System.Collections.Generic;

public class gameplay : MonoBehaviour {

    XmlDocument xml = new XmlDocument();

    public GameObject fogo;
    public GameObject glow;
    GameObject Glowing;
    public GameObject tableP;
    public List<GameObject> objectsS;
    public GameObject fireP;

    GameObject[] itensEscolha = new GameObject[3];
    Vector3 pos1;
    Vector3 pos2;
    Vector3 pos3;

    private float contador = 0f;
    private bool podeInstanciar = true;

    private bool select01 = false;
    private bool select02 = false;
    private bool select03 = false;

    //gambi
    private float timer = 5f;
    private bool podeRodar;

	void Start () {
		xml.Load("Assets/Resources/xmlSituations.xml");
        positionObjects();

        //anim = GetComponent<Animator>();

		pos1 = new Vector3(XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION6/situation6/object1/x").InnerText), XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION6/situation6/object1/y").InnerText), 0);
		pos2 = new Vector3(XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION6/situation6/object2/x").InnerText), XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION6/situation6/object2/y").InnerText), 0);
		pos3 = new Vector3(XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION6/situation6/object3/x").InnerText), XmlConvert.ToSingle(xml.SelectSingleNode("XMLSituations/SITUATION6/situation6/object3/y").InnerText), 0);

        itensEscolha[0] = objectsS[Random.Range(0, objectsS.Count)];
        itensEscolha[1] = objectsS[Random.Range(0, objectsS.Count)];
        itensEscolha[2] = objectsS[Random.Range(0, objectsS.Count)];
        while (itensEscolha[1] == itensEscolha[0])
        {
            itensEscolha[1] = objectsS[Random.Range(0, objectsS.Count)];
        }
        while (itensEscolha[2] == itensEscolha[0] || itensEscolha[2] == itensEscolha[1])
        {
            itensEscolha[2] = objectsS[Random.Range(0, objectsS.Count)];
        }

        Instantiate(itensEscolha[0], pos1, Quaternion.identity);
        Instantiate(itensEscolha[1], pos2, Quaternion.identity);
        Instantiate(itensEscolha[2], pos3, Quaternion.identity);
        Glowing = Instantiate(glow, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
	}
	
	void Update () {
        contador += Time.deltaTime;
        
        Debug.Log(contador);
        
        if (contador >= 15)
        {
            contador = 0;
        }
        if (contador <= 5f)
        {
            Glowing.transform.position = pos1;
        }
        if (contador > 5f && contador <= 10f)
        {
            Glowing.transform.position = pos2;
        }
        if (contador > 10f && contador <= 15f)
	    {
            Glowing.transform.position = pos3;
	    }

        if (Input.GetKeyDown(KeyCode.Space) && contador <= 5f)//) || (Mindwave.getMeditation()) > 50f || tempoContagem >= 10f)
        {
            select01 = true;
            select02 = false;
            select03 = false;
           
              //  if (itensEscolha[0].tag == "objeto01")
                
            Debug.Log("um");
         } 
        if (Input.GetKeyDown(KeyCode.Space) && contador > 5f && contador <= 10f)//) || (Mindwave.getMeditation()) > 50f || tempoContagem >= 10f)
        {
            select01 = false;
            select02 = true;
            select03 = false;
  
            Debug.Log("dois");
        }
        if (Input.GetKeyDown(KeyCode.Space) && contador > 10f && contador <= 15f)//) || (Mindwave.getMeditation()) > 50f || tempoContagem >= 10f)
        {
            select01 = false;
            select02 = false;
            select03 = true;
           
            Debug.Log("tres");
       
       }
       
        if (select01)
        {
            if (itensEscolha[0].tag == "objeto01")
            {
                Debug.Log("certo");
                //anim.SetBool("apagou", true);
                fogo.GetComponent<Animator>().SetTrigger("AtivaFogo");
                select01 = false;
            }
            else
                Debug.Log("errou");
        }
        if (select02)
        {
            if (itensEscolha[1].tag == "objeto01")
            {
                Debug.Log("certo");
                fogo.GetComponent<Animator>().SetTrigger("AtivaFogo");
                select02 = false;
            }
            else
                Debug.Log("errou");
        }
        if (select03)
        {
            if (itensEscolha[2].tag == "objeto01")
            {
                Debug.Log("certo");
                fogo.GetComponent<Animator>().SetTrigger("AtivaFogo");
                select03 = false;
            }
            else
                Debug.Log("errou");
        }
        
             
	}
    void positionObjects()
    {
        int x;
        int y;

     //   x = XmlConvert.ToInt32(xml.SelectSingleNode("situation6/fire/x").InnerText);
    //    y = XmlConvert.ToInt32(xml.SelectSingleNode("situation6/fire/y").InnerText);
     //   Instantiate(fireP, new Vector3(x, y, 0), Quaternion.identity);
        

		x = XmlConvert.ToInt32(xml.SelectSingleNode("XMLSituations/SITUATION6/situation6/table/x").InnerText);
		y = XmlConvert.ToInt32(xml.SelectSingleNode("XMLSituations/SITUATION6/situation6/table/y").InnerText);
       Instantiate(tableP, new Vector3(x, y, 0), Quaternion.identity);

      // GameObject teste = objectsS[Random.Range(0, objectsS.Count)];
        //  Instantiate(teste, new Vector3(XmlConvert.ToInt32(xml.SelectSingleNode("situation6/fire/x").InnerText), XmlConvert.ToInt32(xml.SelectSingleNode("situation6/fire/y").InnerText), 0), Quaternion.identity);
      }
}
