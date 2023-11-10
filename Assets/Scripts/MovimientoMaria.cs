using UnityEngine;

public class MovimientoMaria : MonoBehaviour
{
    public Transform[] objetoColision;
    public float velocidad = 5f;
    public float alturaSalto = 200f; // Ajusta la altura del salto seg�n tus necesidades    

    private bool subiendo = false;
    private float step; // Movimiento 
    private int objActual; // objeto actual en el arreglo

    void Start()
    {
        objActual = 0; // Puedes establecer el valor inicial aqu�
                       // Restablecer la escala inicial
       
    }


    void Update()
    {
        Debug.Log("Inside Update");
        //Debug.Log("Time.deltaTime: " + Time.deltaTime);

        step = velocidad * Time.deltaTime;
        if (subiendo)
        {
            objActual = 1;
            transform.position = Vector3.MoveTowards(transform.position, objetoColision[objActual].position, step);
            transform.localScale = new Vector3(1, 1, 1);

        }
        else
        {
            
            objActual = 0;
            transform.position = Vector3.MoveTowards(transform.position, objetoColision[objActual].position, step);
            transform.localScale = new Vector3(-1, 1, 1);
        }

    }

    // Se llama cuando se produce una colisi�n
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Detected");

        if (collision.gameObject.CompareTag("Silla"))
        {
            SubirEscalera();
        }
    }

    void SubirEscalera()
    {
        // Subir a una altura determinada
        Vector3 nuevaPosicion = transform.position + new Vector3(0, alturaSalto, 0);
        transform.position = nuevaPosicion;

        // Cambiar la direcci�n a la izquierda
        subiendo = true;
    }
}
