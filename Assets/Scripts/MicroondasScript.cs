using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroondasScript : MonoBehaviour
{
    public bool esMicroondas;
    private bool OnOff; 
    public GameObject microondas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Accionar(){
        Debug.Log("accionar llamado");

        if(esMicroondas){
            Debug.Log("por llamar a modificar puntos");     
            ModificarPuntos();
            microondas.SetActive(false);
         //   ReproducirSonido("televisor");
        }

    }
    
    void ModificarPuntos(){
        Debug.Log("ModificarPuntos() llamado");
        Debug.Log(OnOff);
        OnOff = !OnOff;
        if(OnOff == true){
             Puntos.puntos += 3f;
           //  ReproducirSonido("televisor");
             Debug.Log("clickeado");
        }
        if(OnOff == false){
             Puntos.puntos -= 3f;
        }
    }

}
