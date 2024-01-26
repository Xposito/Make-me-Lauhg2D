using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class SCR_InteractManager : MonoBehaviour
{

    SCR_SliderControler sliderControler;

    private void Start()
    {
        sliderControler = GameObject.FindGameObjectWithTag("GameController").GetComponent<SCR_SliderControler>();
    }

    void Update()
    {
        ObjetosInteractuables();
        
    }



    public void ObjetosInteractuables()
    {
        
        
       Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Lanza un rayo desde la posición del ratón en dirección Vector2.zero (hacia el centro)
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
                       
        if (hit.collider.gameObject.layer == 6)
        {
            if(hit.collider.gameObject.GetComponent<SCR_Holder>().object_Configuration.ID == 0 && Input.GetMouseButtonDown(0))
            {
                sliderControler.PatitodeGoma(hit.collider.gameObject.GetComponent<SCR_Holder>().object_Configuration);



                             // Aquí puedes realizar acciones relacionadas con el objeto golpeado
                            Debug.Log("Se ha golpeado un objeto: " + hit.collider.gameObject.name);
            }

            if(hit.collider.gameObject.GetComponent<SCR_Holder>().object_Configuration.ID == 1 && Input.GetMouseButton(0))
            {
                float scaleTime = hit.collider.gameObject.GetComponent<SCR_Holder>().object_Configuration.ValorSlide;
                sliderControler.sceneManager.timerSpeed = scaleTime;
                            Debug.Log("Se mantiene" + hit.collider.gameObject.name);
                        
            }
            else 
            {
                sliderControler.sceneManager.timerSpeed = 1f;
            }
            if(hit.collider.gameObject.GetComponent<SCR_Holder>().object_Configuration.ID == 2 && Input.GetMouseButtonDown(0))
            {
                Debug.Log("Se mantiene" + hit.collider.gameObject.name);
            }
            if(hit.collider.gameObject.GetComponent<SCR_Holder>().object_Configuration.ID == 3 && Input.GetMouseButtonDown(0))
            {
                Debug.Log("Se mantiene" + hit.collider.gameObject.name);
            }
                
        }
             

            // Comprueba si el rayo golpea un objeto
            
        

           
    }

}
