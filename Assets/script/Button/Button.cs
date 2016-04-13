using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Button : MonoBehaviour {

	public void StartGUI()
    {
        SceneManager.LoadScene("SCENE_ONE");
    }
    public void ManualGUI()
    {
        SceneManager.LoadScene("MANUAL");
    }
    public void ExitGUI()
    {
        Application.Quit();
    }
    public void MaualGUI_Back()
    {
        SceneManager.LoadScene("StartScene");
    }
}
