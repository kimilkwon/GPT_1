using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Button : MonoBehaviour {


    StartSound sound =null;
    void Awake()
    {
        sound = GameObject.Find("StartBG").GetComponent<StartSound>();
    }
    

    public void StartGUI()
    {
        AutoFade.LoadLevel("SCENE_ONE", 4, 3, Color.black);
        StartCoroutine(sound.stop());
    }
    public void ManualGUI()
    {
        //SceneManager.LoadScene("MANUAL");
        AutoFade.LoadLevel("MANUAL", 1, 3, Color.black);
    }
    public void ExitGUI()
    {
      //  animator.Play("ExitAnimaiton");
        Application.Quit();
    }
    public void MaualGUI_Back()
    {
        SceneManager.LoadScene("StartScene");
        //AutoFade.LoadLevel("StartScene", 1, 3, Color.black);
     
    }
}
