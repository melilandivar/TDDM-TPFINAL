using UnityEngine;

public class MovimientoMaria : MonoBehaviour
{
    public Transform[] objetoColision;
    public float velocidad = 5f;
    public float alturaSalto = 200f;

    private bool bajando = false;
    private bool bajarDos = false;
    private int objActual = 0;
    private float step;

    void Start()
    {
        objActual = 0;
        // Voltear sprite hacia la derecha
        transform.localScale = new Vector3(-1, 1, 1);
        step = velocidad * Time.deltaTime;
    }

    void Update()
    {
        if (bajando)
        {
            BajarEscalera();
        }
        else if (bajarDos)
        {
            BajarEscaleraDos();
        }
        else
        {
            // Movimiento horizontal
            transform.position = Vector3.MoveTowards(transform.position, objetoColision[objActual].position, step);
            //transform.localScale = new Vector3((objActual == 0) ? -1 : 1, 1, 1);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Detected");

        if (collision.gameObject.CompareTag("Silla"))
        {
            bajando = true;
        }
        else if (collision.gameObject.CompareTag("Lavarropa"))
        {
            bajarDos = true;
        }
    }

    void BajarEscalera()
    {
        // Bajar a una altura determinada
        Vector3 nuevaPosicion = transform.position + new Vector3(0, alturaSalto, 0);
        transform.position = nuevaPosicion;

        // Cambiar la dirección
        objActual = 1;
        bajando = false;

        // Voltear sprite hacia la izquierda
        transform.localScale = new Vector3(1, 1, 1);
    }

    void BajarEscaleraDos()
    {
        // Bajar a una altura determinada
        Vector3 nuevaPosicion = transform.position + new Vector3(0, alturaSalto, 0);
        transform.position = nuevaPosicion;

        // Cambiar la dirección
        objActual = 2;
        bajarDos = false;
        // Voltear sprite hacia la derecha
        transform.localScale = new Vector3(-1, 1, 1);
    }
}

