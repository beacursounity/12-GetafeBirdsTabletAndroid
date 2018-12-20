using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaScript : MonoBehaviour {

    [SerializeField] GameObject prefabCien;
    private bool estaIntacta = true;

    private void OnCollisionEnter2D(Collision2D collision) {
        // PARA SI ESTA INTACTA LA CAJA QUE COLISIONE Y SALGA EL 100 
        // PERO NO LO VAMOS HACER
        if (estaIntacta && collision.gameObject.name == "Pajarraco") {
            Instantiate(prefabCien, this.transform.position,Quaternion.identity);
        }
    }
}
