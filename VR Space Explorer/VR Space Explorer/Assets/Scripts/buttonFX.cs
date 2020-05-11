using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonFX : MonoBehaviour {

    // Use this for initialization
    private GvrAudioSource myFX;
    private AudioSource myFX1;
    public AudioClip clickFX;
    public AudioClip hoverFX;


    void Start()
    {
        myFX = this.gameObject.GetComponent<GvrAudioSource>();
        myFX1 = this.gameObject.GetComponent<AudioSource>();
    }
    

   
    public void  ClickedFX() {
        myFX.PlayOneShot(clickFX);
        myFX1.PlayOneShot(clickFX);
    }

    public void HoverFX() {
        myFX.PlayOneShot(hoverFX);
        myFX1.PlayOneShot(hoverFX);
    }
}
