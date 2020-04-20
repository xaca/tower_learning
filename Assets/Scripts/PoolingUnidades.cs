using UnityEngine;
using System.Collections;

public class PoolingUnidades : MonoBehaviour {

    public static ArrayList unidades;

	// Use this for initialization
	void Start () {               
        unidades = new ArrayList();
        CrearPoolingUnidades();
        PosicionarUnidades();
    }
	
    public void CrearPoolingUnidades()
    {
        //Este metodo es el que se llamaria en cada nivel, para
        //Crear las unidades necesarias seg�n la dificultad
        for (int i = 0; i < 10; i++)
        {
            CrearUnidad("unidad_01");
            CrearUnidad("unidad_02");
            CrearUnidad("unidad_03");
        }
    }

    public void CrearUnidad(string nombre)
    {
        GameObject temp;
        GameObject unidad = GameObject.Find(nombre);

        temp = (GameObject)Instantiate(unidad, Vector3.zero, Quaternion.identity);
        
        if(!unidades.Contains(unidad))
        {
            unidades.Add(unidad);
        }
        unidades.Add(temp);
    }

    public void PosicionarUnidades()
    {
        Vector3 incremento = new Vector3(1, 0);
        Vector3 posicion_actual = new Vector3(0,4);
        
        foreach (GameObject item in unidades)
        {
            item.transform.position = posicion_actual;
            posicion_actual = posicion_actual + incremento;
        }
    }
	
}
