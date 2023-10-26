using UnityEngine;

public class InteraccionMouse : MonoBehaviour
{
    void Update()
    {
        // Verifica si se hizo clic en el mouse
        if (Input.GetMouseButtonDown(0))
        {
            // Obtiene la posición del clic del mouse en el mundo
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Realiza un raycast para detectar objetos en el punto de clic
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            // Si el raycast golpea un collider 2D
            if (hit.collider != null)
            {
                // Intenta obtener el componente Interactuar del objeto clickeado
                Interactuar interactuarComponent = hit.collider.gameObject.GetComponent<Interactuar>();
                MicroondasScript microondasScript = hit.collider.gameObject.GetComponent<MicroondasScript>();

                // Si el objeto clickeado tiene el componente Interactuar
                if (interactuarComponent != null)
                {
                    // Llama a la función OnOffLuz() del componente Interactuar
                    interactuarComponent.Accionar();
                }

                                // Si el objeto clickeado tiene el componente Interactuar
                if (microondasScript != null)
                {
                    // Llama a la función OnOffLuz() del componente Interactuar
                    microondasScript.Accionar();
                    Debug.Log("compu en Interactuar script: " + microondasScript.esMicroondas);
                }
            }
        }
    }
}
