using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaludJugador : MonoBehaviour
{
    // Variables de salud
    int saludMaxima = 100;
    public int saludActual;
    public BarraDeVida barraDeVidaScript;
    


    void Awake()
    {
        barraDeVidaScript = GetComponent<BarraDeVida>();
    }
    void Start()
    {
        saludActual = saludMaxima;
        barraDeVidaScript.ActualizarBarraDevida(saludActual);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RecibirDanio(int danio)
    {
        saludActual -= danio;
        if (saludActual <= 0)
        {
            saludActual = 0;
            Morir();
        }
        barraDeVidaScript.ActualizarBarraDevida(saludActual);
    }

    private void Morir()
    {
        throw new NotImplementedException();
    }

   
}
