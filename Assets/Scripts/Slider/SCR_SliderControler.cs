using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCR_SliderControler : MonoBehaviour
{
    public Slider slider;
    public Image fillImage;


    int clicks = 0;
    float valor;
    public float timer;

    public SCO_SceneManager sceneManager;

    public bool stopTimer = false;

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

        if(timer <= slider.maxValue * (20 / 100))
        {
            Debug.Log("menos del 20%");
        }
        if (timer <= slider.maxValue * 40 / 100 && timer > slider.maxValue * 20 / 100)
        {
            Debug.Log("menos del 40%");
        }   
        if (timer <= slider.maxValue * 60 / 100 && timer > slider.maxValue * 40 / 100)
        {
            Debug.Log("menos del 60%");
        }
        if (timer <= slider.maxValue * 80 / 100 && timer > slider.maxValue * 60 / 100)
        {
            Debug.Log("menos del 80%");
        }
        if (timer <= slider.maxValue * 100 / 100 && timer > slider.maxValue * 80 / 100)
        {
            
            Debug.Log("menos del 100%");
        }

        if(stopTimer)
        {
            //Volver al inicio.
        }
    }

    public void StartTimer()
    {
        StartCoroutine(StartTheTimerTicker());
    }

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

}
