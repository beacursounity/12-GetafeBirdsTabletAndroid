using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PajaroScript : MonoBehaviour {
    //Touch t; // PARA UN SOLO DEDO
    Touch[] pulsaciones;
    Touch pulsacion;
    Vector2 posicionInicial;
    Vector2 posicionFinal;
    //[SerializeField] int force = 300;

    int fuerzaMaxima = 500; 

    // PARA SABER SI TENEMOS EL PAJARO PULSADO
    bool pajaroPulsado = false;    

    void Update () {
        /*  // PULSACION CON EL PRIMER DEDO
          Touch t = Input.GetTouch(0);
          print("ID; " + t.fingerId); // ES UN IDENTIFICADOR Y ES CONSTANTE MIENTRAS PULSO LA PANTALLA

          // POSICION DEL PUNTERO EN LA PANTALLA
          Vector2 position = t.position; 

          if (t.phase == TouchPhase.Began) {
              print("He empezado a pulsar");
          }
          else if (t.phase == TouchPhase.Ended ){
              print("He finalizado");
          }*/

        // VAMOS A EMPEZAR A VER SI HAY PULSACIONES
        pulsaciones = Input.touches;
        // SI HEMOS PULSADO CON MAS DE UN DEDO NO SALIMOS
        if (pulsaciones.Length != 1) {
            return;
        }

        // RECOJO LA PRIMERA PULSACION
        pulsacion = pulsaciones[0];
        
        // EVALUAR LAS PULSACIONES 
        // TAMBIEN SE PUEDE HACER CON UN IF
        // EL BREAK ES PARA QUE SE CORTE EL SWITCH Y NO SIGA HACIA ABAJO
        switch (pulsacion.phase) {
            case (TouchPhase.Began): // CUANDO EMPIEZA A PULSAR
                ComenzarToque();
                break; // CORTA Y NO SIGUE
            case (TouchPhase.Moved): // SI SE ESTA MOVIENDO EL DEDO
                MoverToque();
                break;
            case (TouchPhase.Ended): // FINALIZACION
                FinalizarToque();
                break;
            case (TouchPhase.Canceled): // TE HAS SALIDO DE LA PANTALLA , HAS ABORTADO 
                //CancelarToque();
                break;
            case (TouchPhase.Stationary): // DEDO QUIETO PODEMOS HACER QUE EL PAJARO SE TIRE UN PEDO AL CABO DE UN TIEMPO O 
                //PausaToque(); // VOY A CONTAR EL TIEMPO MIENTRAS ESTA QUIETO PUEDO HACER UN PUNTO MAS GORDO......
                break;

            default: // ESTO NO HARIA FALTA PORQUE YA NO HAY MAS ESTADOS
                //EjecutarAccionPorDefecto(); NO LO VAMOS HACER
                break;

        }
    }

    void ComenzarToque() {
        //transform.position = pulsacion.position; // se nos ha ido el pajaro
        // El 0,0 de l bakground esta el pivote
        //print("position pajaro: " + transform.position); // el pajaro nos da en metros
        // Nos da en pixeles las pulsaciones
        //print("position pulsacion: " + pulsacion.position);

        // SI NO ESTAS PULSANDO AL PAJARO SE SALE
        // LA DEJAMOS PENDIENTE NO FUNCIONA BIEN
        /*if (!ComprobarPulsacionObjetoByName(pulsacion, "Pajarraco")) {
            print("NO PAJARO PULSADO");
            // SI NO ESTA PULSANDO EL PAJARO SE SALE
            return;
        }*/

        print("PAJARO PULSADO");

        // MARCO AL PAJARO COMO PULSADO
        pajaroPulsado = true;
        // OBTENEMOS EL VECTOR DE POSICION EN EL MUNDO DEL JUEGO
        Vector2 posicionConvertida = getWorldPosition(pulsacion); // LE PASAMOS SOLO LA PULSACION

        // ASIGNAMOS LA NUEVA POSICION DEL PAJARO
        transform.position = posicionConvertida;

        // RECOGEMOS LA POSICION INICIAL PORQUE VAMOS A LANZARLO
        posicionInicial = posicionConvertida;

    }

    void MoverToque() {
        // SE VA A IMPULSAR SI EL PAJARO ESTA PULSADO
        if (pajaroPulsado) {
            // OBTENEMOS EL VECTOR DE POSICION EN EL MUNDO DEL JUEGO
            Vector2 posicionConvertida = getWorldPosition(pulsacion); // LE PASAMOS SOLO LA PULSACION

            // ASIGNAMOS LA NUEVA POSICION DEL PAJARO
            transform.position = posicionConvertida;
        }
    }
    
    void FinalizarToque() { // CUANDO LEVANTO EL DEDO
         // ASIGNAMOS LA NUEVA POSICION DEL PAJARO
         //transform.position = posicionConvertida; // esta linea sobraria porque el pajaro ya esta ahi

         // OBTENEMOS EL VECTOR DE POSICION EN EL MUNDO DEL JUEGO
         // RECOGEMOS LA POSICION FINAL PORQUE VAMOS A LANZARLO
         posicionFinal = getWorldPosition(pulsacion); // LE PASAMOS SOLO LA PULSACION
         /*/ CALCULAMOS DIRECCION
             Vector2 direccion = (posicionInicial - posicionFinal).normalized;
            // PONEMOS EL RIGIDBODY EN MODO KINEMATIC
            GetComponent<Rigidbody2D>().isKinematic = false;

            // LE DAMOS UN EMPUJON
            //GetComponent<Rigidbody2D>().AddRelativeForce(direccion * force);
            */

         // CALCULAMOS DIRECCION
         // CALCULAMOS EL VECTOR ENTRE LA POSICION INICIAL(CUANDO PULSO LA PRIMERA VEZ Y CUANDO LO SUELTO EL DEDO)
         Vector2 vectorDistancia = (posicionInicial - posicionFinal);
         Vector2 vectorDireccion = vectorDistancia.normalized; // HACIA DONDE TIENE QUE IR
         float distancia = vectorDistancia.magnitude;

         // PONEMOS EL RIGIDBODY EN MODO KINEMATIC
         GetComponent<Rigidbody2D>().isKinematic = false;
         // LE DAMOS UN EMPUJON
         GetComponent<Rigidbody2D>().AddRelativeForce(vectorDireccion * distancia *  fuerzaMaxima);


    }


    private Vector2 getWorldPosition(Touch _t) {
        return Camera.main.ScreenToWorldPoint(new Vector2(_t.position.x, _t.position.y));
    }

    // COGE LA PULSACION
    // TRANSFORMA LA PULSACION A LAS COORDENADAS DEL MUNDO
    /*private bool ComprobarPulsacionObjetoByName(Touch _t, string _name) {
        bool estaPulsado = false;
        Vector3 touchWorldPosition = getWorldPosition(_t); // COJO LA PULSACION DEL MUNDO
        print("POSICION PAJARO " + touchWorldPosition);
        RaycastHit2D rch2d = Physics2D.Raycast(Camera.main.transform.position,touchWorldPosition);
        
        if (rch2d.transform != null && rch2d.transform.gameObject.name == _name) {
            estaPulsado = true;
        }
        return estaPulsado;
    }*/
}
