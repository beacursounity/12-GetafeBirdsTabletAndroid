using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntuacionScript : MonoBehaviour {
    public int timeToDestroy = 5;

    private void Start() {
        Invoke("AutoDestroy", timeToDestroy);
        // TAMBIEN SE PUEDE USAR EL DESTROY DIRECTAMENTE SIN NECESIDAD DE TENER UN METODO
        // Destroy(this.gameObject,timetoDestroy);
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(Vector2.up * Time.deltaTime);
    
	}

    private void AutoDestroy() {
        Destroy(this.gameObject);
    }
}
