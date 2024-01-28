using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_AudioManager : MonoBehaviour
{

    [Header("Objetos")]
    public AudioClip pato;
    public AudioClip confeti;
    public AudioClip CajadeMusica;
    public AudioClip juglar;



    public AudioClip musicadeFondo;
    public AudioClip musicadePasos;
    public AudioClip musicaTrompetas;
    
    public void AudioPato(AudioSource audio)
    {
        audio.PlayOneShot(pato);
    }

}
