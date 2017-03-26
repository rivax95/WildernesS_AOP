using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos2 : MonoBehaviour {

    GameObject player;
    bool derecha;
    public float rango = 4f;
    LayerMask raycastdetected; // NOTE CONFIGURAR EN UNITY
    RaycastHit2D detectde;
    RaycastHit2D detectiz;
    Vector2 objetibo;
    public float distancia_ataque=0.5f;
    public int dano = 1;
    public float VelMov = 0.5f;
    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
         detectiz = Physics2D.Raycast(transform.position, transform.right * (-1),rango,raycastdetected);
         detectde = Physics2D.Raycast(transform.position, transform.right * (1), rango, raycastdetected);
        objetibo = player.gameObject.transform.position;
        perseguir();
    }
    public void perseguir()
    { // NOTE mirar bien el script de movimiento que no interrumpa a este ni viceversa.
        if (detectde.collider.tag == "Player")
        {
            Debug.Log("Enemigo detecta a Player");
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            transform.position += new Vector3(+1f, 0f, 0f) * VelMov * Time.deltaTime;
            if (detectde.distance == distancia_ataque)
            {
                //NOTE Cuando se hacerque se tiene que quedar parado
                transform.position = transform.position;
                //NOTE Primero un culdown y al termianr el ataque otro
                Debug.Log("Enemigo se dispone a atacar");
                //TODO ejecuta animacion
                //TODO CULDOWN ATAQUE
                player.GetComponent<PlayerData>().vidas -= dano;
            }
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
}
