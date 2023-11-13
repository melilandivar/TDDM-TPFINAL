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
    public bool camaraCerca;
    private Dialogos dialogos;
    private ControlarLuces controlarLuces;

    private ControladorAudios controlAudios;
    private Temporizador temporizador;
    private PuntosElectricos puntosE;

    private CameraSequenceController camSeqController;
    private ControladorCamaras controladorCamaras;
    private CamaraElementos camaraElementos;

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
        camaraElementos = FindObjectOfType<CamaraElementos>();
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
            computadoraOn =! computadoraOn; 
            dialogos.desactivarComputadora();
            controlarLuces.desactivarLuces("monitor"); 
            controlarLuces.desactivarLuces("gabinete");  
            modificarCompu();  
            camaraElementos.acercarCamara("computadora");      
        }
        if(esMicroondas){   
            microondasOn =! microondasOn;     
            dialogos.desactivarMicroondas();
            controlarLuces.desactivarLuces("microondas"); 
            modificarMicroondas();
            camaraElementos.acercarCamara("microondas");
        }
    
        if(esLavarropas){              
            lavarropasOn =! lavarropasOn;    
            modificarLavarropas();
            dialogos.desactivarLavarropas(); 
            controlarLuces.desactivarLuces("lavarropas"); 
            camaraElementos.acercarCamara("lavarropas");
        }
        if(esAire){            
            aireOn =! aireOn;      
            modificarAire();
            dialogos.desactivarAire();
            controlarLuces.desactivarLuces("aire");
            camaraElementos.acercarCamara("aire");
            if(aireOn){
                temporizador.disminuirTemperatura();                
            } 
         //   controlarAudio();
         //controlAudios.seleccionAudio(3, 0.5f); // Arreglo del audio, posicion 3.
        }
        if(esAspiradora){    
            aspiradoraOn =! aspiradoraOn; 
            modificarAspiradora();
            dialogos.desactivarAspiradora();
            controlarLuces.desactivarLuces("aspiradora"); 
            camaraElementos.acercarCamara("aspiradora");
        }
        if(esVentilador){  
            ventiladorOn =! ventiladorOn; 
            modificarVentilador();
            dialogos.desactivarVentilador();
            controlarLuces.desactivarLuces("ventilador"); 
            camaraElementos.acercarCamara("ventilador");
        } 
    }

    public void llamarAcercarCamara(string objeto){
        camaraElementos.DesactivarZoom();
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
    void modificarMicroondas(){       
            if(microondasOn){
               PuntosElectricos.puntosElectricos = PuntosElectricos.puntosElectricos + 4f;
                Debug.Log("sumar microondas");
            } else {
               PuntosElectricos.puntosElectricos = PuntosElectricos.puntosElectricos - 3f;
                Debug.Log("restar microondas");
            }

    }

    void modificarLavarropas(){      
            if(lavarropasOn){
                PuntosElectricos.puntosElectricos = PuntosElectricos.puntosElectricos + 4f;
                Debug.Log("sumar lavarropas");
            } else {
                PuntosElectricos.puntosElectricos = PuntosElectricos.puntosElectricos - 3f;
                Debug.Log("restar lavarropas");
            }
    }

    void modificarAire(){    
            if(aireOn){
                PuntosElectricos.puntosElectricos = PuntosElectricos.puntosElectricos + 5f;
                Puntos.puntos +=5;
                Debug.Log("sumar aire");
            } else {
                PuntosElectricos.puntosElectricos = PuntosElectricos.puntosElectricos - 4f;
                Puntos.puntos -=5;
                Debug.Log("restar aire");
            }
    }

    void modificarVentilador(){
               
            if(ventiladorOn){
                PuntosElectricos.puntosElectricos = PuntosElectricos.puntosElectricos + 2f;
                Puntos.puntos +=2;
                Debug.Log("sumar ventilador");
            } else {
                PuntosElectricos.puntosElectricos = PuntosElectricos.puntosElectricos - 2f;
                Puntos.puntos -=2;
                Debug.Log("restar ventilador");
            }
    }

    void modificarAspiradora(){
               
            if(aspiradoraOn == true){
                PuntosElectricos.puntosElectricos = PuntosElectricos.puntosElectricos + 4f;
                Debug.Log("sumar aspiradora");
            }
            if(aspiradoraOn == false){
                PuntosElectricos.puntosElectricos = PuntosElectricos.puntosElectricos - 3f;
                Debug.Log("restar aspiradora");
            }
        
    } 
}