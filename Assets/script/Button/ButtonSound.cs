using UnityEngine;
using System.Collections;

public class ButtonSound : MonoBehaviour {

    public AudioSource Audio;

    void Awake()
    {
        Audio = GetComponent<AudioSource>();
    }
     void OnMouseEnter()
    {
        Audio.Play();
    }
}
