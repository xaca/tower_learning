using UnityEngine;
using System.Collections;

public class LogicaPonerTorre : MonoBehaviour {

    public GameObject torre;

	void OnMouseDown()
    {
        GameObject temp;
        Vector3 pos = this.transform.position;
        pos.y = pos.y + .4f;
        temp = (GameObject)Instantiate(torre,pos,Quaternion.identity);
        temp.transform.position = pos;
        temp.layer = 7;
        temp.GetComponent<Torre>().Esta_activa = true;
        Destroy(this.gameObject);
    }
}
