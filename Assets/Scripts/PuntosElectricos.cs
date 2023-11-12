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
    public GameObject medidorNormal;
    public GameObject medidorAlarmante;
    public GameObject medidorCrisis;
    public CambiarEscenas cambiarEscenas;
    public bool cambiarCamara;
    //Aca irian los hud electricos
    void Start()
    {
        interactuar = FindObjectOfType<Interactuar>();
        cambiarEscenas = FindObjectOfType<CambiarEscenas>();
    }

    // Update is called once per frame
    void Update()
    {
        puntosElectricosTexto.text = "Puntos Electricos: " + puntosElectricos.ToString();
        Debug.Log("Puntos e:" + puntosElectricos);
        if (puntosElectricos >= 7f && puntosElectricos <= 10f ){
            medidorCrisis.SetActive(true);
            medidorAlarmante.SetActive(false);
            medidorNormal.SetActive(false);
        }
        if (puntosElectricos >= 4f && puntosElectricos <= 7f ){
            medidorCrisis.SetActive(false);
            medidorAlarmante.SetActive(true);
            medidorNormal.SetActive(false);
        }
        if (puntosElectricos >= 0f && puntosElectricos <= 4f ){
            medidorCrisis.SetActive(false);
            medidorAlarmante.SetActive(false);
            medidorNormal.SetActive(true);
        }
        //Corte de luz
        if (puntosElectricos >= 10f){
            cambiarEscenas.CargarEscena("SecuenciaCamaras");
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