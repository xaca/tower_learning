using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlesTorre : MonoBehaviour {

    [SerializeField]
    private GameObject btn_actualizar;
    [SerializeField]
    private GameObject btn_vender;

	// Use this for initialization
	void Start () {
        CambiarEstadoBotones(false);
	}

    private void OnMouseDown()
    {
        CambiarEstadoBotones(true);
    }

    public void CambiarEstadoBotones (bool estado) {
        btn_actualizar.SetActive(estado);
        btn_vender.SetActive(estado);
	}
}
