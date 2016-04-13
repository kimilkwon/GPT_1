using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Animator))]
public class Laser : MonoBehaviour
{
    public float LaserSpeed = 12f;
    const int RED = 1;
    const int BLUE = 0;
    Enemy EM = null;
    PlayerCtrl PLAYER = null;
    BoxCollider2D bc = null;
    private ScoreTimeCtrl SC = null;
    public int Laser_Kind  ;
    bool die = false;
    Animator animator;
    void Awake()
    {
        bc = GetComponent<BoxCollider2D>();//BoxCollider2D를 넣어줌
        EM = GameObject.FindWithTag("ENEMY").GetComponent<Enemy>(); 
        SC = GameObject.Find("Center").GetComponent<ScoreTimeCtrl>();
        PLAYER = GameObject.Find("player_0(Clone)").GetComponent<PlayerCtrl>();
        animator = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D coll)//충돌 체크 함수
    {
        if (coll.gameObject.tag == "ENEMY")
        {
            die = true;
            EM.Enemy_Hp -= 1;// Hp를 하나 깎음 
            EM.Enemy_Hit();
            StartCoroutine(Laser_Destroy());


        }

        if (coll.gameObject.tag == "BULLET_R" && Laser_Kind==RED)
        {
            die = true;
           StartCoroutine(Laser_Destroy());
            
            SC.ScoreUp(10);
            Destroy(coll.gameObject);
        }
        if (coll.gameObject.tag == "BULLET_B" && Laser_Kind == BLUE)
        {
            die = true;
            StartCoroutine(Laser_Destroy());

            SC.ScoreUp(10);
            Destroy(coll.gameObject);
        }


    }
    public IEnumerator Laser_Destroy()
    {
        if (PLAYER.Change == false)
        {
            animator.Play("Laser_boom");
            yield return new WaitForSeconds(0.2f);
            Destroy(this.gameObject);
        }
        else
        {
            animator.Play("Laser_boomR");
            yield return new WaitForSeconds(0.2f);
            Destroy(this.gameObject);
        }
        yield return null;
    }
    public IEnumerator Laser_Set()
    {
        if (PLAYER.Change == false)
        {
           animator.Play("Laser_Play");
           Laser_Kind = BLUE;
        }
        else
        {
            animator.Play("Laser_PlayR");
            Laser_Kind = RED;
        }
        yield return null;
    }



    void Start()
    {
        StartCoroutine(Laser_Set());
        Destroy(this.gameObject, 2f);
       
    }

    // Update is called once per frame
    void Update()
    {
        if (die == false)
        {
            transform.Translate(Vector2.up * LaserSpeed * Time.deltaTime);
            
        }
        
    }

}
