using UnityEngine;
public class Interactuar : MonoBehaviour
{
    public GameObject luzObjeto;
    public bool luz;
 //   public bool esCompu;
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
        Debug.Log("accionar llamado");
        if(luz){
            OnOffLuz();
        }
    /*    if(esCompu){              
            Debug.Log("por llamar a modificar puntos");     
            ModificarPuntos();
        }*/
    }

    void OnOffLuz(){
        luzOnOff = !luzOnOff;
        if(luzOnOff == true){
            luzObjeto.SetActive(true);
        }
        if(luzOnOff == false){
            luzObjeto.SetActive(false);
        }
    }
    
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

 /*   void ModificarPuntos(){
        Debug.Log("ModificarPuntos() llamado");
        Debug.Log(OnOff);
        OnOff = !OnOff;
        if(OnOff == true){
             Puntos.puntos += 3f;
             ReproducirSonido("televisor");
             Debug.Log("clickeado");
        }
        if(OnOff == false){
             Puntos.puntos -= 3f;
        }
    } */
}