using UnityEngine;
using System.Collections;

public class StartSound : MonoBehaviour {

    //public AudioSource StartAudio;
     static bool isPlaying = false;
    float volume = 1.0f;
    // Use this for initialization
    void Awake()
    {

        //StartAudio = GetComponent<AudioSource>();
       
    }
    void Start () {
       
        //StartAudio.Play();
        DontDestroyOnLoad(transform.gameObject);
        if (!isPlaying)
        {
            GetComponent<AudioSource>().Play();
            isPlaying = true;
        }

    }

    public IEnumerator stop()
    {
       while(volume >= 0.0f)
        {
            GetComponent<AudioSource>().volume = volume;
            yield return new WaitForSeconds(0.25f);
            volume -= 0.1f;
        }
        GetComponent<AudioSource>().Stop();
        yield return null;
        Debug.Log("SOUNDOFF");
    }
	
	
	


}
