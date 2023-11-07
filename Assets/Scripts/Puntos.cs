using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntos : MonoBehaviour
{
    public static float puntos; 
    public GameObject Confortable;
    public GameObject Alarmante;
    public GameObject Crisis;

    void Start()
    {
        Confortable.SetActive(false);
        Alarmante.SetActive(false);
        Crisis.SetActive(false);
        
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
      //  Debug.Log("Puntos: "+puntos);
        if (puntos >= 7f && puntos <= 10f ){
            Confortable.SetActive(true);
         //   Debug.Log("Confortable. Puntos: " + puntos);
        }
        if (puntos >= 4f && puntos <= 7f ){
            Confortable.SetActive(false);
            Alarmante.SetActive(true);
        //    Debug.Log("Alarmante. Puntos: " + puntos);
        }
        if (puntos >= 0f && puntos <= 4f ){
            Alarmante.SetActive(false);
            Crisis.SetActive(true);
          //  Debug.Log("Confortable. Puntos: " + puntos);
        }
    }
}
