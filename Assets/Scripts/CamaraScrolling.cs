using UnityEngine;

public class CameraScrolling : MonoBehaviour
{
    public float scrollSpeed = 100f;
    public float minY = 380f; // Declarar minY
    public float maxY = 1000f; // Declarar maxY

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        float newPositionY = transform.position.y - scroll * scrollSpeed;

        // Limitar el desplazamiento en el eje Y
        newPositionY = Mathf.Clamp(newPositionY, minY, maxY);

        // Aplicar el nuevo valor de Y a la posición de la cámara
        transform.position = new Vector3(transform.position.x, newPositionY, transform.position.z);
    }
}
