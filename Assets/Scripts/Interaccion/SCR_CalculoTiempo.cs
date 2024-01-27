using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCR_CalculoTiempo : MonoBehaviour
{
    SCR_InteractManager interactManager;
    SCO_SceneManager sceneManager;
    public GameObject[] spawnpoints;
    public GameObject lacayos_1;
    public GameObject lacayos_2;
    public GameObject lacayos_3;
    public GameObject lacayos_4;

    public GameObject[] spawnpointsombreros;
    public GameObject sombrero;

    public GameObject beanLisa;
    public GameObject beanRallada;
    public GameObject beanPuntos;
    public GameObject beanEstrellada;

    public bool Iswaiting = false;

    private float currentTime = 0f;
    private float lacayosTime = 0f;
    private float sombreroTime = 0f;
    private float targetTime; // Tiempo deseado de espera en segundos
    

    private void Start()
    {
        interactManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SCR_InteractManager>();
        sceneManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SCR_Holder>().sceneManager;
        targetTime = sceneManager.tiempoNivel;
        StartCoroutine(CustomWait());
        //Restart();
    }
    void Update()
    {
        // Lógica personalizada de tiempo
        currentTime += Time.deltaTime;
        lacayosTime += Time.deltaTime;
        sombreroTime += Time.deltaTime;

        // Comienza la espera cuando se presiona la tecla 'Espacio'
        if(lacayosTime >= sceneManager.tiempoSpawnLacayos)
        {
            ElegirLacayo();
        }
        if (sombreroTime >= sceneManager.tiempoSpawnSombrero && !sceneManager.IsSombreroInScene)
        {
            ElegirSpawnSombrero();
        }


    }

    // Coroutine personalizada para la espera
    IEnumerator CustomWait()
    {
        
        
        while (currentTime < targetTime)
        {
            // Puedes realizar acciones mientras esperas, si es necesario
            Debug.Log("Esperando...");
            

            yield return null;
        }
        

        // Restablece el tiempo y realiza acciones después de la espera
        currentTime = 0f;
        
        Debug.Log("Has Ganado");
    }


    void ElegirLacayo()
    {
        int randomlacayo = Random.Range(0, 100);

        
        if (randomlacayo < sceneManager.probabilidadLacayo1)
        {
            RandamoPosition(lacayos_1);
        }
        else if (sceneManager.probabilidadLacayo1 <= randomlacayo && randomlacayo < sceneManager.probabilidadLacayo2)
        {
            RandamoPosition(lacayos_2);
        }
        else if (sceneManager.probabilidadLacayo2 <= randomlacayo && randomlacayo < sceneManager.probabilidadLacayo3)
        {
            RandamoPosition(lacayos_3);
        }
        if (sceneManager.probabilidadLacayo3 <= randomlacayo && randomlacayo < sceneManager.probabilidadLacayo4)
        {
            RandamoPosition(lacayos_4);
        }

    }
    void RandomBean(GameObject lacayo)
    {
        int ramdomBean = Random.Range(0, 100);

        Transform handlerbean = lacayo.GetComponentInChildren<Transform>();
        if(ramdomBean < sceneManager.probalidadSpawnbeanLisa)
        {
            Instantiate(beanLisa, handlerbean.transform.position, Quaternion.identity);
        }
        else if (sceneManager.probalidadSpawnbeanLisa <= ramdomBean && ramdomBean < sceneManager.probalidadSpawnbeanRallada)
        {
            Instantiate(beanRallada, handlerbean.transform.position, Quaternion.identity);
        }
        else if (sceneManager.probalidadSpawnbeanRallada <= ramdomBean && ramdomBean < sceneManager.probalidadSpawnbeanPuntos)
        {
            Instantiate(beanPuntos, handlerbean.transform.position, Quaternion.identity);
        }
        if (sceneManager.probalidadSpawnbeanPuntos <= ramdomBean && ramdomBean < sceneManager.probalidadSpawnbeanEstrellada)
        {
            Instantiate(beanEstrellada, handlerbean.transform.position, Quaternion.identity);
        }

    }

    void RandamoPosition(GameObject lacayoRandom)
    {
        //StopCoroutine(SpawnLacayos());
        //StartCoroutine(SpawnLacayos());
        int randomNumber = Random.Range(0, 100);

        Debug.Log(randomNumber);

        if (randomNumber <= 50)
        {
            GameObject lacayoIntancia = Instantiate(lacayoRandom, spawnpoints[0].transform.position, Quaternion.identity); 
            //Instantiate(lacayos_1, spawnpoints[0].transform.position, Quaternion.identity);
            RandomBean(lacayoIntancia);
        }
        else
        {
            GameObject lacayoIntancia = Instantiate(lacayoRandom, spawnpoints[1].transform.position, Quaternion.identity);
            //Instantiate(lacayos_1, spawnpoints[0].transform.position, Quaternion.identity);
            RandomBean(lacayoIntancia);
        }
        lacayosTime = 0f;
    }

    void ElegirSpawnSombrero()
    {
        sceneManager.IsSombreroInScene = true;
        interactManager.SombreroEnEscena();

        int randomsombrerospawn = Random.Range(0, 100);


        if (randomsombrerospawn < sceneManager.probabilidadSpawnSombrero)
        {
            Instantiate(sombrero, spawnpointsombreros[0].transform.position, Quaternion.identity);
        }
        else if (sceneManager.probabilidadSpawnSombrero <= randomsombrerospawn && randomsombrerospawn < sceneManager.probabilidadSpawnSombrero1)
        {
            Instantiate(sombrero, spawnpointsombreros[1].transform.position, Quaternion.identity);
        }
        else if (sceneManager.probabilidadSpawnSombrero1 <= randomsombrerospawn && randomsombrerospawn < sceneManager.probabilidadSpawnSombrero2)
        {
            Instantiate(sombrero, spawnpointsombreros[2].transform.position, Quaternion.identity);
        }
        if (sceneManager.probabilidadSpawnSombrero2 <= randomsombrerospawn && randomsombrerospawn < sceneManager.probabilidadSpawnSombrero3)
        {
            Instantiate(sombrero, spawnpointsombreros[3].transform.position, Quaternion.identity);
        }

        sombreroTime = 0;
    }

}
