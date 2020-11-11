using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpsound : MonoBehaviour
{    
    AudioSource soundsource;
    void Start()
    {
        soundsource = this.GetComponent<AudioSource>();
    }

    public void onjumpclick(){
    	soundsource.loop = false;
        soundsource.Play();
    }

}
