using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiempo : MonoBehaviour
{
    public  GameObject boton;
    public GameObject botonQuit;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ActiveAndDesactive());
    }

    IEnumerator ActiveAndDesactive()
    {
        yield return new WaitForSeconds(14);
        boton.SetActive(true);
        botonQuit.SetActive(true);
        transform.gameObject.SetActive(false);

    }
    
}
