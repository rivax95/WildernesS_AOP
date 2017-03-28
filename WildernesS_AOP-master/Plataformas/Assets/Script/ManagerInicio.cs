using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ManagerInicio : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            Carga();
        }
	}
    public void Carga()
    {// se puede cargar por id por ruta o por nombre
        SceneManager.LoadScene("plataformaspruebas", LoadSceneMode.Single);
    }
}
