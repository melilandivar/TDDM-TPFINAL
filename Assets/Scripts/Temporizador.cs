using UnityEngine;

public class Temporizador : MonoBehaviour
{
    public float duracionTotal = 90f; // Duración total del juego en segundos (4 minutos)
    public GameObject solMañana;
    public GameObject solTarde;
    public GameObject solNoche;
    public GameObject treinta;
    public GameObject treintaydos;
    public GameObject treintaycinco;
    public GameObject cuarenta;
    public AudioSource audio;


    private Dialogos dialogos;  
    private ControlarLuces controlarLuces;
    private ControladorAudios controlAudios;
    private Interactuar interactuar;

    private bool audioReproducido = false;



    private void Start()
    {
        // Iniciar el temporizador cuando el juego comienza
        InvokeRepeating("ActualizarTemporizador", 0f, 1f); // Invocar ActualizarTemporizador cada segundo
        //Puntos para el estres
        Puntos.puntos = 10f;
        dialogos = FindObjectOfType<Dialogos>(); // Encuentra el objeto con el script Dialogos
        controlarLuces = FindObjectOfType<ControlarLuces>(); // Encuentra el objeto con el script ControlarLuces
      controlAudios = FindObjectOfType<ControladorAudios>(); // Encuentra el objeto con el script ControlarLuces
        interactuar = FindObjectOfType<Interactuar>(); // Encuentra el objeto con el script ControlarLuces
        audioReproducido = false;
    }
    
        // Update is called once per frame
    void Update()
    {

    }

    private void ActualizarTemporizador()
    {
        duracionTotal -= 1f; // Reducir 1 segundo del temporizador
        //Debug.Log("puntos" + Puntos.puntos);

        //___________________________________________________  MAÑANA
        if (duracionTotal <= 90f && duracionTotal >=60f) // 1:30 es solMañana
        {
            solMañana.SetActive(true);          
            treinta.SetActive(true);   
            treintaydos.SetActive(false);   
            treintaycinco.SetActive(false);   
            cuarenta.SetActive(false);
           
            if (!audioReproducido)
            {
                controlAudios.ReproducirAudio(0);
                audioReproducido = true;
            }

        }
        
        if (duracionTotal == 85f){ // 1:25 aparecen dialogos 
           dialogos.activarLavarropas();          
           controlarLuces.activarLuces("lavarropas");   
        }  
        if(duracionTotal == 84f){ // 1:24 aparecen dialogos
           Debug.Log("dialogo pc");
           dialogos.activarComputadora(); 
           controlarLuces.activarLuces("monitor");      
           controlarLuces.activarLuces("gabinete");    
           
        }
        //Resto puntos 
        if(duracionTotal == 75f){
            Puntos.puntos -=3;
        }
        //___________________________________________________  TARDE
        if(duracionTotal == 60f){ // 1:00 se restan 3 puntos 
           //Resto puntos
           Puntos.puntos -= 6f;
           Debug.Log("Tarde");
           Debug.Log("Restar 6 puntos");
           if(!interactuar.computadoraOn){
                //Resto puntos por no trabajar en la mañana
                Puntos.puntos -= 4f;
           }
           if(!interactuar.lavarropasOn){
                //Resto puntos por no limpiar en la mañana
                Puntos.puntos -= 2f;
           }
            if (audioReproducido)
            {
                controlAudios.PausarAudio(0);
                controlAudios.ReproducirAudio(1);               
            }

        }
        if(duracionTotal<=60f && duracionTotal >=30f){
           treinta.SetActive(false);  
           //Hacen 35 grados
           treintaycinco.SetActive(true);   
           

        }
        if(duracionTotal == 58f){ // aparecen dialogos 
            dialogos.desactivarLavarropas();
            controlarLuces.desactivarLuces("lavarropas"); 
            controlarLuces.activarLuces("aire"); 
            controlarLuces.activarLuces("monitor");      
            controlarLuces.activarLuces("gabinete");  
            dialogos.activarAire();        
            dialogos.activarComputadora();     
        }
        if(duracionTotal <= 40f && duracionTotal >=30f){ // evaluamos si sigue sin prender el aire 
            if(!interactuar.aireOn){ //si el aire nunca se prendio 
                cuarenta.SetActive(true);
                treintaycinco.SetActive(false);
            }
        }
        if(duracionTotal == 30f){ // 0:30 es solNoche
           //Resto puntos
           Puntos.puntos -= 6f;
           Debug.Log("Restar 6 puntos");
           if(!interactuar.computadoraOn){
                //Resto puntos por no trabajar en la tarde
                Puntos.puntos -= 4f;
           }
            if (audioReproducido)
            {
                controlAudios.PausarAudio(1);
                controlAudios.ReproducirAudio(2);
            }

        }
       if (duracionTotal <= 30f) // 00:30 es solNoche
        {
            treintaycinco.SetActive(false);       
            cuarenta.SetActive(false);     
            solTarde.SetActive(false);

            treintaydos.SetActive(true);
            solNoche.SetActive(true);
            
        }
        if(duracionTotal == 28f){ // aparecen dialogos
            dialogos.desactivarAire();
            dialogos.desactivarComputadora();
            controlarLuces.desactivarLuces("aire"); 
            controlarLuces.desactivarLuces("monitor");      
            controlarLuces.desactivarLuces("gabinete");  
            controlarLuces.activarLuces("microondas");      
            controlarLuces.activarLuces("aspiradora");  
            dialogos.activarMicroondas();
            dialogos.activarAspiradora();           
        }
        if (duracionTotal <=5f) // El tiempo ha terminado
        {
           if(!interactuar.microondasOn){
                //Resto puntos por no cocinar
                Puntos.puntos -= 5f;
           }
           if(!interactuar.aspiradoraOn){
                //Resto puntos por no limpiar
                Puntos.puntos -= 2f;
           }
        }

    }
    public void disminuirTemperatura(){
        cuarenta.SetActive(false);
        treintaycinco.SetActive(true);
        interactuar.aireOn = true;
    }
}
