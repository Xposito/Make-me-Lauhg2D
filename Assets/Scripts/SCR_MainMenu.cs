using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class SCR_MainMenu : MonoBehaviour
{
    SCR_Holder holder;

    public GameObject calendario;
    public GameObject requisito;
    Button boton;

    private void Start()
    {
        holder = GameObject.FindGameObjectWithTag("GameController").GetComponent<SCR_Holder>();
    }
    public void PlayCuaderno()
    {
        
        calendario.GetComponent<VideoPlayer>().Play();
    }

    public void Dia1()
    {
        calendario.SetActive(false);
        holder.sceneManager = holder.choseSceneManager[0];
        holder.sceneManager.startTime = true;
        holder.sceneManager.stopTime = true;
        requisito.SetActive(true);

    }
}
