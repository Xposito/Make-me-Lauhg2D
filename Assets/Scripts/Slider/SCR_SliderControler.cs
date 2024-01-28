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
    SCR_AudioManager audioManager;

    

    public GameObject cambiosMuyContento;
    public GameObject cambiosContento;
    public GameObject cambiosserio;
    public GameObject cambiosenfadado;
    public GameObject cambiosMuyEnfadado;

    public GameObject[] objetos;
    public GameObject confetiusado;
    public GameObject pantallaInicio;

    public GameObject pantallaGameOver;
    

    bool muycontento =  true;
    bool contento;
    bool serio;
    bool enfadado;
    bool muyenfadado;

    #endregion

    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SCR_AudioManager>();
        slider.gameObject.SetActive(false);
        sceneManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SCR_Holder>().sceneManager;
        sceneManager.stopTime = true;
        sceneManager.startTime = true;
        InicioMenu();
        
    }


    private void Update()
    {
        

        //Los if diferencian los tramos de muecas
        if (!sceneManager.stopTime)
        {
           
            if (sceneManager.startTime)
            {
                sceneManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SCR_Holder>().sceneManager;
                sceneManager.startTime = false;
                timer = sceneManager.timer;
                slider.maxValue = sceneManager.timer;
                slider.value = sceneManager.timer;
                StartTimer();
                InicioJuego();

            }


            slider.gameObject.SetActive(true);

            valor = slider.value / slider.maxValue;
            UpdateColor(valor);

            if (timer <= slider.maxValue * (20 / 100))
            {
                if (muyenfadado)
                {
                    audioManager.AudioReyMuyEnfadado();
                    muycontento = true;
                    contento = true;
                    enfadado = true;
                    serio = true;
                    muyenfadado = false;


                    cambiosMuyContento.GetComponent<SpriteRenderer>().sortingOrder = 1;
                    cambiosMuyEnfadado.GetComponent<SpriteRenderer>().sortingOrder = 5;
                    cambiosenfadado.GetComponent<SpriteRenderer>().sortingOrder = 1;
                    cambiosserio.GetComponent<SpriteRenderer>().sortingOrder = 1;
                    cambiosContento.GetComponent<SpriteRenderer>().sortingOrder = 1;
                }

               
                //Debug.Log("menos del 20%");
            }
            if (timer <= slider.maxValue * 40 / 100 && timer > slider.maxValue * 20 / 100)
            {
                if (enfadado)
                {
                    audioManager.AudioReyEnfadado();
                    muycontento = true;
                    contento = true;
                    enfadado = false;
                    serio = true;
                    muyenfadado = true;


                    cambiosMuyContento.GetComponent<SpriteRenderer>().sortingOrder = 1;
                    cambiosMuyEnfadado.GetComponent<SpriteRenderer>().sortingOrder = 1;
                    cambiosenfadado.GetComponent<SpriteRenderer>().sortingOrder = 5;
                    cambiosserio.GetComponent<SpriteRenderer>().sortingOrder = 1;
                    cambiosContento.GetComponent<SpriteRenderer>().sortingOrder = 1;
                }


                //Debug.Log("menos del 40%");
            }
            if (timer <= slider.maxValue * 60 / 100 && timer > slider.maxValue * 40 / 100)
            {

                if (serio)
                {
                    audioManager.AudioReySerio();
                    muycontento = true;
                    contento = true;
                    enfadado = true;
                    serio = false;
                    muyenfadado = true;


                    cambiosMuyContento.GetComponent<SpriteRenderer>().sortingOrder = 1;
                    cambiosMuyEnfadado.GetComponent<SpriteRenderer>().sortingOrder = 1;
                    cambiosenfadado.GetComponent<SpriteRenderer>().sortingOrder = 1;
                    cambiosserio.GetComponent<SpriteRenderer>().sortingOrder = 5;
                    cambiosContento.GetComponent<SpriteRenderer>().sortingOrder = 1;
                }

                //Debug.Log("menos del 60%");
            }
            if (timer <= slider.maxValue * 80 / 100 && timer > slider.maxValue * 60 / 100)
            {
                if (contento)
                {
                    audioManager.AudioReyContento();
                    muycontento = true;
                    contento = false;
                    enfadado = true;
                    serio = true;
                    muyenfadado = true;


                    cambiosMuyContento.GetComponent<SpriteRenderer>().sortingOrder = 1;
                    cambiosMuyEnfadado.GetComponent<SpriteRenderer>().sortingOrder = 1;
                    cambiosenfadado.GetComponent<SpriteRenderer>().sortingOrder = 1;
                    cambiosserio.GetComponent<SpriteRenderer>().sortingOrder = 1;
                    cambiosContento.GetComponent<SpriteRenderer>().sortingOrder = 5;
                }


                //Debug.Log("menos del 80%");
            }
            if (timer <= slider.maxValue * 100 / 100 && timer > slider.maxValue * 80 / 100)
            {



                if (muycontento)
                {
                    audioManager.AudioReyMuyContento();
                    muycontento = false;
                    contento = true;
                    enfadado = true;
                    serio = true;
                    muyenfadado = true;


                    cambiosMuyContento.GetComponent<SpriteRenderer>().sortingOrder = 5;
                    cambiosMuyEnfadado.GetComponent<SpriteRenderer>().sortingOrder = 1;
                    cambiosenfadado.GetComponent<SpriteRenderer>().sortingOrder = 1;
                    cambiosserio.GetComponent<SpriteRenderer>().sortingOrder = 1;
                    cambiosContento.GetComponent<SpriteRenderer>().sortingOrder = 1;
                }



                //Debug.Log("menos del 100%");
            }
        }
        else
        {
           

            
            //Meter escena de gameover
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
        while (sceneManager.stopTime == false)
        {
            Time.timeScale = sceneManager.TimerSpeed;
            timer -= Time.deltaTime;

            yield return new WaitForSeconds(0.001f);
            
            
            if (timer <= 0) 
            {
                sceneManager.stopTime = true;
                GameOver();
            }
            if (sceneManager.stopTime == false)
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
            audioManager.AudioChiste();
            timer = timer + chistes_Data.valorSlide;
        }
        else
        {
            timer = timer - chistes_Data.valorSlide;
        }

    }
    


    void GameOver()
    {
        pantallaGameOver.SetActive(true);
        audioManager.AudioTrompetasDerrota();
    }
    public void InicioMenu()
    {
        for (int i = 0; i < objetos.Length; i++)
        {
            objetos[i].SetActive(false);
        }
        Debug.Log("InicioMenu");
        pantallaInicio.GetComponent<SpriteRenderer>().sortingOrder = 100;
        slider.gameObject.SetActive(false);
        confetiusado.gameObject.SetActive(false);

    }
    public void InicioJuego()
    {
        sceneManager.timerSpeed = 1.0f;
        sceneManager.patito = true;
        sceneManager.IsSombreroInScene = false;
        sceneManager.confetiUsed = true;
        confetiusado.SetActive(false);
        for (int i = 0; i < objetos.Length; i++)
        {
            objetos[i].SetActive(true);
        }
        pantallaInicio.GetComponent<SpriteRenderer>().sortingOrder = -1;
    }


}
