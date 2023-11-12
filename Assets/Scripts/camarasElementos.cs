using UnityEngine;

public class camarasElementos : MonoBehaviour
{
    public Transform objetivo; // El objeto hacia el cual quieres mover la c�mara
    public float velocidadMovimiento = 5.0f;
    public float velocidadZoom = 5.0f; // Velocidad de cambio del campo de visi�n

    void Update()
    {

    }

    public void moverCamara()
    {
        // Verifica si el objeto de destino est� asignado
        if (objetivo != null)
        {
            // Calcula la posici�n intermedia entre la posici�n actual de la c�mara y la posici�n del objetivo
            Vector3 nuevaPosicion = Vector3.Lerp(transform.position, objetivo.position, velocidadMovimiento * Time.deltaTime);

            // Modifica el campo de visi�n para lograr un efecto de zoom
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, objetivo.GetComponent<Camera>().fieldOfView, velocidadZoom * Time.deltaTime);

            // Establece la nueva posici�n de la c�mara
            transform.position = nuevaPosicion;
        }
    }
}
