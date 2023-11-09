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
    public GameObject fondoDia;
    public GameObject fondoNoche;


    private Dialogos dialogos;  
    private ControlarLuces controlarLuces;
    private ControladorAudios controlAudios;
    private Interactuar interactuar;

    private bool audioReproducido = false;

    public float velocidad = 5f; // Puedes ajustar la velocidad según tus necesidades
    //private float duracionTotal = 60f; // Ajusta según tus necesidades



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

    void MoverHorizontalmente()
    {
        // Obtener la dirección de movimiento (puedes ajustar según tus necesidades)
        float direccionHorizontal = 1f; // Mover a la derecha

        // Calcular la nueva posición
        Vector3 nuevaPosicion = transform.position + new Vector3(direccionHorizontal * velocidad * Time.deltaTime, 0, 0);

        // Aplicar la nueva posición al objeto
        transform.position = nuevaPosicion;
    }

    private void ActualizarTemporizador()
    {
        duracionTotal -= 1f; // Reducir 1 segundo del temporizador
        //Debug.Log("puntos" + Puntos.puntos);

        //___________________________________________________  MAÑANA
        if (duracionTotal <= 60f && duracionTotal >=40f) // 00:60 es solMañana
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

            // Mover el personaje horizontalmente
            MoverHorizontalmente();

        }
        
        if (duracionTotal == 58f){ // 00:58 aparecen dialogos 
           dialogos.activarLavarropas();          
           controlarLuces.activarLuces("lavarropas");   
        }  
        if(duracionTotal == 57f){ // 00:57 aparecen dialogos
           Debug.Log("dialogo pc");
           dialogos.activarComputadora(); 
           controlarLuces.activarLuces("monitor");      
           controlarLuces.activarLuces("gabinete");    
           
        }
        //Resto puntos, seria que pasa al mediodía
        if(duracionTotal == 50f){
            Puntos.puntos -=3;
            treinta.SetActive(false);
            //hacen 32 grados al mediodia
            treintaydos.SetActive(true);
        }
        //___________________________________________________  TARDE
        if(duracionTotal == 40f){ // 00:40 es solTarde
           //Resto puntos
           Puntos.puntos -= 3f;
           Debug.Log("Tarde");
           Debug.Log("Restar 3 puntos");
           if(interactuar.computadoraOn == false){
               
                //Resto puntos por no trabajar en la mañana
                Puntos.puntos -= 4f;
           }
           if(interactuar.lavarropasOn == false){
                //Resto puntos por no limpiar en la mañana
                Puntos.puntos -= 2f;
           }
            if (audioReproducido)
            {
                controlAudios.PausarAudio(0);
                controlAudios.ReproducirAudio(1);               
            }

        }
        if(duracionTotal<=40f && duracionTotal >=20f){
           treinta.SetActive(false);
           treintaydos.SetActive(false);  
           //Hacen 35 grados
           treintaycinco.SetActive(true);   
           solMañana.SetActive(false);
           solTarde.SetActive(true);

        }
        if(duracionTotal == 39f){ // aparecen dialogos 
            dialogos.desactivarLavarropas();
            controlarLuces.desactivarLuces("lavarropas"); 
            controlarLuces.activarLuces("aire"); 
            controlarLuces.activarLuces("monitor");      
            controlarLuces.activarLuces("gabinete");  
            dialogos.activarAire();        
            dialogos.activarComputadora();     
        }
        if(duracionTotal <= 30f && duracionTotal >=20f){ // evaluamos si sigue sin prender el aire 
            if(interactuar.aireOn == false){ //si el aire nunca se prendio 
                cuarenta.SetActive(true);
                treintaycinco.SetActive(false);
            }
            //Indicador para que prenda el ventilador tambíen 
            dialogos.activarVentilador();
            dialogos.desactivarComputadora();
            controlarLuces.activarLuces("ventilador");
            controlarLuces.desactivarLuces("computadora");
        }
        if(duracionTotal == 20f){ // 00:20 es solNoche
           //Resto puntos
           Puntos.puntos -= 3f;
           Debug.Log("Restar 3 puntos");
           if(interactuar.computadoraOn == false){
                //Resto puntos por no trabajar en la tarde
                Puntos.puntos -= 4f;
           }
            if (audioReproducido)
            {
                controlAudios.PausarAudio(1);
                controlAudios.ReproducirAudio(2);
            }

        }
       if (duracionTotal <= 20f) // 00:20 es solNoche
        {
            treintaycinco.SetActive(false);       
            cuarenta.SetActive(false);     
            solTarde.SetActive(false);
            fondoDia.SetActive(false);

            treintaydos.SetActive(true);
            fondoNoche.SetActive(true);
            solNoche.SetActive(true);
            
        }
        if(duracionTotal == 18f){ // aparecen dialogos
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
           if(interactuar.microondasOn == false){
                //Resto puntos por no cocinar
                Puntos.puntos -= 5f;
           }
           if(interactuar.aspiradoraOn == false){
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
