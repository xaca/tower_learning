using UnityEngine;
using System.Collections;
using System;

public class Bala : MonoBehaviour {

    public const float TIEMPO_DISPARO = .5f;
    private GameObject objetivo;
    private float velocidad;
    private bool disparada;
    //Punto inicial de la bala, donde arranca y donde vuelve cuando se recicla
    private Vector3 punto_inicial;

    private float tiempo;

    private SpriteRenderer sr;

    // Use this for initialization
    void Start () {
        velocidad = 7;
        sr = this.GetComponent<SpriteRenderer>();
        punto_inicial = new Vector3(-5, 4);
        CambiarOpacidad(0f);
    }
	
	// Update is called once per frame
	void Update () {
                
        if(objetivo!=null)
        {
            if(TiempoVida())
            {
                MoverBalaAUnPunto();
            }
            else
            {
                ReciclarBala();
            }
        }

        if (!disparada) {
            ReciclarBala();
        }
	}

    private bool TiempoVida()
    {
        tiempo += Time.deltaTime;
        return tiempo < TIEMPO_DISPARO;
    }

    private void MoverBalaAUnPunto()
    {
        Vector3 direccion;
        Unidad unidad = objetivo.GetComponent<Unidad>();

        if (unidad.Esta_viva)
        {            
            Disparada = true;
            direccion = objetivo.transform.position - this.transform.position;
            this.transform.position += velocidad * direccion * Time.deltaTime;
            
        }        
    }    

    private void CambiarOpacidad(float valor)
    {
        sr.color = new Color(1f, 1f, 1f, valor);
    }

    private void ReciclarBala()
    {
        this.transform.position = punto_inicial;
        objetivo = null;
        Disparada = false;
        CambiarOpacidad(0f);
        tiempo = 0;
    }

    public void ActivarBala(Torre torre)
    {
        Disparada = true;
        objetivo = torre.Enemigo;
        tiempo = 0;
        punto_inicial = torre.transform.position;
        transform.position = punto_inicial;
        CambiarOpacidad(1f);
    }

    public bool Disparada
    {
        get
        {
            return disparada;
        }

        set
        {
            disparada = value;
        }
    }
}
