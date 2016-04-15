using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Button : MonoBehaviour {
 


    public void StartGUI()
    {
        AutoFade.LoadLevel("SCENE_ONE", 1, 3, Color.black);
        
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
