﻿using UnityEngine;
using System.Collections;

public class Enemy_One : Enemy {



    float PatternDeltaTime = 0.0f;
    float EnemyPatternTime = 30.0f;

    void Awake()
    {
        StartCoroutine(Enemy_Start());
        
}
    // Use this for initialization
    void Start () {
        Enemy_BulletSpeed = 50f;
        Enemy_Hp =10;
        Enemy_MoveSpeed = 2.5f;
        PatternOne_DelayTime = 2.0f;
        PatternTwo_DelayTime = 2.0f;
        PatternThree_DelayTime = 3.0f;
        Enemy_Move();
        
    }

    // Update is called once per frame
    void Update() {
        if (StartCheck == false)
        { 
        Enemy_Die_Check("SCENE_TWO");
        

            PatternDeltaTime += Time.deltaTime;
            if (PatternDeltaTime > EnemyPatternTime)
            {
                PatternDeltaTime = -10000.0f; //계속해서 패턴 2를 코루틴 하는걸 방지하기 위해 한번 만 코루틴 해도 계속 생성됨.
                this.StartCoroutine("Pattern_Two", 10f);
            }
        Enemy_MoveCtrl();
        }
        else
        {
            transform.Translate(Vector2.down* Enemy_MoveSpeed * Time.deltaTime);//위로 speed만큼 이동
        }


    }

 
}
