using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlarLuces : MonoBehaviour
{
    public GameObject monitorLuz;
    public GameObject gabineteLuz;
    public GameObject aireLuz;
    public GameObject microondasLuz;
    public GameObject lavarropasLuz;
    public GameObject ventiladorLuz;
    // Start is called before the first frame update
    void Start()
    {

        monitorLuz.SetActive(false);
        gabineteLuz.SetActive(false);
        aireLuz.SetActive(false);
        microondasLuz.SetActive(false);
        lavarropasLuz.SetActive(false);
        ventiladorLuz.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activarLuces(string objeto){
        if(objeto == "monitor"){
            monitorLuz.SetActive(true);
        }
        if(objeto == "gabinete"){
            gabineteLuz.SetActive(true);
        }
        if(objeto == "aire"){
            aireLuz.SetActive(true);
        }
        if(objeto == "microondas"){
            microondasLuz.SetActive(true);
        }
        if(objeto == "lavarropas"){
            lavarropasLuz.SetActive(true);
        }
        if(objeto == "ventilador"){
           ventiladorLuz.SetActive(true);
        }
    }
    public void desactivarLuces(string objeto){
        if(objeto == "monitor"){
            monitorLuz.SetActive(false);
        }
        if(objeto == "gabinete"){
            gabineteLuz.SetActive(false);
        }
        if(objeto == "aire"){
            aireLuz.SetActive(false);
        }
        if(objeto == "microondas"){
            microondasLuz.SetActive(false);
        }
        if(objeto == "lavarropas"){
            lavarropasLuz.SetActive(false);
        }
        if(objeto == "ventilador"){
           ventiladorLuz.SetActive(false);
        }
    }
}
