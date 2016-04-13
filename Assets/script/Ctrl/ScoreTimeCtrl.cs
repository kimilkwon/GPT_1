using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreTimeCtrl : MonoBehaviour {


    private int Score = 0;
    public Text ScoreText = null;
    private float Time_ = 0;
    public Text TimeText = null;
    private int Hp = 0;
    public Text Hp_Text = null;
    // Use this for initialization
    void Start () {
        Ctrl.HP = 5;
        ScoreUp(Ctrl.Score_Static);
        TimeUp(Ctrl.Time_Static);
        Hp_Center(Ctrl.HP);
    }
	
	// Update is called once per frame
	public void ScoreUp(int iScore) {
        Score += iScore;
        ScoreText.text = "Score : " + Score.ToString();
        Ctrl.Score_Static += iScore;
    }
    public void TimeUp(float time)
    {
        Time_ += time;
        TimeText.text = "Time : " + Time_.ToString();
        Ctrl.Time_Static += time;
    }
    public void Hp_Center(int min)
    {
        Hp = min;
        Hp_Text.text = "X " + Hp.ToString();
        
    }

    void Update()
    {
      
    }
}
