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

    public bool patito;
    public bool cajitaMusica;
    public bool confeti;

    public bool beanLisa;
    public bool beanRallada;
    public bool beanPuntos;
    public bool beanEstrellas;
    
    





    public float TimerSpeed
    {
        get { return timerSpeed; }
    }
    


}
