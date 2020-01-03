using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControlEjecucion : MonoBehaviour,IPointerClickHandler {

    private bool habiltado;

    public void OnPointerClick(PointerEventData eventData)
    {
        Hud hud;
        hud = Hud.GetInstance();
        if(habiltado)
        {
            hud.Modo_ejecucion = Hud.EJECUCION;
            habiltado = false;
        }
    }

    // Use this for initialization
    void Start () {
        
        habiltado = true;
	}
	
}
