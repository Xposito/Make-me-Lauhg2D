using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Update : MonoBehaviour
{
    // Start is called before the first frame update

    public SCO_SceneManager sceneManager;

    private void Start()
    {
        sceneManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SCR_Holder>().sceneManager;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            
            if (sceneManager.stopTime)
            {
                sceneManager.stopTime = false;
            }
            transform.gameObject.SetActive(false);
        }
    }
}
