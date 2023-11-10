using TMPro;
using UnityEngine;
public class Interactuar : MonoBehaviour
{
  //  public GameObject luzObjeto;
    public bool luz;
    public bool esCompu;
    public bool esMicroondas;
    public bool esAire;
    public bool esLavarropas;
    public bool esAspiradora;
    public bool esVentilador;
    private bool luzOnOff;
    private bool OnOff; 
    public bool aireOn;
    public bool microondasOn;
    public bool lavarropasOn;
    public bool aspiradoraOn;
    public bool ventiladorOn;
    public bool computadoraOn;

    private Dialogos dialogos;
    private ControlarLuces controlarLuces;

    private ControladorAudios controlAudios;
    private Temporizador temporizador;
    private PuntosElectricos puntosE;

    private CameraSequenceController camSeqController;
    private ControladorCamaras controladorCamaras;

    public bool on;
              

    void Start()
    {
        dialogos = FindObjectOfType<Dialogos>(); // Encuentra el objeto con el script Dialogos
        puntosE = FindObjectOfType<PuntosElectricos>(); // Encuentra el objeto con el script PuntosElectricos
        controlarLuces = FindObjectOfType<ControlarLuces>(); // Encuentra el objeto con el script ControlarLuces
      //  cambiarEscenas = FindObjectOfType<CambiarEscenas>(); // Encuentra el objeto con el script CambiarEscenas
        temporizador = FindObjectOfType<Temporizador>(); // Encuentra el objeto con el script ControlarLuces
        camSeqController = FindObjectOfType<CameraSequenceController>();
        controladorCamaras = FindObjectOfType<ControladorCamaras>();
       // controlAudios = FindObjectOfType<ControladorAudios>();
       
        aireOn= false;      
    }

    // Update is called once per frame
    void Update()
    {
        //Se produce corte electrico
        if (PuntosElectricos.puntosElectricos>=10){
               Puntos.puntos = 0;
            
       //     camSeqController.InitSequence();
        }
    }
    public void Accionar(){
  
        if(esCompu){         
            on = true;      
            puntosE.sumarPuntos(3);    
            computadoraOn =! computadoraOn; 
            dialogos.desactivarComputadora();
            controlarLuces.desactivarLuces("monitor"); 
            controlarLuces.desactivarLuces("gabinete");          
        }
        if(esMicroondas){         
            on = true;      
            puntosE.sumarPuntos(4); 
            microondasOn =! microondasOn;     
            dialogos.desactivarMicroondas();
            controlarLuces.desactivarLuces("microondas"); 
        }
        /*
        if(esLavarropas){              
            lavarropasOn =! lavarropasOn;
            Debug.Log("lavarropas: " + lavarropasOn);     
            modificarLavarropas();
            dialogos.desactivarLavarropas(); 
            controlarLuces.desactivarLuces("lavarropas"); 
        }
        if(esAire){            
            aireOn =! aireOn;  
            Debug.Log("aire");     
            modificarAire();
            dialogos.desactivarAire();
            controlarLuces.desactivarLuces("aire");
            if(aireOn){
                temporizador.disminuirTemperatura();                
            } 
         //   controlarAudio();
         //controlAudios.seleccionAudio(3, 0.5f); // Arreglo del audio, posicion 3.
        }
        if(esAspiradora){    
            aspiradoraOn =! aspiradoraOn;          
            Debug.Log("aspiradora");     
            modificarAspiradora();
            dialogos.desactivarAspiradora();
            controlarLuces.desactivarLuces("aspiradora"); 
        }
        if(esVentilador){  
            ventiladorOn =! ventiladorOn;            
            Debug.Log("ventilador");     
            modificarVentilador();
            dialogos.desactivarAspiradora();
            controlarLuces.desactivarLuces("ventilador"); 
        } */
    }
/*
    void OnOffLuz(){
        luzOnOff = !luzOnOff;
        if(luzOnOff == true){
            luzObjeto.SetActive(true);
        }
        if(luzOnOff == false){
            luzObjeto.SetActive(false);
        }
    }
    */

    void modificarCompu(){
      
            if(computadoraOn){
                PuntosElectricos.puntosElectricos = PuntosElectricos.puntosElectricos + 3f;
                Debug.Log("sumar pc");
            } else {
               PuntosElectricos.puntosElectricos = PuntosElectricos.puntosElectricos - 2f;
                Debug.Log("restar pc");
            }

    }
    /*
    void modificarMicroondas(){       
            if(microondasOn){
               puntosElectricos = puntosElectricos + 4f;
                Debug.Log("sumar microondas");
            } else {
               puntosElectricos = puntosElectricos - 3f;
                Debug.Log("restar microondas");
            }

    }

    void modificarLavarropas(){      
            if(lavarropasOn){
                puntosElectricos = puntosElectricos + 4f;
                Debug.Log("sumar lavarropas");
            } else {
                puntosElectricos = puntosElectricos - 3f;
                Debug.Log("restar lavarropas");
            }
    }

    void modificarAire(){    
            if(aireOn){
                puntosElectricos = puntosElectricos + 5f;
                Puntos.puntos +=5;
                Debug.Log("sumar aire");
            } else {
                puntosElectricos = puntosElectricos - 4f;
                Puntos.puntos -=5;
                Debug.Log("restar aire");
            }
    }

    void modificarVentilador(){
               
            if(ventiladorOn){
                puntosElectricos = puntosElectricos + 2f;
                Puntos.puntos +=2;
                Debug.Log("sumar ventilador");
            } else {
                puntosElectricos = puntosElectricos - 2f;
                Puntos.puntos -=2;
                Debug.Log("restar ventilador");
            }
    }

    void modificarAspiradora(){
               
            if(aspiradoraOn == true){
                puntosElectricos = puntosElectricos + 4f;
                Debug.Log("sumar aspiradora");
            }
            if(aspiradoraOn == false){
                puntosElectricos = puntosElectricos - 3f;
                Debug.Log("restar aspiradora");
            }
        
    } */
}