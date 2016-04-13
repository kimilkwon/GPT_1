using UnityEngine;
using System.Collections;

public class Enemy_Two : Enemy {

    float PatternDeltaTime = 0.0f;
    float EnemyPatternTime = 10.0f;

    void Awake()
    {
        StartCoroutine(Enemy_Start());

    }
    // Use this for initialization
    void Start()
    {
        Enemy_BulletSpeed = 50f;
        Enemy_Hp = 30;
        Enemy_MoveSpeed = 3.0f;
        PatternOne_DelayTime = 2.0f;
        PatternTwo_DelayTime = 1.5f;
        PatternThree_DelayTime = 1.5f;
        Enemy_Move();
      
    }

    // Update is called once per frame
    void Update()
    {
        if (StartCheck == false)
        {
            Enemy_Die_Check("SCENE_TWO");


            PatternDeltaTime += Time.deltaTime;
            if (PatternDeltaTime > EnemyPatternTime)
            {
                PatternDeltaTime = -10000.0f; //계속해서 패턴 2를 코루틴 하는걸 방지하기 위해 한번 만 코루틴 해도 계속 생성됨.
                this.StartCoroutine("Pattern_Two", 15f);
            }
            Enemy_MoveCtrl();
        }
        else
        {
            transform.Translate(Vector2.down * Enemy_MoveSpeed * Time.deltaTime);//위로 speed만큼 이동
        }


    }


}
