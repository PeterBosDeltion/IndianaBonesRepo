using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickSound : MonoBehaviour {

    public AudioClip kickSound;
    public AudioSource audioS;


    void Start()
    {

    }

    void Kicking()
    {
        audioS.PlayOneShot(kickSound);
    }
}

