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
    SCR_AudioManager audioManager;
    Manager manager;

    public GameObject calendario;
    
    public GameObject FondoGameOver;
    public GameObject menuInicio;
    public GameObject[] botonesdeDías;
    public GameObject[] requisitos;
    public GameObject botonJugar;
    public GameObject botonQuit;
    Button boton;

    private void Start()
    {
        
        audioManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SCR_AudioManager>();
        holder = GameObject.FindGameObjectWithTag("GameController").GetComponent<SCR_Holder>();
        sliderControler = GameObject.FindGameObjectWithTag("GameController").GetComponent<SCR_SliderControler>();
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<Manager>();
        audioManager.MusicaDeFondo();
    }
    public void PlayCuaderno()
    {
        audioManager.AudioLibro();
        botonJugar.SetActive(false);
        botonQuit.SetActive(false);
        calendario.GetComponent<VideoPlayer>().Play();
        

        StartCoroutine(CuadernoYDías());
    }

    public void Dia1()
    {
        requisitos[0].SetActive(false);
        audioManager.CambioDeCanción();
        calendario.SetActive(false);
        holder.sceneManager = holder.choseSceneManager[0];
        holder.sceneManager.startTime = true;
        holder.sceneManager.stopTime = true;
        
        menuInicio.SetActive(false);
        botonJugar.SetActive(true);
        botonQuit.SetActive(true);

        sliderControler.InicioJuego();
        for (int i = 0; i < botonesdeDías.Length; i++)
        {
            botonesdeDías[i].SetActive(false);
        }

    }
    public void Dia2()
    {
        requisitos[1].SetActive(false);
        audioManager.CambioDeCanción();
        calendario.SetActive(false);
        holder.sceneManager = holder.choseSceneManager[1];
        holder.sceneManager.startTime = true;
        holder.sceneManager.stopTime = true;
        
        menuInicio.SetActive(false);
        botonJugar.SetActive(true);
        sliderControler.InicioJuego();
        for (int i = 0; i < botonesdeDías.Length; i++)
        {
            botonesdeDías[i].SetActive(false);
        }

    }
    public void Dia3()
    {
        requisitos[2].SetActive(false);
        audioManager.CambioDeCanción();
        calendario.SetActive(false);
        holder.sceneManager = holder.choseSceneManager[3];
        holder.sceneManager.startTime = true;
        holder.sceneManager.stopTime = true;
        
        menuInicio.SetActive(false);
        botonJugar.SetActive(true);
        sliderControler.InicioJuego();
        for (int i = 0; i < botonesdeDías.Length; i++)
        {
            botonesdeDías[i].SetActive(false);
        }

    }
    public void Dia4()
    {
        requisitos[3].SetActive(false);
        audioManager.CambioDeCanción();
        calendario.SetActive(false);
        holder.sceneManager = holder.choseSceneManager[3];
        holder.sceneManager.startTime = true;
        holder.sceneManager.stopTime = true;
        
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
        if (!manager.primerNivelComplete)
        {
            requisitos[0].SetActive(true);
        }
        if (manager.primerNivelComplete && !manager.segundoNivelComplete)
        {
            requisitos[0].SetActive(true);
        }
        if (!manager.segundoNivelComplete && !manager.terceroNivelComplete)
        {
            requisitos[0].SetActive(true);
        }
        if (!manager.terceroNivelComplete & !manager.cuartpNivelComplete)
        {
            requisitos[0].SetActive(true);
        }

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
