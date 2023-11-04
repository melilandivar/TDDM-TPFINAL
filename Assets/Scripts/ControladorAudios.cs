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

  //QUIZAS EL PLAYONESHOT se puede usar para los sonidos de los objetos, ya que deberian ser mas cortos
    public void seleccionAudio (int indice, float volumen)
    {
        controlAudio.PlayOneShot(audios[indice], volumen); //PlayOneShot permite controlar el Volumen del audio
    }

    // Este método permite reproducir un audio específico del arreglo.
    public void ReproducirAudio(int indice)
    {
        controlAudio.clip = audios[indice];
        controlAudio.Play();
    }
    public void PausarAudio(int indice)
    {
        controlAudio.clip = audios[indice];
        controlAudio.Pause();
    }
}
