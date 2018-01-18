using UnityEngine;
using System.Collections;

public class Situation09 : MonoBehaviour {
   
    public Sprite SpriteSecador;
    public Sprite SpritePia;
    public Sprite SpriteChuveiro;
    public Sprite SpriteSanitario;
    public Sprite SpriteLampada;

    public float timerContador;

    public GameObject posicaoGlow;
    private Vector3 position;

    private SpriteRenderer sr;

    public static bool chuveiro = false;
    public static bool sanitario = false;
    public static bool pia = false;
    public static bool secador = false;
    public static bool lampada = false;
    

    public static bool[] myArray = new bool[5];
	void Start () {

        sr = GetComponent<SpriteRenderer>();
        chuveiro = myArray[0];
        sanitario = myArray[1];
        pia = myArray[2];
        secador = myArray[3];
        lampada = myArray[4];
        int rnd;
        rnd = Random.Range(0,myArray.Length);
        myArray[rnd] = true;
	}
	
	void Update () {
        
        timerContador += Time.deltaTime;

        if (timerContador <= 5f)
        {
            //secador
            sr.sprite = SpriteSecador;
            posicaoGlow.transform.position = new Vector3(5.87f, -2.4f, 0);

            if (Input.GetKeyDown(KeyCode.A))
            {
                if (secador)
                {
                    Debug.Log("acertou");
                }
                else if (!secador)
                {
                    Debug.Log("perdeu");
                }
            }
            
        }
        if (timerContador >= 5f && timerContador <= 10f)
        {
            //pia
            sr.sprite = SpritePia;
            posicaoGlow.transform.position = new Vector3(-3.51f, -1.27f, 0);

            if (Input.GetKeyDown(KeyCode.A))
            {
                if (pia)
                {
                    Debug.Log("acertou");
                }
                else if (!pia)
                {
                    Debug.Log("perdeu");
                }
            }
            
        }
        if (timerContador >= 10f && timerContador <= 15f)
        {
            //chuveiro
            sr.sprite = SpriteChuveiro;
            posicaoGlow.transform.position = new Vector3(-5.76f, 0.65f, 0);

            if (Input.GetKeyDown(KeyCode.A))
            {
                if (chuveiro)
                {
                    Debug.Log("acertou");
                }
                else if (!chuveiro)
                {
                    Debug.Log("perdeu");
                }
            }
        }
        if (timerContador >= 20f && timerContador <= 25f)
        {
            //sanitario
            sr.sprite = SpriteSanitario;
            posicaoGlow.transform.position = new Vector3(-5.71f, -2.69f, 0);

            if (Input.GetKeyDown(KeyCode.A))
            {
                if (sanitario)
                {
                    Debug.Log("acertou");
                }
                else if (!sanitario)
                {
                    Debug.Log("perdeu");
                }
            }
        }
        if (timerContador >= 25f && timerContador <= 30f)
        {
            sr.sprite = SpriteLampada;
            posicaoGlow.transform.position = new Vector3(0.5310789f, 4.356742f, 0);

            if (Input.GetKeyDown(KeyCode.A))
            {
                if (lampada)
                {
                    Debug.Log("acertou");
                }
                else if (!lampada)
                {
                    Debug.Log("perdeu");
                }
            }
        }
        if (timerContador >= 30)
        {
            timerContador = 0;
        }
	}
}
