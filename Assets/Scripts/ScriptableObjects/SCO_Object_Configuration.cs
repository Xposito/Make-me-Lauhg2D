using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SceneConfiguration", menuName = "ScriptableObjects/Objects/ObjectData")]
public class SCO_Object_Configuration : ScriptableObject
{
    public int ID;

    public float ValorSlide;
    public bool Used;
}
