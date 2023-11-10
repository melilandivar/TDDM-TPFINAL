using UnityEngine.SceneManagement;
using UnityEngine;


public class CambiarEscenas : MonoBehaviour
{
    public void CargarEscena(string nombreDeEscena)
    {
        SceneManager.LoadScene(nombreDeEscena);
    }
}