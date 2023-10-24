using UnityEngine;
public class Interactuar : MonoBehaviour
{
    public GameObject luzObjeto;
    public bool luz;
    public bool tele;
    private bool luzOnOff;
    private bool OnOff; // Inicializado en true por defecto
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Accionar(){
        if(luz){
            OnOffLuz();
        }
        if(tele){
                    

            ReproducirSonido("televisor");
        }

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
}