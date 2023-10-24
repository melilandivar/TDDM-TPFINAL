using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscenas : MonoBehaviour
{
    public void CargarEscena(string nombreDeEscena)
    {
        SceneManager.LoadScene(nombreDeEscena);
    }
}
