using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Holder : MonoBehaviour
{
    //Este Script se utiliza para meter el scriptable Object que se necesita, no se tiene porque rellenar todas las variables

    public SCO_Object_Configuration object_Configuration;
    public SCO_Bean_Data bean_Data;
    public SCO_SceneManager sceneManager;
    public SCO_Chistes chistes_Data;

    public bool manager;

    public SCO_SceneManager[] choseSceneManager; //Setea todas las característas porcentajes del día


    private void Awake()
    {
        if (manager)
        {
            sceneManager = choseSceneManager[0];
        }
    }
}
