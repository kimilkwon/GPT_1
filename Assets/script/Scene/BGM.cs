using UnityEngine;
using System.Collections;

public class BGM : MonoBehaviour {
    float volume = 1.0f;
    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(transform.gameObject);
        GetComponent<AudioSource>().Play();
    }
    public IEnumerator stop()
    {
        while (volume >= 0.0f)
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
