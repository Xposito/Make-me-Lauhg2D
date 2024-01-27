using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class SCR_InteractManager : MonoBehaviour
{
#region Variables
    SCO_SceneManager sceneManager;
    SCR_SliderControler sliderControler;
    public SCO_Object_Configuration confeti_SCO;
    public SCO_Object_Configuration sombrero_SCO;

    float scaleTime; //Velocidad del Slide

    #endregion

    private void Start()
    {
        sliderControler = GameObject.FindGameObjectWithTag("GameController").GetComponent<SCR_SliderControler>();
        sceneManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SCR_Holder>().sceneManager;
        sceneManager.timerSpeed = 1.0f;
        sceneManager.patito = true;
        sceneManager.IsSombreroInScene = false;
        confeti_SCO.Used = true;

        scaleTime = sceneManager.TimerSpeed;
    }

    void Update()
    {
        

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

        //Interacción con objetos               
        if (hit.collider.gameObject.layer == 6)
        {
            //Patito De Goma
            if(hit.collider.gameObject.GetComponent<SCR_Holder>().object_Configuration.ID == 0 && Input.GetMouseButtonDown(0))
            {
                sliderControler.PatitodeGoma(hit.collider.gameObject.GetComponent<SCR_Holder>().object_Configuration);
                         // Aquí puedes realizar acciones relacionadas con el objeto golpeado
                            Debug.Log("Se ha golpeado un objeto: " + hit.collider.gameObject.name);
            }


            //Cajita de Musica
            if(hit.collider.gameObject.GetComponent<SCR_Holder>().object_Configuration.ID == 1 && Input.GetMouseButton(0) && sceneManager.cajitaMusica)
            {
                float scaleTime = hit.collider.gameObject.GetComponent<SCR_Holder>().object_Configuration.scaleTime;
                sceneManager.timerSpeed = scaleTime;
                            Debug.Log("Se mantiene" + hit.collider.gameObject.name);
                        
            }
            else if(hit.collider.gameObject.GetComponent<SCR_Holder>().object_Configuration.ID == 1 && Input.GetMouseButton(0) && !sceneManager.cajitaMusica)
            {
                float scaleTime = 1.5f;
                sceneManager.timerSpeed = scaleTime;
            }
           






            //CONFETI
            if(hit.collider.gameObject.GetComponent<SCR_Holder>().object_Configuration.ID == 2 && Input.GetMouseButtonDown(0))
            {
                if (hit.collider.gameObject.GetComponent<SCR_Holder>().object_Configuration.Used)
                {
                    sliderControler.Confeti(hit.collider.gameObject.GetComponent<SCR_Holder>().object_Configuration);
                    scaleTime = hit.collider.gameObject.GetComponent<SCR_Holder>().object_Configuration.scaleTime;
                    hit.collider.gameObject.GetComponent<SCR_Holder>().object_Configuration.Used = false;
                }
                

                Debug.Log("Se mantiene" + hit.collider.gameObject.name);
            }
            



            //Gorro de bufón
            if(hit.collider.gameObject.GetComponent<SCR_Holder>().object_Configuration.ID == 3 && Input.GetMouseButtonDown(0))
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
           

            if(hit.collider.gameObject.GetComponent<SCR_Holder>().bean_Data.ID == 0 && Input.GetMouseButtonDown(0))
            {
                sliderControler.Bean(sceneManager.beanLisa, hit.collider.gameObject.GetComponent<SCR_Holder>().bean_Data);
                scaleTime = hit.collider.gameObject.GetComponent<SCR_Holder>().bean_Data.scaleTime;
            }
            if (hit.collider.gameObject.GetComponent<SCR_Holder>().bean_Data.ID == 1 && Input.GetMouseButtonDown(0))
            {
                sliderControler.Bean(sceneManager.beanRallada, hit.collider.gameObject.GetComponent<SCR_Holder>().bean_Data);
                scaleTime = hit.collider.gameObject.GetComponent<SCR_Holder>().bean_Data.scaleTime;
            }
            if (hit.collider.gameObject.GetComponent<SCR_Holder>().bean_Data.ID == 2 && Input.GetMouseButtonDown(0)) 
            {
                sliderControler.Bean(sceneManager.beanPuntos, hit.collider.gameObject.GetComponent<SCR_Holder>().bean_Data);
                scaleTime = hit.collider.gameObject.GetComponent<SCR_Holder>().bean_Data.scaleTime;
            }
            if (hit.collider.gameObject.GetComponent<SCR_Holder>().bean_Data.ID == 3 && Input.GetMouseButtonDown(0))
            {
                sliderControler.Bean(sceneManager.beanEstrellas, hit.collider.gameObject.GetComponent<SCR_Holder>().bean_Data);
                scaleTime = hit.collider.gameObject.GetComponent<SCR_Holder>().bean_Data.scaleTime;
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
