using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCR_SliderControler : MonoBehaviour
{
    public Slider slider;
    public Image fillImage;

    
    float valor;
    float timer;

    public SCO_SceneManager sceneManager;

    public bool stopTimer = false;

    void Start()
    {
        timer = sceneManager.timer;
        slider.maxValue = sceneManager.timer;
        slider.value = sceneManager.timer;
        StartTimer();
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

    private void Update()
    {
        valor = slider.value/slider.maxValue;
        UpdateColor(valor);
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
        timer = timer + object_Configuration.ValorSlide;


    }



}
