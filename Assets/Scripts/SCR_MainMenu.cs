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
    public GameObject[] botonesdeD�as;
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

        StartCoroutine(CuadernoYD�as());
    }

    public void Dia1()
    {
        audioManager.CambioDeCanci�n();
        calendario.SetActive(false);
        holder.sceneManager = holder.choseSceneManager[0];
        holder.sceneManager.startTime = true;
        holder.sceneManager.stopTime = true;
        requisito.SetActive(true);
        menuInicio.SetActive(false);
        botonJugar.SetActive(true);
        sliderControler.InicioJuego();
        for (int i = 0; i < botonesdeD�as.Length; i++)
        {
            botonesdeD�as[i].SetActive(false);
        }

    }
    public void Dia2()
    {
        audioManager.CambioDeCanci�n();
        calendario.SetActive(false);
        holder.sceneManager = holder.choseSceneManager[1];
        holder.sceneManager.startTime = true;
        holder.sceneManager.stopTime = true;
        requisito.SetActive(true);
        menuInicio.SetActive(false);
        botonJugar.SetActive(true);
        sliderControler.InicioJuego();
        for (int i = 0; i < botonesdeD�as.Length; i++)
        {
            botonesdeD�as[i].SetActive(false);
        }

    }
    public void Dia3()
    {
        audioManager.CambioDeCanci�n();
        calendario.SetActive(false);
        holder.sceneManager = holder.choseSceneManager[3];
        holder.sceneManager.startTime = true;
        holder.sceneManager.stopTime = true;
        requisito.SetActive(true);
        menuInicio.SetActive(false);
        botonJugar.SetActive(true);
        sliderControler.InicioJuego();
        for (int i = 0; i < botonesdeD�as.Length; i++)
        {
            botonesdeD�as[i].SetActive(false);
        }

    }
    public void Dia4()
    {
        audioManager.CambioDeCanci�n();
        calendario.SetActive(false);
        holder.sceneManager = holder.choseSceneManager[3];
        holder.sceneManager.startTime = true;
        holder.sceneManager.stopTime = true;
        requisito.SetActive(true);
        menuInicio.SetActive(false);
        botonJugar.SetActive(true);
        sliderControler.InicioJuego();
        for (int i = 0; i < botonesdeD�as.Length; i++)
        {
            botonesdeD�as[i].SetActive(false);
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
    IEnumerator CuadernoYD�as()
    {
        yield return new WaitForSeconds(3f);

        for(int i = 0; i < botonesdeD�as.Length; i++)
        {
            botonesdeD�as[i].SetActive(true);
        }

    }
}
