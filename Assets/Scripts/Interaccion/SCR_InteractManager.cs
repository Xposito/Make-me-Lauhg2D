using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;


public class SCR_InteractManager : MonoBehaviour
{
#region Variables
    SCO_SceneManager sceneManager;
    SCR_SliderControler sliderControler;
    SCR_AudioManager audioManager;
    public SCO_Object_Configuration confeti_SCO;
    public SCO_Object_Configuration sombrero_SCO;

    public GameObject[] patoCambio;

    public GameObject[] confeti;    

    

    float scaleTime; //Velocidad del Slide

    #endregion

    private void Start()
    {
        sliderControler = GameObject.FindGameObjectWithTag("GameController").GetComponent<SCR_SliderControler>();
        sceneManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SCR_Holder>().sceneManager;
        audioManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SCR_AudioManager>();



        scaleTime = sceneManager.TimerSpeed;
    }

    void Update()
    {
        sceneManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SCR_Holder>().sceneManager;
        confeti_SCO.Used = sceneManager.confetiUsed;

        sceneManager.timerSpeed = scaleTime;
        ObjetosInteractuables();
        
    }

    //Para saber cuando está el sombrero
    public void SombreroEnEscena()
    {
        if (sceneManager.IsSombreroInScene)
        {
            scaleTime = sombrero_SCO.scaleTime;
        }
    }


