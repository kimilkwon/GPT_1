using UnityEngine;
using System.Collections;

public class IntroScene : MonoBehaviour {

    float volume = 1.0f;
    StartSound startsound;
    IEnumerator Intro()
    
    {
        yield return new WaitForSeconds(20.0f); 
        AutoFade.LoadLevel("SCENE_ONE", 4, 3, Color.black);
        StartCoroutine(startsound.stop());
        yield return null;
    }
    void Awake()
    {
        startsound = GameObject.Find("StartBG").GetComponent<StartSound>();
    }
    // Update is called once per frame
    void Start () {
        StartCoroutine(Intro());
        
    }


}
