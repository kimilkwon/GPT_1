using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Animator))]
public class Laser : MonoBehaviour
{
    public float LaserSpeed = 12f;
    
    Enemy EM = null;
    BoxCollider2D bc = null;
    private ScoreCtrl SC = null;
    public int Laser_Kind  ;
    bool die = false;
    Animator animator;
    void Awake()
    {
        bc = GetComponent<BoxCollider2D>();//BoxCollider2D를 넣어줌
        EM = GameObject.FindWithTag("ENEMY").GetComponent<Enemy>(); 
        SC = GameObject.Find("Center").GetComponent<ScoreCtrl>();
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

        if (coll.gameObject.tag == "BULLETS")
        {
            die = true;
           StartCoroutine(Laser_Destroy());
            
            SC.ScoreUp(10);
           
        }


    }
    public IEnumerator Laser_Destroy()
    {
        
        animator.Play("Laser_boom");
        yield return new WaitForSeconds(0.2f);
        Destroy(this.gameObject);

        yield return null;
    }


    public void Laser_Change()
    {
        Laser_Kind = 1;
    }
    void Start()
    {
        Destroy(this.gameObject, 2f);
        if(Laser_Kind == 1 )
        {
            SpriteRenderer sprite = GetComponentInChildren<SpriteRenderer>();

            sprite.color = Color.red;
        }
        if (Laser_Kind == 0)
        {
            SpriteRenderer sprite = GetComponentInChildren<SpriteRenderer>();

            sprite.color = Color.white;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(die==false)
        transform.Translate(Vector2.up * LaserSpeed * Time.deltaTime);
   
    }

}
