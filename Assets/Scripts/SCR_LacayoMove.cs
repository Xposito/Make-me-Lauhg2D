using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_LacayoMove : MonoBehaviour
{
    Transform puntoInicial;
    public Transform puntoFinal;
    public float duracion = 5f;

    void Start()
    {
        // Inicia la coroutine para el movimiento
        StartCoroutine(MoverObjetoEnElTiempo());
    }

    IEnumerator MoverObjetoEnElTiempo()
    {
        float tiempoPasado = 0f;

        while (tiempoPasado < duracion)
        {
            // Calcula la interpolaci�n lineal entre puntoInicial y puntoFinal
            float t = tiempoPasado / duracion;
            transform.position = Vector3.Lerp(puntoInicial.position, puntoFinal.position, t);

            // Actualiza el tiempo pasado
            tiempoPasado += Time.deltaTime;

            // Espera hasta el siguiente frame
            yield return null;
        }

        // Aseg�rate de que el objeto est� exactamente en la posici�n final
        transform.position = puntoFinal.position;
    }
}
