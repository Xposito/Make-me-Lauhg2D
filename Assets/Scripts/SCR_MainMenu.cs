using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class SCR_MainMenu : MonoBehaviour
{
    SCR_Holder holder;
    SCR_SliderControler sliderControler;

    public GameObject calendario;
    public GameObject requisito;
    public GameObject FondoGameOver;
    public GameObject menuInicio;
    public GameObject[] botonesdeDías;
    public GameObject botonJugar;
    Button boton;

    private void Start()
    {
        holder = GameObject.FindGameObjectWithTag("GameController").GetComponent<SCR_Holder>();
        sliderControler = GameObject.FindGameObjectWithTag("GameController").GetComponent<SCR_SliderControler>();
    }
    public void PlayCuaderno()
    {
        botonJugar.SetActive(false);
        calendario.GetComponent<VideoPlayer>().Play();

        StartCoroutine(CuadernoYDías());
    }

    public void Dia1()
    {
        calendario.SetActive(false);
        holder.sceneManager = holder.choseSceneManager[0];
        holder.sceneManager.startTime = true;
        holder.sceneManager.stopTime = true;
        requisito.SetActive(true);
        menuInicio.SetActive(false);
        botonJugar.SetActive(true);
        sliderControler.InicioJuego();
        for (int i = 0; i < botonesdeDías.Length; i++)
        {
            botonesdeDías[i].SetActive(false);
        }

    }

    public void Reiniciar()
    {
        FondoGameOver.SetActive(false);
        holder.sceneManager.startTime = true;
        holder.sceneManager.stopTime = false;
    }
    public void MenuInicio()
    {
        menuInicio.SetActive(true);
        sliderControler.InicioMenu();
        FondoGameOver.SetActive(false) ;
        calendario.SetActive(true);

    }
    IEnumerator CuadernoYDías()
    {
        yield return new WaitForSeconds(3f);

        for(int i = 0; i < botonesdeDías.Length; i++)
        {
            botonesdeDías[i].SetActive(true);
        }

    }
}
