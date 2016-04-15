using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent (typeof(Animator))]

public class PlayerCtrl : MonoBehaviour {
    public const float ShieldCoolTime = 3.8f;
    public const float BombCoolTime = 12.0f;
    float Player_Speed = 2.0f;
    public int hp = 5;//플레이어 Hp
    bool Die = false;//죽었는지 안죽었는지
    public bool Change = false;
    public GameObject laser_B = null;
    public GameObject laser_R = null;

    public GameObject shield = null;
    BoxCollider2D bc = null;

    public float move_speed = 5.0f;
    Animator animator;


    LaserChange LC = null;

    int Shield_Check =0;
    int Shot_Check = 0;
	int Shield_Cool_Check =0;
    int Bomb_Check = 0;

    bool StartCheck = true;

    private ShieldUI SU = null;
    private ShieldUI BU = null;//필살기 ui
    public void PlayerHit()//EnemyCtrl스크립트에서 충돌시 불러줄꺼임
    {
        
       
        if (hp <= 0)//만약 Hp가 0이하로 떨어지면
        {
            Die = true;//Die는 참
        }

        StartCoroutine(PlayerChange());

    }
    void OnTriggerEnter2D(Collider2D coll)//충돌 체크 함수
    {
        if (coll.gameObject.tag == "BULLET_R")
        {
            hp -= 1;//주인공의 Hp를 하나 깎음 
            Ctrl.HP -= 1;
            PlayerHit();

            Destroy(coll.gameObject);
        }
        if (coll.gameObject.tag == "BULLET_B")
        {
            hp -= 1;//주인공의 Hp를 하나 깎음 
            PlayerHit();
            Ctrl.HP -= 1;
            Destroy(coll.gameObject);
        }


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
        if (Input.GetKeyDown(KeyCode.C))//C를 눌렀다면
        {
            StartCoroutine(Player_Bomb());
        }
        if (Input.GetKeyDown(KeyCode.Z))//C를 눌렀다면
        {
            StartCoroutine(Player_Laser_Change());
        }

    }
    public IEnumerator Player_Attack()
    {
        if (Shot_Check == 0 && Bomb_Check == 0)
        {
            Shot_Check++;
            
              

			if (Shield_Check == 0) {
				animator.Play ("player_attack");
                Laser_Choice();
                yield return new WaitForSeconds (0.2f); // 레이저 무자비 생성 방지
				yield return null;
				animator.Play("player_normal");
			} 
			else //쉴드 하고 공격할때 가운데에서 레이저 나가게끔.
			{

                Laser_Choice();
                yield return new WaitForSeconds(0.2f); // 레이저 무자비 생성 방지
				yield return null;
			}
            Shot_Check--;
        }
        
    }

    void Laser_Change()
    {
        if (Change == false)
        {
            Change = true;
        }
        else
            Change = false;
    }

    void Laser_Choice()
    {
        if (Change == false)
        {
            if (Shield_Check == 0)
            {
                Instantiate(laser_B, new Vector3(this.transform.position.x + 0.5f, this.transform.position.y + 0.9f, this.transform.position.z), Quaternion.identity);
            }
            else
            {
                Instantiate(laser_B, new Vector3(this.transform.position.x, this.transform.position.y + 0.9f, this.transform.position.z), Quaternion.identity);
            }
        }
        else
        {
            if (Shield_Check == 0)
            {
                Instantiate(laser_R, new Vector3(this.transform.position.x + 0.5f, this.transform.position.y + 0.9f, this.transform.position.z), Quaternion.identity);
            }
            else
            {
                Instantiate(laser_R, new Vector3(this.transform.position.x, this.transform.position.y + 0.9f, this.transform.position.z), Quaternion.identity);
            }
        }
    }
    public IEnumerator Player_Shield()
    {
       
		if (Shield_Cool_Check == 0 && Bomb_Check == 0)
        {
            Shield_Check++;
			Shield_Cool_Check++;
			animator.Play("player_shield");
            SU.coolTime = ShieldCoolTime * 2;
            SU.leftTime = ShieldCoolTime*2;
            Instantiate(shield, this.transform.position, Quaternion.identity);
			yield return new WaitForSeconds(ShieldCoolTime); // 쿨타임
			animator.Play("player_normal");
			Shield_Check --;
            yield return new WaitForSeconds(ShieldCoolTime); // 쿨타임
            yield return null;
			Shield_Cool_Check--;
            
        }

    }
    public IEnumerator Player_Start()
    {

        yield return new WaitForSeconds(2.5f);
        StartCheck = false;
        yield return null;
      

    }
    public IEnumerator Player_Laser_Change()
    {

        if (Shot_Check == 0 && Bomb_Check == 0)
        {
            Laser_Change();
            LC.BoolTurn();
             yield return new WaitForSeconds(0.4f); // 쿨타임
            yield return null;

        }

    }

    public IEnumerator Player_Bomb()
    {

        if (Bomb_Check == 0 && Shield_Check == 0 && Shot_Check ==0)
        {
            Bomb_Check++;
           
            animator.Play("player_shield");
            BU.leftTime = BombCoolTime;
            BU.coolTime = BombCoolTime;
            // Instantiate(shield, this.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(BombCoolTime/3); // 쿨타임
            animator.Play("player_normal");
            yield return new WaitForSeconds(BombCoolTime / 3);
            yield return new WaitForSeconds(BombCoolTime / 3);
            yield return null;
            Bomb_Check--;
           
        }

    }

    IEnumerator Player_Die()
    {
        transform.localScale = new Vector2(transform.localScale.x - 0.1f, transform.localScale.y - 0.1f);//스케일은 작아짐
        transform.Rotate(new Vector3(0, 0, 10));//계속 회전함
        yield return new WaitForSeconds(1.2f); // 쿨타임
        yield return null;
        Destroy(this.gameObject);//자기 자신 삭제
        
        AutoFade.LoadLevel("GAMEOVER", 2, 3, Color.black);



    }


void Awake()
    {
        SU = GameObject.Find("ShieldCoolTime").GetComponent<ShieldUI>();
        BU = GameObject.Find("BombCoolTime").GetComponent<ShieldUI>();
        LC = GameObject.Find("Bullet_RB").GetComponent<LaserChange>();
        bc = GetComponent<BoxCollider2D>();
     
             animator = GetComponent<Animator>();
        StartCoroutine(Player_Start());
    }
    public void start()
    {
        
    }
    void Update()
    {

        if (StartCheck == false)
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
        else
        {
            transform.Translate(Vector2.up * Player_Speed * Time.deltaTime);//위로 speed만큼 이동
        }
    }

 }


