using UnityEngine;
public class Interactuar : MonoBehaviour
{
  //  public GameObject luzObjeto;
    public bool luz;
    public bool esCompu;
    public bool esMicroondas;
    public bool esAire;
    public bool esLavarropas;
    private bool luzOnOff;
    private bool OnOff; 
    void Start()
    {

        
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
        }
        if(esMicroondas){              
            Debug.Log("microondas");     
            ModificarPuntos();
        }
        if(esLavarropas){              
            Debug.Log("lavarropas");     
            ModificarPuntos();
        }
        if(esAire){              
            Debug.Log("aire");     
            ModificarPuntos();
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
        OnOff = !OnOff;
        GameObject audioObjeto = GameObject.Find(nombreAudio);
        if (audioObjeto != null)
        {
            AudioSource audioSource = audioObjeto.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                if (OnOff)
                {
                    audioSource.Play();
                }
                else
                {
                    audioSource.Stop();
                }
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

    void ModificarPuntos(){
        OnOff = !OnOff;
        if(OnOff == true){
             Puntos.puntos -= 3f;
         //    ReproducirSonido("televisor");
             Debug.Log("sumar");
        }
        if(OnOff == false){
             Puntos.puntos -= 3f;
             Debug.Log("restar");
        }
    } 
}