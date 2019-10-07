using UnityEngine;
using System.Collections;

public class PoolingUnidades : MonoBehaviour {

    public static ArrayList unidades;

	// Use this for initialization
	void Start () {
        GameObject unidad = GameObject.Find("unidad_01");
        GameObject unidad2 = GameObject.Find("unidad_02");
        GameObject temp;
        Vector3 incremento = new Vector3(0, 1);
        Vector3 posicion_actual = unidad.transform.position;
        unidades = new ArrayList();
        unidades.Add(unidad);
        unidades.Add(unidad2);

        for (int i = 0; i < 10; i++)
        {
            temp = (GameObject)Instantiate(unidad, posicion_actual + incremento, Quaternion.identity);
            posicion_actual = temp.transform.position;
            unidades.Add(temp);

            temp = (GameObject)Instantiate(unidad2, posicion_actual + incremento, Quaternion.identity);
            posicion_actual = temp.transform.position;
            unidades.Add(temp);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
