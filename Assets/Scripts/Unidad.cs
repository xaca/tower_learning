using UnityEngine;
using System.Collections;
using System;

public class Unidad : MonoBehaviour,IControlable {

    [SerializeField]
    private GameObject ruta;
    [SerializeField]
    private float vel;
    [SerializeField]
    private int vidas;
    [SerializeField]
    private int valor_muerte;
    private int indice;
    private Vector2 posicion_inicial;
    private Transform posicion_siguiente;
    private Transform posicion_actual;
    private float distancia_punto;
    private bool esta_viva;
    private float tiempo;
    private float delta_vida;
    private Vector3 posicion_muerte;
    private Animator controlador;
    private LogicaBarra lb;
    private Hud hud;


    // Use this for initialization
    void Start () {
        vel = 1f;
        delta_vida = 1f / vidas;
        distancia_punto = .1f;
        esta_viva = true;
        posicion_inicial = this.transform.position;
        posicion_siguiente = ruta.transform.GetChild(0);
        controlador = this.GetComponent<Animator>();
        lb = this.GetComponent<LogicaBarra>();
        hud = Hud.GetInstance();
    }
	
	// Update is called once per frame
	void Update () {
        
        if(EsActualizable())
        {
            if (esta_viva)
            {                
                    //dir = posicion_siguiente.position - this.transform.position;
                    //dir.z = 0;
                    transform.position = Vector2.MoveTowards(transform.position, posicion_siguiente.position, vel * Time.deltaTime);

                    if (Vector2.Distance(transform.position,posicion_siguiente.position)<distancia_punto)
                    {
                        if (indice + 1 < ruta.transform.childCount)
                        {
                            indice++;
                            posicion_actual = posicion_siguiente;
                            posicion_siguiente = ruta.transform.GetChild(indice);
                            CambiarPosicion();                            
                        }
                        else
                        {
                            indice = 0;
                            transform.position = posicion_inicial;
                            posicion_siguiente = ruta.transform.GetChild(0);
                            posicion_actual = null;                            
                        }                
                    }                                    
            }
            else
            {
                Posicion_muerte = this.transform.position;
                this.transform.position = posicion_inicial;
            }
        }
        
	}

    private void CambiarPosicion()
    {
        int direccion = 1;
        Direccion mira_hacia;

        if (posicion_actual != null)
        {
            mira_hacia = posicion_actual.GetComponent<Direccion>();
            if (mira_hacia.Ubicacion == Direccion.ARRIBA)
            {
                direccion = Direccion.ARRIBA;
            }
            if (mira_hacia.Ubicacion == Direccion.ABAJO)
            {
                direccion = Direccion.ABAJO;
            }
            if (mira_hacia.Ubicacion == Direccion.IZQUIERDA)
            {
                direccion = Direccion.IZQUIERDA;
            }
            if (mira_hacia.Ubicacion == Direccion.DERECHA)
            {
                direccion = Direccion.DERECHA;
            }
            controlador.SetInteger("direccion", direccion);
        }
        
    }

    void OnTriggerEnter2D(Collider2D otro)
    {
        Bala bala;

        if (vidas > 0)
        {
            if (otro.gameObject.tag == "bala")
            {
                //Pendiente poner pooling para las balas
                bala = otro.gameObject.GetComponent<Bala>();
                bala.Disparada = false;

                if(--vidas==0)
                {
                    esta_viva = false;
                    hud.ActualizarMoneda(valor_muerte);
                    hud.DescontarVidas();
                }
                else
                {
                    lb.ModificarBarra(delta_vida);
                }
               
            }
        }
       
    }

    public bool EsActualizable()
    {
        return hud.Modo_ejecucion == Hud.EJECUCION;
    }

    public bool Esta_viva
    {
        get
        {
            return esta_viva;
        }

        set
        {
            esta_viva = value;
        }
    }

    public Vector3 Posicion_muerte
    {
        get
        {
            return posicion_muerte;
        }

        set
        {
            posicion_muerte = value;
        }
    }
}
