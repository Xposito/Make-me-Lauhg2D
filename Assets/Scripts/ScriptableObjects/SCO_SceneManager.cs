using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SceneConfiguration", menuName = "ScriptableObjects/Scene/SceneConfiguration")]
public class SCO_SceneManager : ScriptableObject
{

    //El Script MÁS importante, es el que hace que los días sean diferentes, aquí se añade todo lo que tengan en común todos los niveles
    [Header("Slider")]
    public float timer; //El tiempo  que tarda en acabar si no es tocado
    //Este numero NO puede ser menor 0 o menor.
    public float timerSpeed; //Varía la velocidad del tiempo

    [Header("Requisitos")]
    public bool patito; 
    public bool cajitaMusica;
    public bool confeti;

    public bool beanLisa;
    public bool beanRallada;
    public bool beanPuntos;
    public bool beanEstrellas;

    public bool chistesPobreza;
    public bool chistesAnimales;
    public bool chistesAmor;
    public bool chistesRopa;

    public bool IsSombreroInScene;

    [Header("NivelCaracterísticas")]
    public float tiempoNivel;
    public float tiempoSpawnLacayos;
    public float tiempoSpawnChistes;
    public float tiempoSpawnSombrero;
    public float probalidadSpawnbeanLisa;
    public float probalidadSpawnbeanRallada;
    public float probalidadSpawnbeanPuntos;
    public float probalidadSpawnbeanEstrellada;
    public float probabilidadLacayo1;
    public float probabilidadLacayo2;
    public float probabilidadLacayo3;
    public float probabilidadLacayo4;
    public float probabilidadSpawnSombrero;
    public float probabilidadSpawnSombrero1;
    public float probabilidadSpawnSombrero2;
    public float probabilidadSpawnSombrero3;
    public float probabilidadSpawnChistePobreza;
    public float probabilidadSpawnChisteAnimales;
    public float probabilidadSpawnChisteAmor;
    public float probabilidadSpawnChisteRopa;
    public int tiempoVidaChistes;
    public int tiempoVidaLacayos;

    [Header("Controlador")]
    public bool stopTime;
    public bool startTime;
    public bool confetiUsed;


   





    //Se utiliza para no cambiar directamente la velocidad es solo de lectura
    public float TimerSpeed
    {
        get { return timerSpeed; }
    }
    


}
