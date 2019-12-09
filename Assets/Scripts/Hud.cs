using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour {

    private static Hud instancia;

    [SerializeField]
    private Text monedas;
    private int contador_monedas;
    private bool modo_construccion;

    public const int ID_TORRE = 1;
    public const int ID_UNIDAD = 2;
    
    public static Hud GetInstance()
    {

        return instancia;
    }

    public int Contador_monedas
    {
        get
        {
            return contador_monedas;
        }

        set
        {
            contador_monedas = value;
        }
    }

    private void Start()
    {
        modo_construccion = true;
        Contador_monedas = 1000;
        instancia = this;
    }

    public bool EstadoActual(int identificador)
    {
        if(identificador == ID_TORRE)
        {
            return !modo_construccion;
        }

        if(identificador == ID_UNIDAD)
        {
            return !modo_construccion;
        }

        return false;
    }

    public void CambiarModoConstruccion(bool valor)
    {
        modo_construccion = valor;
    }

    public void ActualizarMoneda(int valor)
    {
        Contador_monedas += valor;
    }

	// Update is called once per frame
	void Update () {
        monedas.text = Contador_monedas.ToString();
	}

    public void DescontarSaldo(int valor)
    {
        contador_monedas -= valor;
        StartCoroutine("CambiarColorSaldo", Color.black);
    }

    public void ErrorSaldoInsuficiente()
    {
        StartCoroutine("CambiarColorSaldo", Color.red);
    }

    public IEnumerator CambiarColorSaldo(Color color)
    {
        monedas.color = color;
        yield return new WaitForSeconds(.5f);
        RestearCampoTexto();
    }

    private void RestearCampoTexto()
    {
        monedas.color = Color.white;
    }
}
