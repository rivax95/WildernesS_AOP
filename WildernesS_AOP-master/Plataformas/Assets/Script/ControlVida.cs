using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControlVida : MonoBehaviour {

    public PlayerData miJugador;

    public float vidaMaxima;
    public float vidaGUI;

    public Image barraVida;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        vidaGUI = miJugador.vidas / vidaMaxima;

        barraVida.fillAmount = vidaGUI;
    }
}