    //Engloba todos los objetos con los que se interactúan
    public void ObjetosInteractuables()
    {
        
        
       Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Lanza un rayo desde la posición del ratón en dirección Vector2.zero (hacia el centro)
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        if (Physics2D.Raycast(mousePosition, Vector2.zero))
        {
            //Interacción con objetos               
            if (hit.collider.gameObject.layer == 6)
            {
                //Patito De Goma
                if (hit.collider.gameObject.GetComponent<SCR_Holder>().object_Configuration.ID == 0 && Input.GetMouseButtonDown(0))
                {
                    audioManager.AudioPato(hit.collider.gameObject.GetComponent<AudioSource>());
                    StartCoroutine(CambioPato());
                    
                    sliderControler.PatitodeGoma(hit.collider.gameObject.GetComponent<SCR_Holder>().object_Configuration);
                    
                    
                    // Aquí puedes realizar acciones relacionadas con el objeto golpeado
                    Debug.Log("Se ha golpeado un objeto: " + hit.collider.gameObject.name);
                }


                //Cajita de Musica
                if (hit.collider.gameObject.GetComponent<SCR_Holder>().object_Configuration.ID == 1 && Input.GetMouseButton(0) && sceneManager.cajitaMusica)
                {
                    float scaleTime = hit.collider.gameObject.GetComponent<SCR_Holder>().object_Configuration.scaleTime;
                    sceneManager.timerSpeed = scaleTime;
                    Debug.Log("Se mantiene" + hit.collider.gameObject.name);

                    audioManager.AudioCajaDeMusica();

                }
                else if (hit.collider.gameObject.GetComponent<SCR_Holder>().object_Configuration.ID == 1 && Input.GetMouseButton(0) && !sceneManager.cajitaMusica)
                {
                    float scaleTime = 1.5f;
                    sceneManager.timerSpeed = scaleTime;

                    
                }
                else
                {
                    audioManager.PararCajaDeMusica();
                }







                //CONFETI
                if (hit.collider.gameObject.GetComponent<SCR_Holder>().object_Configuration.ID == 2 && Input.GetMouseButtonDown(0))
                {
                    if (hit.collider.gameObject.GetComponent<SCR_Holder>().object_Configuration.Used)
                    {
                        audioManager.Audioconfeti();
                        sliderControler.Confeti(hit.collider.gameObject.GetComponent<SCR_Holder>().object_Configuration);
                        scaleTime = hit.collider.gameObject.GetComponent<SCR_Holder>().object_Configuration.scaleTime;
                        sceneManager.confetiUsed = false;
                        confeti[0].SetActive(false);
                        confeti[1].SetActive(true);
                    }


                    Debug.Log("Se mantiene" + hit.collider.gameObject.name);
                }




                //Gorro de bufón
                if (hit.collider.gameObject.GetComponent<SCR_Holder>().object_Configuration.ID == 3 && Input.GetMouseButtonDown(0))
                {

                    sceneManager.IsSombreroInScene = false;
                    scaleTime = 1f;
                    Destroy(hit.collider.gameObject);
                    Debug.Log("Se mantiene" + hit.collider.gameObject.name);
                }

            }
            //Interacción con beans
            if (hit.collider.gameObject.layer == 7)
            {


                if (hit.collider.gameObject.GetComponent<SCR_Holder>().bean_Data.ID == 0 && Input.GetMouseButtonDown(0))
                {
                    audioManager.Audiohaba();
                    sliderControler.Bean(sceneManager.beanLisa, hit.collider.gameObject.GetComponent<SCR_Holder>().bean_Data);
                    scaleTime = hit.collider.gameObject.GetComponent<SCR_Holder>().bean_Data.scaleTime;
                    //Destroy(hit.collider.gameObject);
                    hit.collider.gameObject.SetActive(false);

                }
                if (hit.collider.gameObject.GetComponent<SCR_Holder>().bean_Data.ID == 1 && Input.GetMouseButtonDown(0))
                {
                    audioManager.Audiohaba();
                    sliderControler.Bean(sceneManager.beanRallada, hit.collider.gameObject.GetComponent<SCR_Holder>().bean_Data);
                    scaleTime = hit.collider.gameObject.GetComponent<SCR_Holder>().bean_Data.scaleTime;
                    //Destroy(hit.collider.gameObject);
                    hit.collider.gameObject.SetActive(false);
                }
                if (hit.collider.gameObject.GetComponent<SCR_Holder>().bean_Data.ID == 2 && Input.GetMouseButtonDown(0))
                {
                    audioManager.Audiohaba();
                    sliderControler.Bean(sceneManager.beanPuntos, hit.collider.gameObject.GetComponent<SCR_Holder>().bean_Data);
                    scaleTime = hit.collider.gameObject.GetComponent<SCR_Holder>().bean_Data.scaleTime;
                    //Destroy(hit.collider.gameObject);
                    hit.collider.gameObject.SetActive(false);
                }
                if (hit.collider.gameObject.GetComponent<SCR_Holder>().bean_Data.ID == 3 && Input.GetMouseButtonDown(0))
                {
                    audioManager.Audiohaba();
                    sliderControler.Bean(sceneManager.beanEstrellas, hit.collider.gameObject.GetComponent<SCR_Holder>().bean_Data);
                    scaleTime = hit.collider.gameObject.GetComponent<SCR_Holder>().bean_Data.scaleTime;
                    //Destroy(hit.collider.gameObject);
                    hit.collider.gameObject.SetActive(false);
                }




            }

            //Interacción con Chistes
            if (hit.collider.gameObject.layer == 8)
            {
                
                if (hit.collider.gameObject.GetComponent<SCR_Holder>().chistes_Data.ID == 0 && Input.GetMouseButtonDown(0))
                {
                    sliderControler.Chistes(sceneManager.chistesPobreza, hit.collider.gameObject.GetComponent<SCR_Holder>().chistes_Data);
                    scaleTime = hit.collider.gameObject.GetComponent<SCR_Holder>().chistes_Data.scaleTime;
                    Destroy(hit.collider.gameObject);
                }
                if (hit.collider.gameObject.GetComponent<SCR_Holder>().chistes_Data.ID == 1 && Input.GetMouseButtonDown(0))
                {
                    sliderControler.Chistes(sceneManager.chistesAnimales, hit.collider.gameObject.GetComponent<SCR_Holder>().chistes_Data);
                    scaleTime = hit.collider.gameObject.GetComponent<SCR_Holder>().chistes_Data.scaleTime;
                    Destroy(hit.collider.gameObject);
                }
                if (hit.collider.gameObject.GetComponent<SCR_Holder>().chistes_Data.ID == 2 && Input.GetMouseButtonDown(0))
                {
                    sliderControler.Chistes(sceneManager.chistesAmor, hit.collider.gameObject.GetComponent<SCR_Holder>().chistes_Data);
                    scaleTime = hit.collider.gameObject.GetComponent<SCR_Holder>().chistes_Data.scaleTime;
                    Destroy(hit.collider.gameObject);
                }
                if (hit.collider.gameObject.GetComponent<SCR_Holder>().chistes_Data.ID == 3 && Input.GetMouseButtonDown(0))
                {
                    sliderControler.Chistes(sceneManager.chistesRopa, hit.collider.gameObject.GetComponent<SCR_Holder>().chistes_Data);
                    scaleTime = hit.collider.gameObject.GetComponent<SCR_Holder>().chistes_Data.scaleTime;
                    Destroy(hit.collider.gameObject);
                }
            }





        }
        
        


    }
    
    IEnumerator CambioPato()
    {
        patoCambio[0].GetComponent<SpriteRenderer>().enabled = false;
        patoCambio[1].SetActive(true);

        yield return new WaitForSeconds(0.1f);

        patoCambio[0].GetComponent<SpriteRenderer>().enabled = true;
        patoCambio[1].SetActive(false);
    }
   


}
