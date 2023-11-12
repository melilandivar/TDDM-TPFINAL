using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform[] views;
    public float transitionSpeed;
    private int currentViewIndex = 0;
    private CambiarEscenas cambiarEscenas;
    private PuntosElectricos puntosElectricos;
    public bool on;

    void Start()
    {
        InvokeRepeating("ChangeToNextView", 0f, 2f); // Cambia de vista cada 5 segundos (ajusta seg�n sea necesario)
        cambiarEscenas = FindObjectOfType<CambiarEscenas>();
        puntosElectricos = FindObjectOfType<PuntosElectricos>();
    }

    void Update(){
        if(currentViewIndex == 5){
            cambiarEscenas.CargarEscena("Perder");
          //  puntosElectricos.cambiarCamara = true;
        }
        Debug.Log(currentViewIndex);
    }

    void ChangeToNextView()
    {
        currentViewIndex = (currentViewIndex + 1) % views.Length;
        StartCoroutine(TransitionToView(views[currentViewIndex]));
    }

    IEnumerator TransitionToView(Transform targetView)
    {
        float t = 0f;
        Transform startingView = transform;

        while (t < 1f)
        {
            t += Time.deltaTime * transitionSpeed;
            transform.position = Vector3.Lerp(startingView.position, targetView.position, t);
            yield return null;
        }
    }
}

//aca es lo mismo pero con teclas

/*
public class Camara : MonoBehaviour
{
    public Transform[] views;
    public float transitionSpeed;
    Transform currentView;
    void Start()
    {
        currentView = transform;
    }


    // En el update estoy poniendo para que las vistas cambien con las teclas. Habria que modificarlo a tiempos. Ej: 1 segundo y pasa a la siguiente

    
    void Update()

    {
        if(Input.GetKeyDown(KeyCode.Q)) 
        { 
            currentView = views[0];
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            currentView = views[1];
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentView = views[2];
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            currentView = views[3];
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            currentView = views[4];
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            currentView = views[5];
        }
        
    }
   // aca se hace el movimiento de camara en si
    private void LateUpdate()
    {

        transform.position = Vector3.Lerp(transform.position, currentView.position,Time.deltaTime * transitionSpeed);

    }
}
*/