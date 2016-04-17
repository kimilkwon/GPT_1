using UnityEngine;
using System.Collections;

public class Center : MonoBehaviour {

    ScoreTimeCtrl SC= null;

    float StartTime = 0.0f;
    //float Time = 0.0f;
    public GameObject Enemy;
    public GameObject Player;
    Vector3 EnemyPosition = new Vector3(0, 8, 0); // 시작 최종 위치 0,4,0
    Vector3 PlayerPosition = new Vector3(0, -8, 0); //시작 최종 위치 0,-4,0
    // Use this for initialization
    void Start () {
        
        Instantiate(Player, PlayerPosition, Quaternion.identity);
        Instantiate(Enemy, EnemyPosition, Quaternion.identity);
        StartCoroutine(TIMEUPDATE());

    }
	void Awake()
    {
       
        SC = GameObject.Find("Center").GetComponent<ScoreTimeCtrl>();
    }
	// Update is called once per frame
	void Update () {
        //tartTime += Time.deltaTime;
      
    }
    public IEnumerator TIMEUPDATE()
    {
            yield return new WaitForSeconds(0.100f); // 쿨타임
            SC.TimeUp(0.100f);
            SC.Hp_Center(Ctrl.HP);
        yield return null;
        StartCoroutine(TIMEUPDATE());

    }
}
