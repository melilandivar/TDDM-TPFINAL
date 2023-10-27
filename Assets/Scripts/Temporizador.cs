using UnityEngine;

public class Temporizador : MonoBehaviour
{
    public float duracionTotal = 240f; // Duración total del juego en segundos (4 minutos)
    public GameObject solMañana;
    public GameObject solTarde;
    public GameObject solNoche;
    public GameObject veinticinco;
    public GameObject treinta;
    public GameObject treintaydos;
    public GameObject treintaycinco;

    private void Start()
    {
        // Iniciar el temporizador cuando el juego comienza
        InvokeRepeating("ActualizarTemporizador", 0f, 1f); // Invocar ActualizarTemporizador cada segundo
        Puntos.puntos = 10f;

    }
    
        // Update is called once per frame
    void Update()
    {

    }

    private void ActualizarTemporizador()
    {
        // Acceder a la variable puntos del script Puntos
      //  Puntos.puntos -= 1f; 
        duracionTotal -= 1f; // Reducir 1 segundo del temporizador
        Debug.Log("puntos" + Puntos.puntos);

        // Verificar el tiempo actual y activar los objetos correspondientes
        if (duracionTotal <= 240f) // Menos de 2 minutos (solMañana)
        {
            solMañana.SetActive(true);
            veinticinco.SetActive(true);
           
            treinta.SetActive(false);   
            treintaydos.SetActive(false);   
            treintaycinco.SetActive(false);   
            
            
        }
        if(duracionTotal == 235f){
     //     Puntos.puntos -= 3f;
        }
        if (duracionTotal <= 235f) // Menos de 2 minutos (solMañana)
        {
            veinticinco.SetActive(false);            
            solMañana.SetActive(false);

            treinta.SetActive(true);
            solTarde.SetActive(true);
            
        }
        if(duracionTotal == 230f){
      //      Puntos.puntos -= 5f;
        }
        if (duracionTotal <= 230f && duracionTotal > 0f) // Entre 2 y 3 minutos (solTarde)
        {
  
            treinta.SetActive(false);           
            solTarde.SetActive(false);
            treintaydos.SetActive(true);
            solNoche.SetActive(true);

          
        }
        if(duracionTotal == 225f){
       //      Puntos.puntos -= 3f;
        }
        if (duracionTotal <=0f) // El tiempo ha terminado
        {

            // Puedes hacer algo cuando el juego termina, como mostrar un mensaje de Game Over o reiniciar el nivel.
        }
    }
}
