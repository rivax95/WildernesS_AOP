using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemigos2 : MonoBehaviour {
   public AudioClip recibedaño;
   public AudioClip hacedaño;
    public AudioClip muere;
    public int vidas = 1;
    GameObject player;
    bool derecha;
    public float rango = 0.5f;
	public float rangoDistancia = 5;
    public LayerMask raycastdetected; // NOTE CONFIGURAR EN UNITY
    RaycastHit2D detectde;
    RaycastHit2D detectiz;
    Vector2 objetibo;
    public float distancia_ataque=0.5f;
    public int dano = 1;
    public bool quieto = false;
    public float culdown = 0.5f;
    public float VelMov = 1.5f;
   public MovimientoEnemigo mov;
    bool golpea = false;
    Vector2 quietov2;
    AudioSource aud;

	/// <summary>
	/// <para>Comprueba si se a detectado algun enemigo</para>
	/// </summary>
	private bool tempDetect = false;													// Comprueba si se a detectado algun enemigo

	void Start () {
        player = GameObject.FindWithTag("Player");
        mov = this.gameObject.GetComponent<MovimientoEnemigo>(); // NOTE puede que no lo detecte si no lo tiene el script por lo que tengo que si el enemigo es estatico va a tirar error Null referent....
        aud = this.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
	{
		muerte();

		detectiz = Physics2D.Raycast(transform.position, transform.right * -1, rango, raycastdetected);
		detectde = Physics2D.Raycast(transform.position, transform.right * 1, rango, raycastdetected);
		Debug.DrawRay(transform.position, transform.right * (-1) * rango, Color.white, 0);
		Debug.DrawRay(transform.position, transform.right * (1) * rango, Color.white, 0);

		quietov2 = transform.position;

		// Detectamos si tenemos objetivo
		if (detectde != false)
		{
			// Si encontramos al enemigo dentro del rango, perseguimos
			if (detectde.collider.transform.position.x <= detectde.collider.transform.position.x + rango || detectde.collider.transform.position.x >= detectde.collider.transform.position.x - rango)
			{
				perseguir();
			}
			else
			{
				mov.Persigue = false;
			}
		}
		else
		{
			mov.Persigue = false;
		}



			//objetibo = player.gameObject.transform.position;

	}

    public void perseguir()
    { // NOTE mirar bien el script de movimiento que no interrumpa a este ni viceversa. *Mirado y corregio a falta de testearlo|26/03/2017 12:00|
        Debug.Log(detectde.collider.tag + " collision");
        if (detectde.collider.transform.position.x <= detectde.collider.transform.position.x + rango || detectde.collider.transform.position.x >= detectde.collider.transform.position.x - rango)
        {
            golpea = true;
            mov.Persigue = true;
            Debug.Log("Enemigo detecta a Player");
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            transform.position += new Vector3(+1f, 0f, 0f) * VelMov * Time.deltaTime;
            Debug.Log(detectde.distance + " Distancia del enemigo al personaje");
            if (detectde.distance < distancia_ataque) // ya tira
            {
                quieto = true;
                if (quieto == true)
                {
                    transform.position = quietov2;
                }
                Debug.Log("Enemigo ataca");
                //TODO ejecuta animacion

                if (!IsInvoking("ferCooldown")) // NOTE MIRAR Repasado con fernando 27/03/2017
                {
                    aud.PlayOneShot(hacedaño, 1f);
                    //aud.Play(1);
                    player.GetComponent<PlayerData>().vidas -= dano;
                    Invoke("ferCooldown", 2.0f);
                }
            }
            else 
            {
                quieto = false; 
            }
        }
        else
        {
			Debug.LogWarning("No persigue a nadie");
            mov.Persigue = false; //NOTE Mirar por que no funciona
        }
    }
    public void actualizarestado()
    {

        if (player.transform.position.x > this.gameObject.transform.position.x)
        {
            derecha =true;
        }
        else
        {
            derecha = false;
        }
    }
    public void muerte()
    {
        if (vidas == 0)
        {
            // TODO AUDIO
            //TODO ANIMACION
            Destroy(this.gameObject);
        }
    }
    public void sonidos()
    {
        switch (vidas) // NOTE cuando le resten una vida plantear el problema PRIMERO
        {
            case 1:
                bool au1 = true;
                if (au1 == true)
                aud.PlayOneShot(recibedaño, 1f);
                au1 = false;
                break;
            case 2:
                bool au2 = true;
                if (au2 == true)
                    aud.PlayOneShot(recibedaño, 1f);
                au2 = false;
                break;
        }
    }
    void ferCooldown()
    {
        return;
    }
   
}
