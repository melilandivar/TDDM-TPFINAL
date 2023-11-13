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

    private bool primerEstado=true;
    private bool segundoEstado;
    private bool regresar=false;
    private bool subir = false;
    private bool subirDos = false;

    void Start()
    {
        
            
            objActual = 0;
            // Voltear sprite hacia la derecha
            transform.localScale = new Vector3(-1, 1, 1);
            step = velocidad * Time.deltaTime;
       
        
        
     

        
        segundoEstado = false;
    }

    void Update()
    {
        if (primerEstado) {
            transform.position = Vector3.MoveTowards(transform.position, objetoColision[objActual].position, step);
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
                //transform.position = Vector3.MoveTowards(transform.position, objetoColision[objActual].position, step);
                //transform.localScale = new Vector3((objActual == 0) ? -1 : 1, 1, 1);
            }
        }

        if (segundoEstado)
        {
            
            if (subir)
            {
                subirEscalera01();
            }
            else if (subirDos)
            {
                subirEscalera02();
            }

        }

        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Detected");

        if (primerEstado)
        {
            if (collision.gameObject.CompareTag("Silla"))
            {
                bajando = true;
            }
            else if (collision.gameObject.CompareTag("Lavarropa"))
            {
                bajarDos = true;
            }
            else if (collision.gameObject.CompareTag("ColiMaria03"))
            {
                //segundoEstado = true;
                regreso();
            }
        }
        if (segundoEstado)
        {
            if (collision.gameObject.CompareTag("Escalera01"))
            {
                subir = true;
            }
            if (collision.gameObject.CompareTag("Escalera02"))
            {
                subirDos = true;
            }
            if (collision.gameObject.CompareTag("ultimaPrincipio"))
            {
                reiniciar();
            }
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

    void subirEscalera01()
    {
       
        // Cambiar la dirección
        objActual = 4;
        subir = false;

        Vector3 nuevaPosicion = transform.position + new Vector3(0, 290, 0);
        transform.position = nuevaPosicion;

        // Voltear sprite hacia la derecha
        transform.localScale = new Vector3(-1, 1, 1);

    }

    void subirEscalera02()
    {
        // Cambiar la dirección
        objActual = 5;
        subirDos = false;

        Vector3 nuevaPosicion = transform.position + new Vector3(0, 290, 0);
        transform.position = nuevaPosicion;

        // Voltear sprite hacia la derecha
        transform.localScale = new Vector3(1, 1, 1);

    }

    void regreso()
    {
        // Movimiento horizontal
        transform.position = Vector3.MoveTowards(transform.position, objetoColision[objActual].position, step);

        // Cambiar la dirección
        objActual = 3;
        //bajarDos = false;
        // Voltear sprite hacia la derecha
        transform.localScale = new Vector3(1, 1, 1);
        segundoEstado = true;
    }

    void reiniciar()
    {
        Start();
    }
}

