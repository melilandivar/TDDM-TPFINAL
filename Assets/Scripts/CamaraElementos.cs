using System.Collections;
using UnityEngine;

public class CamaraElementos : MonoBehaviour
{
    public Transform[] views;
    public float transitionSpeed;
    private Transform currentView;
    private Camera mainCamera;

    public float zoomSize = 5f; // Tamaño de zoom para la cámara ortográfica
    public float defaultSize = 10f; // Tamaño ortográfico por defecto

    private float originalSize; // Guarda el tamaño original antes del zoom

    private Interactuar interactuar;

    void Start()
    {
        mainCamera = GetComponent<Camera>();
        interactuar = FindObjectOfType<Interactuar>();
        currentView = transform;
        originalSize = mainCamera.orthographicSize; // Almacena el tamaño original
    }

    void Update()
    {


        // Verifica si el zoom está activo antes de realizar zoom al presionar teclas o el botón
        if (!interactuar.camaraCerca)
        {
            // Aire
            if (Input.GetKeyDown(KeyCode.Q))
            {
                interactuar.camaraCerca = true;
                currentView = views[0];
                StartCoroutine(ZoomEffect(zoomSize)); // Activa el efecto de zoom
            }
            // Lavarropas
            else if (Input.GetKeyDown(KeyCode.W))
            {
                interactuar.camaraCerca = true;
                currentView = views[1];
                StartCoroutine(ZoomEffect(zoomSize));
            }
            // ... Agrega condiciones para otros elementos

            // Última es la vista general, la original de la cámara
            else if (Input.GetKeyDown(KeyCode.U))
            {
                interactuar.camaraCerca = false;
                currentView = views[6];
                StartCoroutine(ZoomEffect(originalSize)); // Restaura el tamaño original
            }
        }
    }

    public void acercarCamara(string objeto)
    {

        // Verifica si el zoom está activo antes de realizar zoom al hacer clic en el botón
        if (!interactuar.camaraCerca)
        {
            // Aire
            if (objeto == "aire")
            {
                interactuar.camaraCerca = true;
                currentView = views[0];
                StartCoroutine(ZoomEffect(zoomSize)); // Activa el efecto de zoom
            }
            // Lavarropas
            else if (objeto == "lavarropas")
            {
                interactuar.camaraCerca = true;
                currentView = views[1];
                StartCoroutine(ZoomEffect(zoomSize));
            }
                   //aspiradora
        if (objeto == "aspiradora")
        {
            interactuar.camaraCerca = true;
            currentView = views[2];
            StartCoroutine(ZoomEffect(zoomSize));
        }

        //microondas
        if (objeto == "microondas")
        {
            interactuar.camaraCerca = true;
            currentView = views[3];
            StartCoroutine(ZoomEffect(zoomSize));
        }
        //ventilador
        if (objeto == "ventilador")
        {
            interactuar.camaraCerca = true;
            currentView = views[4];
            StartCoroutine(ZoomEffect(zoomSize));
        }
        //computadora
        if (objeto == "computadora")
        {
            interactuar.camaraCerca = true;
            currentView = views[5];
            StartCoroutine(ZoomEffect(zoomSize));
        }

            // Última es la vista general, la original de la cámara
            else if (objeto == "general")
            {
                interactuar.camaraCerca = false;
                currentView = views[6];
                StartCoroutine(ZoomEffect(originalSize)); // Restaura el tamaño original
            }
        }
    }

    public void DesactivarZoom()
    {
        // Verifica si el zoom está activo antes de desactivarlo
        if (interactuar.camaraCerca)
        {
            interactuar.camaraCerca = false;
            currentView = views[6];
            StartCoroutine(ZoomEffect(originalSize)); // Restaura el tamaño original
        }
    }

    IEnumerator ZoomEffect(float targetSize)
    {
        float initialSize = mainCamera.orthographicSize;
        float timer = 0f;
        while (timer < transitionSpeed)
        {
            timer += Time.deltaTime;
            mainCamera.orthographicSize = Mathf.Lerp(initialSize, targetSize, timer / transitionSpeed);
            yield return null;
        }
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, currentView.position, Time.deltaTime * transitionSpeed);
    }
}
