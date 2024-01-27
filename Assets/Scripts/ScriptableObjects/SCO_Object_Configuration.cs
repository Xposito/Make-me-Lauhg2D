using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SceneConfiguration", menuName = "ScriptableObjects/Objects/ObjectData")]
public class SCO_Object_Configuration : ScriptableObject
{
    //Es el SCO que lleva la diferenciación de los Objetos
    public int ID;

    public float valorSlide;
    public float scaleTime;
    public bool Used;
}
