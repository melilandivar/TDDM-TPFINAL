using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionController : MonoBehaviour
{
    public Camera mainCamera;
    public Transform newCameraPosition;
    public float transitionSpeed = 1.5f; // Velocidad de transición

    void Start()
    {
        // Verifica si hay información de la última posición guardada
        if (CameraTransitionData.hasSavedData)
        {
            StartCoroutine(TransitionToNewScene());
        }
    }

    IEnumerator TransitionToNewScene()
    {
        float t = 0f;
        Vector3 startingPosition = mainCamera.transform.position;
        Quaternion startingRotation = mainCamera.transform.rotation;

        while (t < 1f)
        {
            t += Time.deltaTime * transitionSpeed;

            mainCamera.transform.position = Vector3.Lerp(startingPosition, newCameraPosition.position, t);
            mainCamera.transform.rotation = Quaternion.Slerp(startingRotation, newCameraPosition.rotation, t);

            yield return null;
        }

        // Restaura la información de la cámara
        CameraTransitionData.hasSavedData = false;
    }

    public void ChangeToNewScene(string sceneName)
    {
        // Guarda la información de la cámara antes de cambiar de escena
        CameraTransitionData.hasSavedData = true;

        // Carga la siguiente escena
        SceneManager.LoadScene(sceneName);
    }

    public static class CameraTransitionData
    {
        public static bool hasSavedData = false;
    }
}


