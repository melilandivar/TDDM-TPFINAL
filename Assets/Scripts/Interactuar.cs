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

    private float puntosElectricos;

    private Dialogos dialogos;
    private ControlarLuces controlarLuces;
    void Start()
    {
        dialogos = FindObjectOfType<Dialogos>(); // Encuentra el objeto con el script Dialogos
        controlarLuces = FindObjectOfType<ControlarLuces>(); // Encuentra el objeto con el script ControlarLuces
        puntosElectricos = 0f;
    }

    // Update is called once per frame
    void Update()
    {
   // Debug.Log(compu);
    }
    public void Accionar(){
       // Debug.Log("accionar llamado");
        if(luz){
      //      OnOffLuz();
        }
        if(esCompu){              
            Debug.Log("compu");     
            ModificarPuntos();
            dialogos.desactivarComputadora();
            controlarLuces.desactivarLuces("monitor"); 
            controlarLuces.desactivarLuces("gabinete"); 
        }
        if(esMicroondas){              
            Debug.Log("microondas");     
            ModificarPuntos();
            dialogos.desactivarMicroondas();
            controlarLuces.desactivarLuces("microondas"); 
        }
        if(esLavarropas){              
            Debug.Log("lavarropas");     
            ModificarPuntos();
            dialogos.desactivarLavarropas(); 
            controlarLuces.desactivarLuces("lavarropas"); 
        }
        if(esAire){              
            Debug.Log("aire");     
            ModificarPuntos();
            dialogos.desactivarAire();
            controlarLuces.desactivarLuces("aire"); 
        }
        if(esAspiradora){              
            Debug.Log("aspiradora");     
            ModificarPuntos();
            dialogos.desactivarAspiradora();
            controlarLuces.desactivarLuces("aspiradora"); 
        }
        if(esVentilador){              
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
    void ReproducirSonido(string nombreAudio)
    {
        GameObject audioObjeto = GameObject.Find(nombreAudio);
        Debug.Log(audioObjeto);
        if (audioObjeto != null)
        {
            AudioSource audioSource = audioObjeto.GetComponent<AudioSource>();
            if (audioSource != null)
            {
              
                    audioSource.Play();
            }
            else
            {
                Debug.LogWarning("El objeto de audio no tiene un componente AudioSource.");
            }
        }
        else
        {
            Debug.LogWarning("Objeto de audio no encontrado: " + nombreAudio);
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