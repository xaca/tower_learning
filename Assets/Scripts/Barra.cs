using UnityEngine;
using System.Collections;

public class Barra : MonoBehaviour {
    
    private SpriteRenderer sr;
    public float escala;
    // Use this for initialization
    void Start () {
        sr = this.GetComponent<SpriteRenderer>();
        
    }

    void Update()
    {
        Debug.Log(sr.transform.localScale);
        sr.transform.localScale = new Vector3(.5f, 1);
        Debug.Log(sr.transform.localScale);
    }
}
