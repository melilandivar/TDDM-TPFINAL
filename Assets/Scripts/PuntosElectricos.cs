using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PuntosElectricos : MonoBehaviour
{
    
    public static float puntosElectricos;
    public TextMeshProUGUI  puntosElectricosTexto;
    private bool on;
    private Interactuar interactuar;
    //Aca irian los hud electricos
    void Start()
    {
        interactuar = FindObjectOfType<Interactuar>();
    }

    // Update is called once per frame
    void Update()
    {
        puntosElectricosTexto.text = "Puntos Electricos: " + puntosElectricos.ToString();
        if (puntosElectricos >= 7f && puntosElectricos <= 10f ){
         //   Confortable.SetActive(true);
         //   Debug.Log("Confortable. puntosElectricos: " + puntosElectricos);
        }
        if (puntosElectricos >= 4f && puntosElectricos <= 7f ){
           // Confortable.SetActive(false);
          //  Alarmante.SetActive(true);
        //    Debug.Log("Alarmante. puntosElectricos: " + puntosElectricos);
        }
        if (puntosElectricos >= 0f && puntosElectricos <= 4f ){
            //Alarmante.SetActive(false);
            //Crisis.SetActive(true);
          //  Debug.Log("Confortable. puntosElectricos: " + puntosElectricos);
        }
    }

    public void sumarPuntos(float numero){
        Debug.Log(interactuar.on);
        if(interactuar.on){
        puntosElectricos = puntosElectricos + numero;
        Debug.Log(puntosElectricos);
        } else {
            puntosElectricos = puntosElectricos - numero;
        }
        interactuar.on = !interactuar.on;

    }
}
