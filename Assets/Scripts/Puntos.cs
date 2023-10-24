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
        if (puntos >= 7)
        {
            Confortable.SetActive(true);
        }
        else if (puntos >= 4)
        {
            Confortable.SetActive(false);
            Alarmante.SetActive(true);
        }
        else
        {
            Alarmante.SetActive(false);
            Crisis.SetActive(true);
        }
    }
}
