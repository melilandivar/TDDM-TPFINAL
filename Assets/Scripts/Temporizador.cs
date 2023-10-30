using UnityEngine;

public class Temporizador : MonoBehaviour
{
    public float duracionTotal = 90f; // Duración total del juego en segundos (4 minutos)
    public GameObject solMañana;
    public GameObject solTarde;
    public GameObject solNoche;
    public GameObject veinticinco;
    public GameObject treinta;
    public GameObject treintaydos;
    public GameObject treintaycinco;

Dialogos dialogos = new Dialogos();

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
        if (duracionTotal <= 90f) // 1:30 es solMañana
        {
            solMañana.SetActive(true);
            veinticinco.SetActive(true);
           
            treinta.SetActive(false);   
            treintaydos.SetActive(false);   
            treintaycinco.SetActive(false);   

            Debug.Log("Mañana");
            
            
        }
        if(duracionTotal == 80f){ // 1:00 se restan 3 puntos 
           dialogos.activarComputadora();           
        }
        if(duracionTotal == 83f){ // 1:00 se restan 3 puntos 
           dialogos.activarLavarropas();           
        }       
        if(duracionTotal == 60f){ // 1:00 se restan 3 puntos 
           Puntos.puntos -= 3f;
           Debug.Log("Restar 3 puntos");

        }
        if(duracionTotal == 57f){ // 1:00 se restan 3 puntos 
           dialogos.activarComputadora();           
        }
        if(duracionTotal == 55f){ // 1:00 se restan 3 puntos 
           dialogos.activarAire();           
        }
        if (duracionTotal <= 60f) // 1:00 es solTarde
        {
            veinticinco.SetActive(false);            
            solMañana.SetActive(false);

            treinta.SetActive(true);
            solTarde.SetActive(true);

            Debug.Log("Tarde");
            
        }
        if(duracionTotal == 30f){ //30 seg se restan 5 puntos
            Puntos.puntos -= 5f;
            Debug.Log("Restar 5 puntos");
        }
        if (duracionTotal <= 30 && duracionTotal > 0f) // 00:30 seg es solNoche
        {
  
            treinta.SetActive(false);           
            solTarde.SetActive(false);
            treintaydos.SetActive(true);
            solNoche.SetActive(true);

            Debug.Log("Noche");

          
        }
        if (duracionTotal <=0f) // El tiempo ha terminado
        {
            //Pantalla perder
        }
    }
}
