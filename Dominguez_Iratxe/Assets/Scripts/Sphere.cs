using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sphere : MonoBehaviour
   
{
    [SerializeField] Text myText;

    // Variable que guarda la velocidad maxima del objeto
    private float velocidad = 3f;

    // Variables que muestran si el objeto esta dentro de limites y se puede mover (valor 1) o fuera de los limites y no se puede mover (valor 0) 
    private float limX = 1f;
    private float limY = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Tiempo");
    }

    // Update is called once per frame
    void Update()
    {
        LimitadorMovimiento();
    }
    void LimitadorMovimiento()
    {
        // En desplX se guarda el desplazamiento horizontal que se genera en el controlador (teclado o mando)
        float desplX = Input.GetAxis("Horizontal");

        // Este "if" significa que estás cerca del límite izquierdo (ej: -8f) y sigues intentando moverte a la izquierda (desplX < 0) 
        // Por lo tanto no puedes moverte (limX = 0f)
        if (transform.position.x <= -4f && desplX < 0)
        {
            limX = 0f;
        }
        // Este "else if" significa que estás cerca del límite derecho (ej: 8f) y sigues intentando moverte a la derecha (desplX > 0) 
        // Por lo tanto no puedes moverte (limX = 0f)
        else if (transform.position.x >= 4f && desplX > 0)
        {
            limX = 0f;
        }
        // En el caso de que no intentes atravesar los limites puedes moverte libremente (limX = 1f)
        else
        {
            limX = 1f;
        }

        //El metodo transform.Translate() mueve el objeto una pequeña cantidad para dar ilusion de movimiento fluido
        //Se utiliza el "Vector3.right" para moverlo a derechas y a izquierdas porque Unity utiliza el signo de desplX (positivo o negativo)
        //"velocidad" indica la velocidad del movimiento y se multiplica por Time.deltaTime para que el objeto no salga disparado
        transform.Translate(Vector3.right * Time.deltaTime * velocidad * desplX * limX);


        // Para el eje Y se realiza de la misma forma cambiando las variables
        float desplY = Input.GetAxis("Vertical");

        if (transform.position.y <= 0f && desplY < 0)
        {
            limY = 0f;
        }
        else if (transform.position.y >= 4f && desplY > 0)
        {
            limY = 0f;
        }
        else
        {
            limY = 1f;
        }
        transform.Translate(Vector3.forward * Time.deltaTime * velocidad * desplY * limY);
    }
    IEnumerator Tiempo()
    {
        int n;
        for(n=0; ; n++)
        {
            myText.text = "Tiempo transcurrido:" + n;

            yield return new WaitForSeconds(1f);
        }
    }
   
}
