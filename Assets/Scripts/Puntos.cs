using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntos : MonoBehaviour
{
    public static float puntos; 
    public GameObject hombreNormal;
    public GameObject hombreAlarmante;
    public GameObject hombreCrisis;
    public GameObject mujerNormal;
    public GameObject mujerAlarmante;
    public GameObject mujerCrisis;
    void Start()
    {
        hombreNormal.SetActive(false);
        mujerNormal.SetActive(false);
        hombreAlarmante.SetActive(false);
        mujerAlarmante.SetActive(false);
        hombreCrisis.SetActive(false);
        mujerCrisis.SetActive(false);
        
    }

    void Update()
    {
        actualizarEstadoAnimo();
        if(puntos<0f){
            puntos=0f;
        }
    }

    void actualizarEstadoAnimo()
    {
        Debug.Log("Puntos: "+puntos);
        if (puntos >= 7f && puntos <= 10f ){
            hombreNormal.SetActive(true);
            mujerNormal.SetActive(true);
            Debug.Log("Confortable. Puntos: " + puntos);
        }
        if (puntos >= 4f && puntos <= 7f ){
            hombreNormal.SetActive(false);
            mujerNormal.SetActive(false);
            hombreAlarmante.SetActive(true);
            mujerAlarmante.SetActive(true);
        //    Debug.Log("Alarmante. Puntos: " + puntos);
        }
        if (puntos >= 0f && puntos <= 4f ){
            hombreAlarmante.SetActive(false);
            mujerAlarmante.SetActive(false);
            hombreCrisis.SetActive(true);
            mujerCrisis.SetActive(true);
          //  Debug.Log("Confortable. Puntos: " + puntos);
        }
    }
}
