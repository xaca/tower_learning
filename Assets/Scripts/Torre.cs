﻿using UnityEngine;
using System.Collections;

public class Torre : MonoBehaviour {

    private GameObject enemigo;
    private bool esta_activa;
    private float distancia_umbral;
    private float tiempo_disparo;

    // Use this for initialization
    void Start () {
        distancia_umbral = 1.5f;
        tiempo_disparo = .8f;
}
	
	// Update is called once per frame
	void Update () {
        Enemigo = BuscarEnemigoCercano();
        if(Enemigo!=null && tiempo_disparo <= 0)
        {
            Disparar();
            Debug.DrawLine(this.transform.position, enemigo.transform.position, Color.yellow);
            tiempo_disparo = 2f;
        }
        else
        {
            tiempo_disparo -= .1f;
        }
	}

    void Disparar()
    {
        GameObject obj = (GameObject)Instantiate(GameObject.Find("bala"), this.transform.position, Quaternion.identity);
        Bala bala = obj.GetComponent<Bala>();
        bala.ActivarBala(this);
    }

    GameObject BuscarEnemigoCercano()
    {
        ArrayList enemigos = PoolingUnidades.unidades;
        GameObject temp;
        foreach (Object item in enemigos)
        {
            temp = (GameObject)item;
            if(Vector3.Distance(temp.transform.position,this.transform.position)<distancia_umbral)
            {
                if (temp.GetComponent<Unidad>().Esta_viva)
                {
                    return temp;
                }
            }
        }
        return null;
    }

    public bool Esta_activa
    {
        get
        {
            return esta_activa;
        }

        set
        {
            esta_activa = value;
        }
    }

    public GameObject Enemigo
    {
        get
        {
            return enemigo;
        }

        set
        {
            enemigo = value;
        }
    }
}
