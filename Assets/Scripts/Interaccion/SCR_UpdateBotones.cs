using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SCR_UpdateBotones : MonoBehaviour
{
    Manager manager;

     GameObject candado;
     Button boton;
    public bool dia1;
    public bool dia2;
    public bool dia3;
    public bool dia4;

    public GameObject requisito1;
    
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<Manager>();
        candado = transform.GetChild(0).gameObject;
        boton = transform.GetComponent<Button>();


    }

    // Update is called once per frame
    void Update()
    {
        if (dia1 && !manager.primerNivelComplete)
        {
            requisito1.SetActive(true);
            candado.SetActive(false);
            boton.enabled = true;

        }

        if (dia2 && manager.primerNivelComplete)
        {
            requisito1.SetActive(true);
            candado.SetActive(false);
            boton.enabled = true;

        }
        else if (dia2)
        {
            candado.SetActive(true);
            boton.enabled = false;

        }

        if (dia3 && manager.segundoNivelComplete)
        {
            requisito1.SetActive(true);
            candado.SetActive(false);
            boton.enabled = true;

        }
        else if (dia3)
        {
            candado.SetActive(true);
            boton.enabled = false;

        }

        if (dia4 && manager.terceroNivelComplete)
        {
            requisito1.SetActive(true);
            candado.SetActive(false);
            boton.enabled = true;

        }
        else if (dia4)
        {
            candado.SetActive(true);
            boton.enabled = false;

        }




    }
}
