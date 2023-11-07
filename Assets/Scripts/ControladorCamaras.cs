using UnityEngine;

public class ControladorCamaras : MonoBehaviour
{
    public Transform objetivo; // El objeto hacia el cual quieres mover la cámara
    public float velocidadMovimiento = 5.0f;
    public float velocidadZoom = 5.0f; // Velocidad de cambio del campo de visión

    void Update()
    {

    }

    public void moverCamara(){
        // Verifica si el objeto de destino está asignado
        if (objetivo != null)
        {
            // Calcula la posición intermedia entre la posición actual de la cámara y la posición del objetivo
            Vector3 nuevaPosicion = Vector3.Lerp(transform.position, objetivo.position, velocidadMovimiento * Time.deltaTime);
            
            // Modifica el campo de visión para lograr un efecto de zoom
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, objetivo.GetComponent<Camera>().fieldOfView, velocidadZoom * Time.deltaTime);

            // Establece la nueva posición de la cámara
            transform.position = nuevaPosicion;
        }
    }
}
