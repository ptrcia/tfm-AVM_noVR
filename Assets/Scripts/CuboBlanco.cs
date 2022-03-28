using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuboBlanco : MonoBehaviour
{

    // Jugador, esta es la referencia para saber la posici�n del jugador
    public Transform player; 

    // Posici�n inicial del cubo, la guardamos para saber cuando dejar de "volver atr�s"
    Vector3 posIni;

    private void Start()
    {
        // Al iniciar, declaramos que la posici�n inicial es la posici�n que tenga el cubo blanco en la escena
        posIni = transform.position;
    }

    private void Update()
    {
        // Solo comprobamos cosas si el player no es null, para evitar problemas de null y fallos en el juego en caso de que el player no exista en la escena
        if(player != null)
        {
            /*
             * Vector3 tiene un m�todo llamado Distance, que devuelve la distancia que hay entre dos posiciones en la escena en float
             * Los par�metros son dos Vector3, en este caso son los transform position que ves
             * this.transform.position se refiere a la posici�n del gameobject que tiene asignado el script, en este caso el cubo blanco
             * player.position es la posici�n del jugador, el cubo rojo
             * 
             * Adem�s, este if tiene un OR (||), es decir, que el cubo se mover� si la distancia es menor que 3 (se le acerca) 
             * o si la posici�n Z es mayor o igual (>=) que la Z incial del cubo blanco, para que si vuelve al incio no siga "bajando"
             * 
             */
            if (Vector3.Distance(this.transform.position, player.position) < 10f || transform.position.x >= posIni.x)
            {
                /* 
                 * Para moverlo, creamos una posici�n objetivo a donde se va a mover
                 * La declaramos como un nuevo Vector3, donde la x ser� la misma que tengamos, la Y igual
                 * PERO la Z ser� la del jugador MAS 3.0 FLOAT (3f)
                 * Con esto el cubo se mover� alante y atr�s teniendo en cuenta de estar a 3 por delante del cubo rojo y las otras coordenadas no se moveran
                 * La Y no se edita porque es hacia arriba, ten en cuenta tu eje de movimiento, si no sabes cual debes sumarle prueba si es la Z o la X en el editor
                 * 
                 */
                Vector3 targetPos = new Vector3(player.position.x + 10f, this.transform.position.y, this.transform.position.z);

                // Le decimos que la posici�n del cubo es la posici�n objetivo (esto es lo que "mueve" el cubo)
                this.transform.position = targetPos;
            }
        }
    }
        


}
