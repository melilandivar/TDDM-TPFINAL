using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSequenceController : MonoBehaviour
{
    public Camera[] cameras; // Asigna las c�maras en el Inspector
    private int currentCameraIndex = 0;

    void Start()
    {
        // Activa la primera c�mara de la secuencia
        ActivateCamera(currentCameraIndex);
    }

    // Activa una c�mara y desactiva las dem�s
    void ActivateCamera(int index)
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(i == index);
        }
    }

    // M�todo para avanzar a la siguiente c�mara
    public void SwitchToNextCamera()
    {
        // Desactiva la c�mara actual
        cameras[currentCameraIndex].gameObject.SetActive(false);

        // Avanza al �ndice siguiente
        currentCameraIndex++;

        // Comprueba si llegaste al final de la secuencia
        if (currentCameraIndex >= cameras.Length)
        {
            // Vuelve al principio de la secuencia
            currentCameraIndex = 0;
        }

        // Activa la siguiente c�mara
        ActivateCamera(currentCameraIndex);
    }

    public void InitSequence()
    {
        for(int i = currentCameraIndex; i < cameras.Length;i++)
        {
            Debug.Log("Activando camara: "+i);
            this.ActivateCamera(i);
        }
    }
}


// en donde se hace el corte de luz habria que agregar la siguiente linea SwitchToNextCamera(), para llamar al switcheo