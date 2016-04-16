using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class HowToButton : MonoBehaviour {

    public void MaualGUI_Back()
    {

        AutoFade.LoadLevel("StartScene", 2, 3, Color.black);
    }
   
}
