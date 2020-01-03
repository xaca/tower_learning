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
    private uint modo_ejecucion;

    public const uint CONSTRUCCION = 1;
    public const uint EJECUCION = 2;

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

    public uint Modo_ejecucion
    {
        get
        {
            return modo_ejecucion;
        }

        set
        {
            modo_ejecucion = value;
        }
    }

    private void Start()
    {
        modo_ejecucion = CONSTRUCCION;
        Contador_monedas = 1000;
        instancia = this;
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
