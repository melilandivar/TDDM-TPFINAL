using UnityEngine;

public class Temporizador : MonoBehaviour
{
    public float duracionTotal = 240f; // Duración total del juego en segundos (4 minutos)
    public GameObject solMañana;
    public GameObject solTarde;
    public GameObject solNoche;
    public GameObject Confortable;
    public GameObject Alarmante;
    public GameObject Crisis;
    public GameObject veinticinco;
    public GameObject treinta;
    public GameObject treintaydos;
    public GameObject treintaycinco;

    private void Start()
    {
        // Iniciar el temporizador cuando el juego comienza
        InvokeRepeating("ActualizarTemporizador", 0f, 1f); // Invocar ActualizarTemporizador cada segundo

    }
    
        // Update is called once per frame
    void Update()
    {

    }

    private void ActualizarTemporizador()
    {
        duracionTotal -= 1f; // Reducir 1 segundo del temporizador

        // Verificar el tiempo actual y activar los objetos correspondientes
        if (duracionTotal <= 240f) // Menos de 2 minutos (solMañana)
        {
            solMañana.SetActive(true);
            Confortable.SetActive(true);
            veinticinco.SetActive(true);

                        Alarmante.SetActive(false);
            treinta.SetActive(false);   
                        Crisis.SetActive(false);
            treintaydos.SetActive(false);   
            treintaycinco.SetActive(false);   
            
        }
        if (duracionTotal <= 235f) // Menos de 2 minutos (solMañana)
        {
            Confortable.SetActive(false);
            veinticinco.SetActive(false);            
            solMañana.SetActive(false);

            treinta.SetActive(true);
            Alarmante.SetActive(true);
            solTarde.SetActive(true);
        }

        if (duracionTotal <= 230f && duracionTotal > 0f) // Entre 2 y 3 minutos (solTarde)
        {
  
            treinta.SetActive(false);
            Alarmante.SetActive(false);            
            solTarde.SetActive(false);
            treintaydos.SetActive(true);
            Crisis.SetActive(true);
            solNoche.SetActive(true);
        }

        if (duracionTotal <=0f) // El tiempo ha terminado, puedes manejar el final del juego aquí
        {

            // Puedes hacer algo cuando el juego termina, como mostrar un mensaje de Game Over o reiniciar el nivel.
        }
    }
}
