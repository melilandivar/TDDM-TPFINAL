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
    private float puntosElectricos;

    private Dialogos dialogos;
    private ControlarLuces controlarLuces;

    private ControladorAudios controlAudios;
    private Temporizador temporizador;

    private CameraSequenceController camSeqController;

    private void Awake()
    {
        controlAudios = FindObjectOfType<ControladorAudios>();
    }

    void Start()
    {
        dialogos = FindObjectOfType<Dialogos>(); // Encuentra el objeto con el script Dialogos
        controlarLuces = FindObjectOfType<ControlarLuces>(); // Encuentra el objeto con el script ControlarLuces
        temporizador = FindObjectOfType<Temporizador>(); // Encuentra el objeto con el script ControlarLuces
        camSeqController = FindObjectOfType<CameraSequenceController>();
        puntosElectricos = 0f;
        aireOn= false;
    }

    // Update is called once per frame
    void Update()
    {
        //Se produce corte electrico
        if(puntosElectricos>=10){
            //   puntos = 0;
            Debug.Log("init sequence");
            camSeqController.InitSequence();
        }
    }
    public void Accionar(){
       // Debug.Log("accionar llamado");
        if(luz){
      //      OnOffLuz();
        }
        if(esCompu){             
            computadoraOn =! computadoraOn; 
            Debug.Log("compu");     
            ModificarPuntos();
            dialogos.desactivarComputadora();
            controlarLuces.desactivarLuces("monitor"); 
            controlarLuces.desactivarLuces("gabinete"); 
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
            Debug.Log("lavarropas");     
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
        //    controlAudios.seleccionAudio(3, 0.5f); // Arreglo del audio, posicion 3.
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
        if(aireOn){
           // controlAudios.seleccionAudio(3, 0.5f); // Arreglo del audio, posicion 3.
        } else {
        //    controlAudios.PausarAudio(3); // Arreglo del audio, posicion 3.
        }
           
        
    }
    
    void sumar(float numero){
        puntosElectricos += numero;
    }
    
    void restar(float numero){
        puntosElectricos -= numero;
    }

    void ModificarPuntos(){
        OnOff = !OnOff;
        if(esCompu){        
            if(OnOff == true){
                this.sumar(3);
                Debug.Log("sumar pc");
           //     ReproducirSonido("PcSound");
            }
            if(OnOff == false){
                this.restar(3);
                Debug.Log("restar pc");
            }
        }
        if(esMicroondas){        
            if(OnOff == true){
                this.sumar(4);
                Debug.Log("sumar microondas");
            }
            if(OnOff == false){
                this.restar(4);
                Debug.Log("restar microondas");
            }
        }
        if(esLavarropas){        
            if(OnOff == true){
                this.sumar(4);
                Debug.Log("sumar lavarropas");
            }
            if(OnOff == false){
                this.restar(2);
                Debug.Log("restar lavarropas");
            }
        }
        if(esAire){        
            if(OnOff == true){
                this.sumar(5);
                Debug.Log("sumar aire");
            }
            if(OnOff == false){
                this.restar(5);
                Debug.Log("restar aire");
            }
        }
        if(esAspiradora){        
            if(OnOff == true){
                this.sumar(4);
                Debug.Log("sumar aspiradora");
            }
            if(OnOff == false){
                this.restar(4);
                Debug.Log("restar aspiradora");
            }
        }


        

    } 
}