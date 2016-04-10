using UnityEngine;
using System.Collections;
[RequireComponent (typeof(Animator))]

public class PlayerCtrl : MonoBehaviour {
    public const float ShieldCoolTime = 10;
    float Player_Speed = 2.0f;
    public int hp = 5;//플레이어 Hp
    bool Die = false;//죽었는지 안죽었는지
    bool Change = false;
    public GameObject laser = null;
    public GameObject shield = null;

    public float move_speed = 5.0f;
    Animator animator;
   


   
    int Shield_Check =0;
    int Shot_Check = 0;
    private ShieldUI SU = null;
    public void PlayerHit()//EnemyCtrl스크립트에서 충돌시 불러줄꺼임
    {
        if (hp <= 0)//만약 Hp가 0이하로 떨어지면
        {
            Die = true;//Die는 참
        }

        StartCoroutine(PlayerChange());

    }
   

    private IEnumerator PlayerChange()
    {
        SpriteRenderer sprite = GetComponentInChildren<SpriteRenderer>();

        sprite.color = Color.red;

        yield return new WaitForSeconds(0.1f);

        sprite.color = Color.white;

        yield return null;

    }

    void Player_Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow) & transform.position.x >= -3)//왼쪽을 눌렀다면
        {
            transform.Translate(Vector2.left * Player_Speed * Time.deltaTime);//왼쪽으로 speed만큼 이동
            
        }
        if (Input.GetKey(KeyCode.RightArrow) & transform.position.x <= 3)//오른쪽을 눌렀다면
        {
            transform.Translate(Vector2.right * Player_Speed * Time.deltaTime);//오른쪽으로 speed만큼 이동
           
        }
        if (Input.GetKey(KeyCode.UpArrow) & transform.position.y <= 4.5)//위를 눌렀다면
        {
            transform.Translate(Vector2.up * Player_Speed * Time.deltaTime);//위로 speed만큼 이동
            
        }
        if (Input.GetKey(KeyCode.DownArrow) & transform.position.y >= -4.5)//아래를 눌렀다면
        {
            transform.Translate(Vector2.down * Player_Speed * Time.deltaTime);//아래로 speed만큼 이동
          
        }
        if (Input.GetKeyDown(KeyCode.Space))//스페이스바를 눌렀다면
        {
            StartCoroutine(Player_Attack());
            


        }
        if (Input.GetKeyDown(KeyCode.X))//x를 눌렀다면
        {
            StartCoroutine(Player_Shield());
        }


    }
    public IEnumerator Player_Attack()
    {
        if (Shot_Check == 0)
        {
            Shot_Check++;
            animator.Play("SHOT");
              

            
            Instantiate(laser, new Vector3(this.transform.position.x+0.5f, this.transform.position.y+0.7f, this.transform.position.z), Quaternion.identity);
            yield return new WaitForSeconds(0.2f); // 레이저 무자비 생성 방지
            yield return null;
            Shot_Check--;
        }
        animator.Play("PLAY");
    }
    public IEnumerator Player_Shield()
    {
       
        if (Shield_Check == 0)
        {
            Shield_Check++;
            SU.leftTime = ShieldCoolTime;
            Instantiate(shield, this.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(ShieldCoolTime); // 쿨타임
            yield return null;
            Shield_Check--;
            
        }
    }

    IEnumerator Player_Die()
    {
        transform.localScale = new Vector2(transform.localScale.x - 0.1f, transform.localScale.y - 0.1f);//스케일은 작아짐
        transform.Rotate(new Vector3(0, 0, 10));//계속 회전함
        yield return new WaitForSeconds(1.2f); // 쿨타임
        yield return null;
        Destroy(this.gameObject);//자기 자신 삭제
       
    }


    void Awake()
    {
        SU = GameObject.Find("ShieldCoolTime").GetComponent<ShieldUI>();
        animator = GetComponent<Animator>();
    }
    public void start()
    {
       
    }
    void Update()
    {


        if (Die == true)//Die가 참이라면
        {
           StartCoroutine(Player_Die());
        }
        else if (Die == false)
        {
            Player_Move();

        }
    }

 }


