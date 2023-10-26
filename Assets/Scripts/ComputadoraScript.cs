using UnityEngine;

public class ComputadoraScript : MonoBehaviour
{

    public GameObject Computadora;
    public bool esCompu;
    private bool OnOff;
    private bool sonidoOnOff;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     //   Debug.Log(Puntos.puntos);
    }

    public void Accionar(){
        Debug.Log("accionar llamado");

        if(esCompu){
            Debug.Log("por llamar a modificar puntos");     
            ModificarPuntos();
         //   ReproducirSonido("televisor");
        }

    }


    void ModificarPuntos(){
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
    }

    void ReproducirSonido(string nombreAudio)
    {
        sonidoOnOff = !sonidoOnOff;
        GameObject audioObjeto = GameObject.Find(nombreAudio);
        if (audioObjeto != null)
        {
            AudioSource audioSource = audioObjeto.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                if (sonidoOnOff)
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
