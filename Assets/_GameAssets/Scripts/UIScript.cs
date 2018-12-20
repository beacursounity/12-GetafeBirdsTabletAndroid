using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript: MonoBehaviour {
    float maxX, maxY, maxZ;

    public Text txtAceleracion;

    private void Update() {
        // COGEMOS LA ACELERACION EN CADA UNO DE LOS EJES
        float x = Input.acceleration.x;
        float y = Input.acceleration.y;
        float z = Input.acceleration.z;

        // Y QUE ME COJA SIEMPRE EL MAXIMO CONSEGUIDA EN LA ACELERACION
        maxX = Mathf.Max(maxX, x);
        maxY = Mathf.Max(maxY, y);
        maxZ = Mathf.Max(maxZ, z);


        txtAceleracion.text = maxX + ":" + maxY + ":" + maxZ;
    }

    // PARA RECARGAR DE NUEVO LA PRIMERA ESCENA
    public void RecargarPantalla () {
        SceneManager.LoadScene(0);
	}
	
}
