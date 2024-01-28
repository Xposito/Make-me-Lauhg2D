using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCR_CalculoTiempo : MonoBehaviour
{
    #region Variables
    [Header("Managers")]
    Manager manager;
    SCR_InteractManager interactManager;
    SCO_SceneManager sceneManager;
    SCR_AudioManager audioManager;
    SCR_MainMenu mainMenu;
    

    [Header("Lacayos")]
    public GameObject[] spawnpoints;
    public GameObject lacayos_1;
    public GameObject lacayos_2;
    public GameObject lacayos_3;
    public GameObject lacayos_4;
    
    [Header("Sombreros")]
    public GameObject[] spawnpointsombreros;
    public GameObject sombrero;

    [Header("Chistes")]
    public GameObject[] spawnpointChistes;
    public GameObject[] chistesPobreza;
    public GameObject[] chistesAnimales;
    public GameObject[] chistesAmor;
    public GameObject[] chistesRopa;

    [Header("Bean")]
    public GameObject beanLisa;
    public GameObject beanRallada;
    public GameObject beanPuntos;
    public GameObject beanEstrellada;

    public bool Iswaiting = false;

    //Floats que miden los tiempos

    public float currentTime = 0f; //Tiempo que corre para el nivel
    private float lacayosTime = 0f; //Tiempo que corre para el spawn de lacayos
    private float sombreroTime = 0f; //Tiempo que corre para el spawn de sombreros
    private float chistesTime = 0f; //Tiempo que que corre para el spawn de chistes
    private float targetTime; // Tiempo deseado de espera en segundos

    bool noIntantiate;
    #endregion

    private void Start()
    {
        StopAllCoroutines();
        interactManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SCR_InteractManager>();
        sceneManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SCR_Holder>().sceneManager;
        audioManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SCR_AudioManager>();
        mainMenu = GameObject.FindGameObjectWithTag("GameController").GetComponent<SCR_MainMenu>();
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<Manager>();
        //Restart();
    }

    void Update()
    {
        if (!sceneManager.stopTime)
        {
            
            if (sceneManager.startTime)
            {
                sceneManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SCR_Holder>().sceneManager;

                
                noIntantiate = true;
                sceneManager.startTime = false;
                targetTime = sceneManager.tiempoNivel;
                

            }
            currentTime += Time.deltaTime;
            lacayosTime += Time.deltaTime;
            sombreroTime += Time.deltaTime;
            chistesTime += Time.deltaTime;

            
                // Comienza la espera cuando se presiona la tecla 'Espacio'
                if (lacayosTime >= sceneManager.tiempoSpawnLacayos)
                {
                    ElegirLacayo();
                }
                if (sombreroTime >= sceneManager.tiempoSpawnSombrero && !sceneManager.IsSombreroInScene)
                {
                    ElegirSpawnSombrero();
                }
                if (chistesTime >= sceneManager.tiempoSpawnChistes)
                {
                    ElegirTipoChiste();
                }
            
            
            Final();
        }
        else
        {
            
        }
        // Lógica personalizada de tiempo
        


    }

    //Lleva el tiempo que tienes que sobrevivir
    void Final()
    {
        
        


        
        if (currentTime >= sceneManager.tiempoNivel)
        {
            audioManager.AudioTrompetasVictoria();
            sceneManager.stopTime = true;
            sceneManager.startTime = true;
            currentTime = 0;
            
            mainMenu.MenuInicio();

            if (sceneManager.primernivel)
            {
                manager.primerNivelComplete = true;
            }
            if (sceneManager.segundonivel)
            {
                manager.segundoNivelComplete= true;
            }
            if (sceneManager.tercernivelnivel)
            {
                manager.terceroNivelComplete = true;
            }
            if (sceneManager.cuartonivel)
            {
                manager.cuartpNivelComplete = true;
            }


            StopAllCoroutines();
        }
        
        
        
        
        
    }

    #region LacayosPosition
    void ElegirLacayo()
    {
        int randomlacayo = Random.Range(0, 100);

        
        if (randomlacayo < sceneManager.probabilidadLacayo1)
        {
            RandomPosition(lacayos_1);
        }
        else if (sceneManager.probabilidadLacayo1 <= randomlacayo && randomlacayo < sceneManager.probabilidadLacayo2)
        {
            RandomPosition(lacayos_2);
        }
        else if (sceneManager.probabilidadLacayo2 <= randomlacayo && randomlacayo < sceneManager.probabilidadLacayo3)
        {
            RandomPosition(lacayos_3);
        }
        if (sceneManager.probabilidadLacayo3 <= randomlacayo && randomlacayo < sceneManager.probabilidadLacayo4)
        {
            RandomPosition(lacayos_4);
        }

    }
    void RandomPosition(GameObject lacayoRandom)
    {
        //StopCoroutine(SpawnLacayos());
        //StartCoroutine(SpawnLacayos());
        int randomNumber = Random.Range(0, 100);

        //Debug.Log(randomNumber);

        if (randomNumber <= 50)
        {
            GameObject lacayoIntancia = Instantiate(lacayoRandom, spawnpoints[0].transform.position, Quaternion.identity);
            
            //Instantiate(lacayos_1, spawnpoints[0].transform.position, Quaternion.identity);
            RandomBean(lacayoIntancia);
            StartCoroutine(MoverLacayo(lacayoIntancia.transform, spawnpoints[1].transform) );
            StartCoroutine(DestruirLacayo(lacayoIntancia));
        }
        else
        {
            GameObject lacayoIntancia = Instantiate(lacayoRandom, spawnpoints[1].transform.position, Quaternion.identity);
            
            lacayoIntancia.transform.localScale = new Vector3(lacayoIntancia.transform.localScale.x * -1, lacayoIntancia.transform.localScale.y, lacayoIntancia.transform.localScale.z);
            //Instantiate(lacayos_1, spawnpoints[0].transform.position, Quaternion.identity);
            RandomBean(lacayoIntancia);
            StartCoroutine(MoverLacayo(lacayoIntancia.transform, spawnpoints[0].transform));
            StartCoroutine(DestruirLacayo(lacayoIntancia));
        }
        lacayosTime = 0f;
    }

    IEnumerator MoverLacayo(Transform inicio, Transform dest)
    {
        float duracion = 500f;
        float tiempoPasado = 0f;

        while (tiempoPasado < duracion)
        {
            // Calcula la interpolación lineal entre puntoInicial y puntoFinal
            float t = tiempoPasado / duracion;
            inicio.gameObject.transform.position = Vector3.Lerp(inicio.position, dest.position, t);

            // Actualiza el tiempo pasado
            tiempoPasado += Time.deltaTime;

            // Espera hasta el siguiente frame
            yield return null;
        }

        // Asegúrate de que el objeto esté exactamente en la posición final
        
    
    }
    IEnumerator DestruirLacayo(GameObject chiste)
    {
        chiste.transform.position = chiste.transform.position + new Vector3(100, 100, 100);
        yield return new WaitForSeconds(sceneManager.tiempoVidaLacayos);
       
        Destroy(chiste);
    }
    #endregion

    #region BeanSpawn
    void RandomBean(GameObject lacayo)
    {
        Debug.Log("LLegue a las habas");
        int ramdomBean = Random.Range(0, 100);

        Transform handlerbean = lacayo.GetComponentInChildren<Transform>();
        if(ramdomBean < sceneManager.probalidadSpawnbeanLisa)
        {
            Instantiate(beanLisa, handlerbean.transform.position - new Vector3(0,2, 0), Quaternion.identity).transform.SetParent(lacayo.transform.GetChild(0));
        }
        else if (sceneManager.probalidadSpawnbeanLisa <= ramdomBean && ramdomBean < sceneManager.probalidadSpawnbeanRallada)
        {
            Instantiate(beanRallada, handlerbean.transform.position - new Vector3(0, 2, 0), Quaternion.identity).transform.SetParent(lacayo.transform.GetChild(0));
        }
        else if (sceneManager.probalidadSpawnbeanRallada <= ramdomBean && ramdomBean < sceneManager.probalidadSpawnbeanPuntos)
        {
            Instantiate(beanPuntos, handlerbean.transform.position - new Vector3(0, 2, 0), Quaternion.identity).transform.SetParent(lacayo.transform.GetChild(0));
        }
        if (sceneManager.probalidadSpawnbeanPuntos <= ramdomBean && ramdomBean <= sceneManager.probalidadSpawnbeanEstrellada)
        {
            Instantiate(beanEstrellada, handlerbean.transform.position - new Vector3(0, 2, 0), Quaternion.identity).transform.SetParent(lacayo.transform.GetChild(0));
        }

    }
    #endregion

    #region SpawSombrero
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
    #endregion

    #region Chistes
    void ElegirTipoChiste()
    {
        int randomlacayo = Random.Range(0, 100);


        if (randomlacayo < sceneManager.probabilidadSpawnChistePobreza)
        {
            GameObject chiste;
            chiste = ChistePobreza();
            GameObject chistenuevo;
            chistenuevo = Instantiate(chiste, RandomSpawnChistes().position, Quaternion.identity);
            StartCoroutine(DestruirChistes(chistenuevo));

        }
        else if (sceneManager.probabilidadSpawnChistePobreza <= randomlacayo && randomlacayo < sceneManager.probabilidadSpawnChisteAnimales)
        {
            GameObject chiste;
            chiste = ChisteAnimales();
            GameObject chistenuevo;
            chistenuevo = Instantiate(chiste, RandomSpawnChistes().position, Quaternion.identity);
            StartCoroutine(DestruirChistes(chistenuevo));
        }
        else if (sceneManager.probabilidadSpawnChisteAnimales <= randomlacayo && randomlacayo < sceneManager.probabilidadSpawnChisteAmor)
        {
            GameObject chiste;
            chiste = ChisteAmor();
            GameObject chistenuevo;
            chistenuevo = Instantiate(chiste, RandomSpawnChistes().position, Quaternion.identity);
            StartCoroutine(DestruirChistes(chistenuevo));
        }
        if (sceneManager.probabilidadSpawnChisteAmor <= randomlacayo && randomlacayo < sceneManager.probabilidadSpawnChisteRopa)
        {
            GameObject chiste;
            chiste = ChisteRopa();
            GameObject chistenuevo;
            chistenuevo = Instantiate(chiste, RandomSpawnChistes().position, Quaternion.identity);
            StartCoroutine(DestruirChistes(chistenuevo));
        }
        chistesTime = 0;

    }

    public Transform RandomSpawnChistes()
    {
        int spawnRandom = Random.Range(0, 4);

        return spawnpointChistes[spawnRandom].transform;
    }

    public GameObject ChistePobreza()
    {
        int randomChiste = Random.Range(0, 4);
        GameObject chiste;

        chiste = chistesPobreza[randomChiste];

        return chiste;

    }
    public GameObject ChisteAnimales()
    {
        int randomChiste = Random.Range(0, 4);
        GameObject chiste;

        chiste = chistesAnimales[randomChiste];

        return chiste;

    }
    public GameObject ChisteAmor()
    {
        int randomChiste = Random.Range(0, 5);
        GameObject chiste;

        chiste = chistesAmor[randomChiste];

        return chiste;

    }
    public GameObject ChisteRopa()
    {
        int randomChiste = Random.Range(0, 4);
        GameObject chiste;

        chiste = chistesRopa[randomChiste];

        return chiste;

    }

    IEnumerator DestruirChistes(GameObject chiste)
    {
        yield return new WaitForSeconds(sceneManager.tiempoVidaChistes);
        Destroy(chiste);
    }
    #endregion 

}
