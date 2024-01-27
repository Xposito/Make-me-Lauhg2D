using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SceneConfiguration", menuName = "ScriptableObjects/Scene/SceneConfiguration")]
public class SCO_SceneManager : ScriptableObject
{

    [Header("Slider")]
    public float timer;
    //Este numero NO puede ser menor 0 o menor.
    public float timerSpeed;

    [Header("Requisitos")]
    public bool patito;
    public bool cajitaMusica;
    public bool confeti;

    public bool beanLisa;
    public bool beanRallada;
    public bool beanPuntos;
    public bool beanEstrellas;

    [Header("NivelCaracterísticas")]
    public float tiempoNivel;
    public float tiempoSpawnLacayos;
    public float tiempoSpawnChistes;
    public float probalidadSpawnbeanLisa;
    public float probalidadSpawnbeanRallada;
    public float probalidadSpawnbeanPuntos;
    public float probalidadSpawnbeanEstrellada;
    public float probabilidadLacayo1;
    public float probabilidadLacayo2;
    public float probabilidadLacayo3;
    public float probabilidadLacayo4;


    
    





    public float TimerSpeed
    {
        get { return timerSpeed; }
    }
    


}
