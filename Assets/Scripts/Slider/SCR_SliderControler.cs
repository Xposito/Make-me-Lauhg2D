using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCR_SliderControler : MonoBehaviour
{
    #region Variables
    public Slider slider; //Slider del tiempo
    public Image fillImage; //relleno del slider


    int clicks = 0; //lleva las veces que pulsas al patito
    float valor; //Se encarga de porcentuar el color
    public float timer; //Tiempo que dura la slide sin ser tocada en acabar

    public SCO_SceneManager sceneManager; //Manager de Características

    public bool stopTimer = false; //Para el Slide

    public GameObject[] cambiosdeAnimo;

    bool muycontento = true;
    bool contento;
    bool serio;
    bool enfadado;
    bool muyenfadado;

    #endregion

    void Start()
    {   
        sceneManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SCR_Holder>().sceneManager;
        timer = sceneManager.timer;
        slider.maxValue = sceneManager.timer;
        slider.value = sceneManager.timer;
        StartTimer();
    }


    private void Update()
    {
        valor = slider.value / slider.maxValue;
        UpdateColor(valor);

        //Los if diferencian los tramos de muecas

        if(timer <= slider.maxValue * (20 / 100))
        {
            if (muyenfadado)
            {
                muyenfadado= false;
                StartCoroutine(cambioestado(0));
            }
            contento =  true;
            serio = true;
            enfadado = true;
            muycontento= true;
            Debug.Log("menos del 20%");
        }
        if (timer <= slider.maxValue * 40 / 100 && timer > slider.maxValue * 20 / 100)
        {
            if (enfadado)
            {
                enfadado = false;
                StartCoroutine(cambioestado(1));
            }
            muycontento = true;
            serio = true;
            contento = true;
            muyenfadado = true;
            Debug.Log("menos del 40%");
        }   
        if (timer <= slider.maxValue * 60 / 100 && timer > slider.maxValue * 40 / 100)
        {
            if (serio)
            {
                serio = false;
                StartCoroutine(cambioestado(2));
            }
            muycontento =  true;
            contento = true;
            enfadado = true;
            muyenfadado= true;
            Debug.Log("menos del 60%");
        }
        if (timer <= slider.maxValue * 80 / 100 && timer > slider.maxValue * 60 / 100)
        {
            if (contento)
            {
                contento = false;
                StartCoroutine(cambioestado(3));
            }
            muycontento = true;
            serio = true;
            enfadado = true;
            muyenfadado = true;
            Debug.Log("menos del 80%");
        }
        if (timer <= slider.maxValue * 100 / 100 && timer > slider.maxValue * 80 / 100)
        {
            if (muycontento)
            {
                muycontento = false;
                StartCoroutine(cambioestado(4));
            }
            contento = true;
            serio = true;
            enfadado = true;
            muyenfadado = true;
            Debug.Log("menos del 100%");
        }

        if(stopTimer)
        {
            //Volver al inicio.
        }
    }


    #region Slider

    //Inicia la corrutiana
    public void StartTimer()
    {
        StartCoroutine(StartTheTimerTicker());
    }

    //Hace que el slider vaya bajando
    IEnumerator StartTheTimerTicker()
    {
        while (stopTimer == false)
        {
            Time.timeScale = sceneManager.TimerSpeed;
            timer -= Time.deltaTime;

            yield return new WaitForSeconds(0.001f);
            
            
            if (timer <= 0) 
            {
                stopTimer = true;
            }
            if (stopTimer == false)
            {
                slider.value = timer;
            }

        }


    }

    
    // Método que cambia el color del Fill del Slider según su valor
    void UpdateColor(float value)
    {
        // Puedes ajustar los colores según tus preferencias
        Color newColor = Color.Lerp(Color.red, Color.green, value);

        // Asigna el nuevo color al componente de imagen del Fill
        fillImage.color = newColor;
    }
    #endregion

    #region Patito de Goma
    //Lo que ocurre al clickar el patito de Goma
    public void PatitodeGoma(SCO_Object_Configuration object_Configuration)
    {
        if (sceneManager.patito)
        {
            
            timer = timer + object_Configuration.valorSlide;
            
            clicks++;
            if(clicks >= 1)
            {
                StartCoroutine(tiempodePatito());
            }
            if (clicks == 10)
            {
                StopCoroutine(tiempodePatito());
                sceneManager.patito = false;
                StartCoroutine(tiempodePatito());
            }
        }
        else
        {
            timer = timer - object_Configuration.valorSlide;
        }

        


    }

    IEnumerator tiempodePatito()
    {
        yield return new WaitForSeconds(10);

        clicks = 0;
        sceneManager.patito = true;
    }

    #endregion

    //Lo que ocurre al tocar el confeti
    public void Confeti(SCO_Object_Configuration object_Configuration)
    {
        if (sceneManager.confeti)
        {
            timer = timer + object_Configuration.valorSlide;
        }
        else
        {
            timer = timer - object_Configuration.valorSlide;
        }
        


    }

    //Lo que ocurre al tocar las habas
    public void Bean(bool requerido, SCO_Bean_Data bean_Data)
    {
        if (requerido)
        {
            timer = timer + bean_Data.valorSlide;
        }
        else
        {
            timer = timer - bean_Data.valorSlide;
        }

    }

    //Lo que ocurre al tocar los Chistes
    public void Chistes(bool requerido, SCO_Chistes chistes_Data)
    {
        if (requerido)
        {
            timer = timer + chistes_Data.valorSlide;
        }
        else
        {
            timer = timer - chistes_Data.valorSlide;
        }

    }
    IEnumerator cambioestado(int numerodelestado)
    {
        cambiosdeAnimo[numerodelestado].SetActive(true);
        

        yield return new WaitForSeconds(1f);

        for (int i = 0; i < cambiosdeAnimo.Length;)
        {
            if (i != numerodelestado)
            {
                cambiosdeAnimo[i].SetActive(false);
            }

            i++;
        }
        cambiosdeAnimo[numerodelestado].transform.GetChild(0).gameObject.SetActive(true);
    }
    //void CambioEstadoPIm(int numerodelestado)
    //{
    //    cambiosdeAnimo[numerodelestado].SetActive(true);


        

    //    for (int i = 0; i < cambiosdeAnimo.Length;)
    //    {
    //        if (i != numerodelestado)
    //        {
    //            cambiosdeAnimo[i].SetActive(false);
    //        }

    //        i++;
    //    }
    //    cambiosdeAnimo[numerodelestado].transform.GetChild(0).gameObject.SetActive(true);
    //}
}
