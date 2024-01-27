using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_CalculoTiempo : MonoBehaviour
{
    private float currentTime = 0f;
    private float targetTime = 120f; // Tiempo deseado de espera en segundos
    private bool isWaiting = false;

    void Update()
    {
        // Lógica personalizada de tiempo
        currentTime += Time.deltaTime;

        // Comienza la espera cuando se presiona la tecla 'Espacio'
        if (Input.GetKeyDown(KeyCode.Space) && !isWaiting)
        {
            StartCoroutine(CustomWait());
        }
    }

    // Coroutine personalizada para la espera
    IEnumerator CustomWait()
    {
        isWaiting = true;

        while (currentTime < targetTime)
        {
            // Puedes realizar acciones mientras esperas, si es necesario
            Debug.Log("Esperando...");

            yield return null;
        }

        // Restablece el tiempo y realiza acciones después de la espera
        currentTime = 0f;
        isWaiting = false;
        Debug.Log("Espera completada");
    }
}
