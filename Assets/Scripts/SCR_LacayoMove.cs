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
            // Calcula la interpolación lineal entre puntoInicial y puntoFinal
            float t = tiempoPasado / duracion;
            transform.position = Vector3.Lerp(puntoInicial.position, puntoFinal.position, t);

            // Actualiza el tiempo pasado
            tiempoPasado += Time.deltaTime;

            // Espera hasta el siguiente frame
            yield return null;
        }

        // Asegúrate de que el objeto esté exactamente en la posición final
        transform.position = puntoFinal.position;
    }
}
