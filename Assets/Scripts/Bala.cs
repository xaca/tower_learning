using UnityEngine;
using System.Collections;

public class Bala : MonoBehaviour {

    private GameObject objetivo;
    private float velocidad;
    private Vector3 posicion_muerte_enemigo;
    private bool disparada;

	// Use this for initialization
	void Start () {
        velocidad = 2;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 direccion;
        Unidad unidad;
        
        if(objetivo!=null)
        {
            unidad = objetivo.GetComponent<Unidad>();
            if (unidad.Esta_viva)
            {
                disparada = true;
                direccion = objetivo.transform.position - this.transform.position;
                this.transform.position += velocidad * direccion * Time.deltaTime;
            }
            else
            {
                posicion_muerte_enemigo = unidad.Posicion_muerte;
                objetivo = null;
            }
        }
        else
        {
            //Debug.Log("Sin objetivo "+ posicion_muerte_enemigo+ " "+disparada);
            if (disparada)
            {
                TerminarRecorrido();
            }
           
        }
	}

    public void TerminarRecorrido()
    {
        Vector3 direccion;
        direccion = posicion_muerte_enemigo - this.transform.position;

        if (direccion.magnitude > .05f )
        {
            this.transform.position += velocidad * direccion * Time.deltaTime;
        }
        else
        {
            Destroy(this);
        }
    }

    public void ActivarBala(Torre torre)
    {
        objetivo = torre.Enemigo;
    }
}
