using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour {

    [SerializeField]
    private Text monedas;
    private static int contador_monedas;

    public static void ActualizarMoneda(int valor)
    {
        contador_monedas += valor;
    }

	// Update is called once per frame
	void Update () {
        monedas.text = contador_monedas.ToString();
	}
}
