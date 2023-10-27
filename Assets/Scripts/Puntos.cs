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
    }

    void actualizarEstadoAnimo()
    {
    //    Debug.Log(puntos);
        if (puntos >= 7 && puntos <= 10 )
        {
            Confortable.SetActive(true);
            Debug.Log("Confortable");
        }
        if (puntos >= 4 && puntos <= 7 )
        {
            Confortable.SetActive(false);
            Alarmante.SetActive(true);
    //        Debug.Log("Alarmante");
        }
        if (puntos >= 0 && puntos <= 4 )
        {
            Alarmante.SetActive(false);
            Crisis.SetActive(true);
      //      Debug.Log("Crisis");
        }
    }
}
