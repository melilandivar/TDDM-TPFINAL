using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCamaras : MonoBehaviour
{
    public GameObject camaraPrincipal;
    public GameObject camaraAire;
    public GameObject camaraLavarropas;
    public GameObject camaraAspiradora;
    public GameObject camaraMicroondas;
    public GameObject camaraLuz;
    public GameObject camaraPc;
    public GameObject chispasAire;
        
    private Interactuar interactuar;

    void Start()
    {

        interactuar = FindObjectOfType<Interactuar>();
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void activarCamaras(){
        chispasAire.SetActive(true);
        camaraAire.SetActive(true);
        camaraPrincipal.SetActive(false);
    }
    public void desactivarCamaras(){
        chispasAire.SetActive(false);
        camaraAire.SetActive(false);
        camaraPrincipal.SetActive(true);
    }
}
