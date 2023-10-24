using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Contador : MonoBehaviour
{
    public TextMeshProUGUI contadorTexto; // Arrastra el objeto Text aquí desde el Inspector.
    private int contador = 0;

    public void ModificarContador(int valor)
    {
        contador += valor;
        ActualizarTextoContador();
    }

    void ActualizarTextoContador()
    {
        contadorTexto.text = "Contador: " + contador;
    }
}
