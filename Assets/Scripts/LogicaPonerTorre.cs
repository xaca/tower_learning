using UnityEngine;
using System.Collections;

public class LogicaPonerTorre : MonoBehaviour {

    [SerializeField]
    private GameObject go_torre;
    private Torre torre;
    private Hud hud;

	void OnMouseDown()
    {
        GameObject temp;
        Vector3 pos = this.transform.position;
        pos.y = pos.y + .4f;
        temp = (GameObject)Instantiate(go_torre,pos,Quaternion.identity);
        temp.transform.position = pos;
        temp.layer = 7;
        torre = temp.GetComponent<Torre>();
        hud = Hud.GetInstance();

        if(torre.Valor_nivel_actual <= hud.Contador_monedas)
        {
            torre.Esta_activa = true;
            Destroy(this.gameObject);
            hud.DescontarSaldo(torre.Valor_nivel_actual);
        }
        else
        {
            Destroy(temp);
            hud.ErrorSaldoInsuficiente();
        }
        
    }
}
