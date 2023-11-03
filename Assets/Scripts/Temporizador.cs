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
    public GameObject cuarenta;

    private Dialogos dialogos;  
    private ControlarLuces controlarLuces;

    private void Start()
    {
        // Iniciar el temporizador cuando el juego comienza
        InvokeRepeating("ActualizarTemporizador", 0f, 1f); // Invocar ActualizarTemporizador cada segundo
        //Puntos para el estres
        Puntos.puntos = 10f;
        dialogos = FindObjectOfType<Dialogos>(); // Encuentra el objeto con el script Dialogos
        controlarLuces = FindObjectOfType<ControlarLuces>(); // Encuentra el objeto con el script ControlarLuces
        if (dialogos == null)
        {
            Debug.LogError("No se encontró el objeto con el script Dialogos en la escena.");
        }


    }
    
        // Update is called once per frame
    void Update()
    {

    }

    private void ActualizarTemporizador()
    {
        duracionTotal -= 1f; // Reducir 1 segundo del temporizador
        Debug.Log("puntos" + Puntos.puntos);

        //___________________________________________________  MAÑANA
        if (duracionTotal <= 90f) // 1:30 es solMañana
        {
            solMañana.SetActive(true);
            veinticinco.SetActive(true);
           
            treinta.SetActive(false);   
            treintaydos.SetActive(false);   
            treintaycinco.SetActive(false);   
            cuarenta.SetActive(false);   
            Debug.Log("Mañana");
            
            
        }
        if(duracionTotal == 85f){ // 1:25 aparecen dialogos 
           dialogos.activarLavarropas();          
           controlarLuces.activarLuces("lavarropas");   
        }  
        if(duracionTotal == 84f){ // 1:24 aparecen dialogos
           Debug.Log("dialogo pc");
           dialogos.activarComputadora(); 
           controlarLuces.activarLuces("monitor");      
           controlarLuces.activarLuces("gabinete");    
           
        }
        if(duracionTotal == 72f){ // 1:12 
           veinticinco.SetActive(false);
           treinta.SetActive(true);        
        }  
        //___________________________________________________  TARDE
        if(duracionTotal == 60f){ // 1:00 se restan 3 puntos 
           Puntos.puntos -= 3f;
           Debug.Log("Restar 3 puntos");

        }
        if(duracionTotal == 57f){ // aparecen dialogos 
            dialogos.desactivarLavarropas();
            controlarLuces.desactivarLuces("lavarropas"); 
            controlarLuces.activarLuces("aire"); 
            controlarLuces.activarLuces("monitor");      
            controlarLuces.activarLuces("gabinete");  
            dialogos.activarAire();        
            dialogos.activarComputadora();     
        }
        if(duracionTotal == 28f){ // aparecen dialogos
            dialogos.desactivarAire();
            dialogos.desactivarComputadora();
            controlarLuces.desactivarLuces("aire"); 
            controlarLuces.desactivarLuces("monitor");      
            controlarLuces.desactivarLuces("gabinete");  
            controlarLuces.activarLuces("microondas");      
            controlarLuces.activarLuces("lavarropas");  
            dialogos.activarMicroondas();
            dialogos.activarLavarropas();           
        }
        if (duracionTotal <= 54f) // 1:00 es solTarde
        {
            treinta.SetActive(false);            
            solMañana.SetActive(false);

            treintaydos.SetActive(true);
            solTarde.SetActive(true);

            Debug.Log("Tarde");
            
        }

        if(duracionTotal == 36f){ //36 
            treintaydos.SetActive(false);    
            treintaycinco.SetActive(true);
        }

        if(duracionTotal == 18){ //30 seg se restan 5 puntos cc
            Puntos.puntos -= 5f;
            Debug.Log("Restar 5 puntos");
        }
        if (duracionTotal <= 18 && duracionTotal > 0f) // 00:30 seg es solNoche
        {
  
            treintaycinco.SetActive(false);           
            solTarde.SetActive(false);
            cuarenta.SetActive(true);
            solNoche.SetActive(true);

            Debug.Log("Noche");

          
        }
        if (duracionTotal <=0f) // El tiempo ha terminado
        {
            //Pantalla perder
        }
    }
}
