using System.Collections;
using System.Collections.Generic;
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

    void Start()
    {
        mainCamera = GetComponent<Camera>();
        currentView = transform;
        originalSize = mainCamera.orthographicSize; // Almacena el tamaño original

    }


    // En el update estoy poniendo para que las vistas cambien con las teclas. Habria que modificarlo a tiempos. Ej: 1 segundo y pasa a la siguiente

    
    void Update()

    {
        if(Input.GetKeyDown(KeyCode.Q)) 
        { 
            currentView = views[0];
            StartCoroutine(ZoomEffect(zoomSize)); // Activa el efecto de zoom
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            currentView = views[1];
            StartCoroutine(ZoomEffect(zoomSize));
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentView = views[2];
            StartCoroutine(ZoomEffect(zoomSize));
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            currentView = views[3];
            StartCoroutine(ZoomEffect(zoomSize));
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            currentView = views[4];
            StartCoroutine(ZoomEffect(zoomSize));
        }

        //Esta ultima es la vista general, la original de la camara digamos
        if (Input.GetKeyDown(KeyCode.Y))
        {
            currentView = views[5];
            StartCoroutine(ZoomEffect(originalSize)); // Restaura el tamaño original
        }
        
    }

    // agregue recien 
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

    // aca se hace el movimiento de camara en si
    private void LateUpdate()
    {

        transform.position = Vector3.Lerp(transform.position, currentView.position,Time.deltaTime * transitionSpeed);

    }
}
