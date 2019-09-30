using UnityEngine;
using System.Collections;

public class LogicaBarra : MonoBehaviour {
    public GameObject heroe;
    public GameObject barra_verde;
    public GameObject barra_roja;
    //private float escala_actual;// = .001f
    private SpriteRenderer sr;

    // Use this for initialization
    void Start () {
        
        sr = barra_verde.GetComponent<SpriteRenderer>();
    }

	public void ModificarBarra(float escala)
    {
        if (sr.transform.localScale.x > 0)
        {
            sr.transform.localScale -= new Vector3(escala, 0);
            barra_verde.transform.position = heroe.transform.position - new Vector3(.3f - sr.bounds.size.x / 2, -.4f);
            barra_roja.transform.position = heroe.transform.position - new Vector3(.05f, -.4f);
        }
        else
        {
            //Disparar evento de muerte
        }
    }
	// Update is called once per frame
	void Update () {
            
    }
}
