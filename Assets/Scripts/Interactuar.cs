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
    public TextMeshProUGUI  puntosElectricosTexto;
    public float puntosElectricos;

    private Dialogos dialogos;
    private ControlarLuces controlarLuces;

    private ControladorAudios controlAudios;
    private Temporizador temporizador;

    private CameraSequenceController camSeqController;
    private ControladorCamaras controladorCamaras;
              

    void Start()
    {
        dialogos = FindObjectOfType<Dialogos>(); // Encuentra el objeto con el script Dialogos
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
        puntosElectricosTexto.text = "Puntos Electricos: " + puntosElectricos.ToString();
        Debug.Log("Puntos electricos: "+puntosElectricos);
        //Se produce corte electrico
        if (puntosElectricos>=10){
               Puntos.puntos = 0;
            
       //     camSeqController.InitSequence();
        }
    }
    public void Accionar(){
        Debug.Log("accionar llamado");
  
        if(esCompu){             
            computadoraOn =! computadoraOn; 
            Debug.Log("compu: " + computadoraOn);     
            ModificarPuntos();
            dialogos.desactivarComputadora();
            controlarLuces.desactivarLuces("monitor"); 
            controlarLuces.desactivarLuces("gabinete");
            //controlarAudio();
           
        }
        if(esMicroondas){         
            microondasOn =! microondasOn;     
            Debug.Log("microondas");     
            ModificarPuntos();
            dialogos.desactivarMicroondas();
            controlarLuces.desactivarLuces("microondas"); 
        }
        if(esLavarropas){              
            lavarropasOn =! lavarropasOn;
            Debug.Log("lavarropas: " + lavarropasOn);     
            ModificarPuntos();
            dialogos.desactivarLavarropas(); 
            controlarLuces.desactivarLuces("lavarropas"); 
        }
        if(esAire){            
            aireOn =! aireOn;  
            Debug.Log("aire");     
            ModificarPuntos();
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
            ModificarPuntos();
            dialogos.desactivarAspiradora();
            controlarLuces.desactivarLuces("aspiradora"); 
        }
        if(esVentilador){  
            ventiladorOn =! ventiladorOn;            
            Debug.Log("ventilador");     
            ModificarPuntos();
            dialogos.desactivarAspiradora();
            controlarLuces.desactivarLuces("ventilador"); 
        }
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
    void controlarAudio(){
        if(computadoraOn)
        {
          //   controlAudios.ReproducirAudio(3);
        }
        else {
            //    controlAudios.PausarAudio(3);
        }
       

    }
    
    void sumar(float numero){
        puntosElectricos += numero;
        Debug.Log("Puntos electricos: "+puntosElectricos);
    }
    
    void restar(float numero){
        puntosElectricos -= numero;
        Debug.Log("Puntos electricos: "+puntosElectricos);
    }

    void ModificarPuntos(){
        OnOff = !OnOff;
        if(esCompu){        
            if(computadoraOn){
                puntosElectricos = puntosElectricos + 3f;
                Debug.Log("sumar pc");
            } else {
               puntosElectricos = puntosElectricos - 3f;
                Debug.Log("restar pc");
            }
        }
        if(esMicroondas){        
            if(microondasOn){
               puntosElectricos = puntosElectricos + 4f;
                Debug.Log("sumar microondas");
            } else {
               puntosElectricos = puntosElectricos - 3f;
                Debug.Log("restar microondas");
            }
        }
        if(esLavarropas){        
            if(lavarropasOn){
                this.sumar(4);
                Debug.Log("sumar lavarropas");
            } else {
                this.restar(2);
                Debug.Log("restar lavarropas");
            }
        }
        if(esAire){        
            if(aireOn){
                this.sumar(5);
                Puntos.puntos +=5;
                Debug.Log("sumar aire");
            } else {
                this.restar(5);
                Puntos.puntos -=5;
                Debug.Log("restar aire");
            }
        }
        if(esVentilador){        
            if(ventiladorOn){
                this.sumar(2);
                Puntos.puntos +=2;
                Debug.Log("sumar ventilador");
            } else {
                this.restar(2);
                Puntos.puntos -=2;
                Debug.Log("restar ventilador");
            }
        }
        if(esAspiradora){        
            if(aspiradoraOn == true){
                this.sumar(4);
                Debug.Log("sumar aspiradora");
            }
            if(aspiradoraOn == false){
                this.restar(4);
                Debug.Log("restar aspiradora");
            }
        }


        

    } 
}