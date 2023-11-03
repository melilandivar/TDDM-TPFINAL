using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogos : MonoBehaviour
{
    public GameObject aire;
    public GameObject computadora;
    public GameObject microondas;
    public GameObject lavarropas;
    public GameObject aspiradora;
    public GameObject ventilador;
    
    void Start()
    {
        computadora.SetActive(false);
        lavarropas.SetActive(false);
        aire.SetActive(false);
        microondas.SetActive(false);
        aspiradora.SetActive(false);
        ventilador.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void activarAire(){
        aire.SetActive(true);
    }
     public void activarComputadora(){
         Debug.Log(computadora);
        computadora.SetActive(true);
    }
     public void activarMicroondas(){
        microondas.SetActive(true);
    }
     public void activarLavarropas(){
        lavarropas.SetActive(true);
    }
    public void activarAspiradora(){
        aspiradora.SetActive(true);
    }
    public void activarVentilador(){
        ventilador.SetActive(true);
    }
      public void desactivarAire(){
        aire.SetActive(false);
    }
       public  void desactivarComputadora(){
        computadora.SetActive(false);
    }
      public void desactivarMicroondas(){
        microondas.SetActive(false);
    }
      public void desactivarLavarropas(){
        lavarropas.SetActive(false);
    }
    public void desactivarAspiradora(){
        aspiradora.SetActive(false);
    }
    public void desactivarVentilador(){
        ventilador.SetActive(false);
    }
}
