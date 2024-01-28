using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_AudioManager : MonoBehaviour
{

    [Header("Objetos")]
    public AudioClip pato;
    public AudioClip confeti;
    public AudioClip haba;
    public AudioClip cajaDeMusica;
    public AudioClip juglar;
    public AudioClip chiste;
    public AudioClip reyMuyEnfadado;
    public AudioClip reyEnfadado;
    public AudioClip reySerio;
    public AudioClip reyContento;
    public AudioClip reyMuyContento;
    public AudioClip musicadeFondo;
    public AudioClip musicadeFondoIngame;
    public AudioClip musicadePasos;
    public AudioClip musicaTrompetasDerrota;
    public AudioClip musicaTrompetasVictoria;

    [Header("UI")]
    public AudioClip libro;
    public AudioClip boton;

    public AudioSource musicaEfectos;
    public AudioSource reyAudio;
    public AudioSource vinilo;
    public AudioSource menu;


    #region ObjetosJuego
    public void AudioPato(AudioSource audio)
    {
        audio.PlayOneShot(pato);
    }

    public void Audioconfeti()
    {
        musicaEfectos.PlayOneShot(confeti);
    }

    public void Audiohaba()
    {
        musicaEfectos.PlayOneShot(haba);
    }

    public void AudioCajaDeMusica()
    {
        vinilo.PlayOneShot(cajaDeMusica);
    }
    public void PararCajaDeMusica()
    {
        vinilo.Stop();
        Debug.Log("Stop");
    }
    public void AudioChiste()
    {
        musicaEfectos.PlayOneShot(chiste);
    }

    public void AudioTrompetasDerrota()
    {
        musicaEfectos.PlayOneShot(musicaTrompetasDerrota);
    }
    public void AudioTrompetasVictoria()
    {
        musicaEfectos.PlayOneShot(musicaTrompetasVictoria);
    }

    public void AudioReyMuyEnfadado()
    {
        reyAudio.Stop();
        reyAudio.PlayOneShot(reyMuyEnfadado);
    }
    public void AudioReyEnfadado()
    {
        reyAudio.Stop();
        reyAudio.PlayOneShot(reyEnfadado);
    }
    public void AudioReySerio()
    {
        reyAudio.Stop();
        reyAudio.PlayOneShot(reySerio);
    }
    public void AudioReyContento()
    {
        reyAudio.Stop();
        reyAudio.PlayOneShot(reyContento);
    }
    public void AudioReyMuyContento()
    {
        reyAudio.Stop();
        reyAudio.PlayOneShot(reyMuyContento);
    }
    #endregion

    public void AudioLibro()
    {
        musicaEfectos.PlayOneShot(libro);
    }

    public void AudioBoton()
    {
        musicaEfectos.PlayOneShot(boton);
    }
    public void MusicaDeFondo()
    {

        menu.Play();
        menu.clip = musicadeFondo;
    }
    public void CambioDeCanción()
    {
        menu.clip = musicadeFondoIngame;
        menu.Play();
    }

}
