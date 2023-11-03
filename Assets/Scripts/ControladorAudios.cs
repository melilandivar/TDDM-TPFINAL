using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorAudios : MonoBehaviour
{
    public AudioClip[] audios; // Arreglo de Audios
    private AudioSource controlAudio; 
   
    private void Awake()
    {
        controlAudio = GetComponent<AudioSource>();
    }

    //Este metodo nos permite controlar el Indice que seria el numero del array, y el volumen del sonido para ser utilizado en otro Script. 
    public void seleccionAudio (int indice, float volumen)
    {
        controlAudio.PlayOneShot(audios[indice], volumen); //PlayOneShot permite controlar el Volumen del audio
    }

    
}
