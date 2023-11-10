using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public Transform[] objetoColision;
    public float velocidad = 5f;
    public float alturaSalto = 100f; // Ajusta la altura del salto según tus necesidades    
   


    private bool subiendo = false;
    private bool subirDos = false;
    private float step; // Movimiento 
    private int objActual; // objeto actual en el arreglo

    void Start()
    {
        objActual = 0;
        transform.localScale = new Vector3(1, 1, 1);
        step = velocidad * Time.deltaTime;
    }

    void Update()
    {
        
        if (subiendo)
            {
            SubirEscalera();
            /*objActual = 1;
            transform.position = Vector3.MoveTowards(transform.position, objetoColision[objActual].position, step);
            transform.localScale = new Vector3(-1, 1, 1);*/

        } else if (subirDos)
        {
            SubirEscaleraDos();

        }
            else
            {
            
            transform.position = Vector3.MoveTowards(transform.position, objetoColision[objActual].position, step);
            
        }
        
    }

    // Se llama cuando se produce una colisión
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Escalera01"))
        {
            subiendo = true;
            //SubirEscalera();
        }
        else if (collision.gameObject.CompareTag("Escalera02"))
        {
            subirDos = true;
            //SubirEscaleraDos();
        }
    }

    void SubirEscalera()
    {
        // Subir a una altura determinada
        Vector3 nuevaPosicion = transform.position + new Vector3(0, alturaSalto, 0);
        transform.position = nuevaPosicion;

      
        subiendo = false;

        //--objeto actual y flip der al sprite
        objActual = 1;
        transform.localScale = new Vector3(-1, 1, 1);
    }
    void SubirEscaleraDos()
    {
        // Subir a una altura determinada
        Vector3 nuevaPosicion = transform.position + new Vector3(0, alturaSalto, 0);
        transform.position = nuevaPosicion;

        subirDos = false;

        //---objeto actual y flip izq al sprite
        objActual = 2;
        transform.localScale = new Vector3(1, 1, 1);
    }
}




