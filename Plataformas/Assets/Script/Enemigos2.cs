using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos2 : MonoBehaviour {

    GameObject player;
    bool derecha;
    public float rango = 4f;
    LayerMask raycastdetected;
    RaycastHit2D detectde;
    RaycastHit2D detectiz;
    Vector2 objetibo;
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
    }
    public void perseguir()
    {
        if (detectde.collider.tag == "Player")
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            transform.position += new Vector3(+1f, 0f, 0f) * VelMov * Time.deltaTime;
            if (detectde.distance == 1)
            {

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
