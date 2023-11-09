using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public Transform target;
    public float velocidad = 5f;
    public float alturaSalto = 100f; // Ajusta la altura del salto según tus necesidades
    private bool subiendo = false;
    public Transform nuevoTarget; // Nueva variable para el nuevo destino
                                  // Movimiento hacia la derecha
    private float step;


      void Update()
    {
                        
            if (subiendo)
            {
                transform.position = Vector3.MoveTowards(transform.position, nuevoTarget.position, step);
            }
            else
            {
                step = velocidad * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            }
        
    }

    // Se llama cuando se produce una colisión
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Escalera01"))
        {
            SubirEscalera();
        }
    }

    void SubirEscalera()
    {
        // Subir a una altura determinada
        Vector3 nuevaPosicion = transform.position + new Vector3(0, alturaSalto, 0);
        transform.position = nuevaPosicion;

        // Cambiar la dirección a la izquierda
        subiendo = true;        
    }
}




