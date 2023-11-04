using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSequenceController : MonoBehaviour
{
    public Camera[] cameras; // Asigna las cámaras en el Inspector
    private int currentCameraIndex;

    void Start()
    {
        cameras = FindObjectsOfType<Camera>();
        currentCameraIndex = 0;
        // Activa la primera cámara de la secuencia
    }

    // Activa una cámara y desactiva las demás
    void ActivateCamera(int index)
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(i == index);
        }
    }

    // Método para avanzar a la siguiente cámara
    /*public void SwitchToNextCamera()
    {
        // Desactiva la cámara actual
        cameras[currentCameraIndex].gameObject.SetActive(false);

        // Avanza al índice siguiente
        currentCameraIndex++;

        // Comprueba si llegaste al final de la secuencia
        if (currentCameraIndex >= cameras.Length)
        {
            // Vuelve al principio de la secuencia
            currentCameraIndex = 0;
        }

        // Activa la siguiente cámara
        ActivateCamera(currentCameraIndex);
    }*/

    public void InitSequence()
    {
        for(int i = currentCameraIndex; i < cameras.Length;i++)
        {
            ActivateCamera(i);
        }
    }
}


// en donde se hace el corte de luz habria que agregar la siguiente linea SwitchToNextCamera(), para llamar al switcheo