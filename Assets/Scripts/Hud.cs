using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour {

    [SerializeField]
    private Text monedas;
    private static int contador_monedas;
    private static bool modo_construccion = true;

    public const int ID_TORRE = 1;
    public const int ID_UNIDAD = 2;


    public static bool EstadoActual(int identificador)
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

    public static void ActualizarMoneda(int valor)
    {
        contador_monedas += valor;
    }

	// Update is called once per frame
	void Update () {
        monedas.text = contador_monedas.ToString();
	}
}
