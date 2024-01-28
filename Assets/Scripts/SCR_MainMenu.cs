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

    public GameObject calendario;
    public GameObject requisito;
    public GameObject FondoGameOver;
    public GameObject menuInicio;
    public GameObject[] botonesdeDías;
    public GameObject botonJugar;
    Button boton;

    private void Start()
    {
        
        audioManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SCR_AudioManager>();
        holder = GameObject.FindGameObjectWithTag("GameController").GetComponent<SCR_Holder>();
        sliderControler = GameObject.FindGameObjectWithTag("GameController").GetComponent<SCR_SliderControler>();
        audioManager.MusicaDeFondo();
    }
    public void PlayCuaderno()
    {
        audioManager.AudioLibro();
        botonJugar.SetActive(false);
        calendario.GetComponent<VideoPlayer>().Play();

        StartCoroutine(CuadernoYDías());
    }

    public void Dia1()
    {
        audioManager.CambioDeCanción();
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
    public void Dia2()
    {
        audioManager.CambioDeCanción();
        calendario.SetActive(false);
        holder.sceneManager = holder.choseSceneManager[1];
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
    public void Dia3()
    {
        audioManager.CambioDeCanción();
        calendario.SetActive(false);
        holder.sceneManager = holder.choseSceneManager[3];
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
    public void Dia4()
    {
        audioManager.CambioDeCanción();
        calendario.SetActive(false);
        holder.sceneManager = holder.choseSceneManager[3];
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

    public void QuitGame()
    {
        Application.Quit();
    }
}
