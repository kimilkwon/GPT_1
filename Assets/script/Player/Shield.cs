using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    void OnTriggerEnter2D(Collider2D coll)//충돌 체크 함수
    {
        if (coll.gameObject.tag == "BULLET_R")
        {
           
            Destroy(coll.gameObject);
        }
        if (coll.gameObject.tag == "BULLET_B")
        {
          
            Destroy(coll.gameObject);
        }


    }

    // Update is called once per frame
    void Update () {
        Move();
        Destroy(this.gameObject,3.9f);
    }
    void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow) & transform.position.x >= -3)//왼쪽을 눌렀다면
        {
            transform.Translate(Vector2.left * 2.0f * Time.deltaTime);//왼쪽으로 speed만큼 이동

        }
        if (Input.GetKey(KeyCode.RightArrow) & transform.position.x <= 3)//오른쪽을 눌렀다면
        {
            transform.Translate(Vector2.right * 2.0f * Time.deltaTime);//오른쪽으로 speed만큼 이동

        }
        if (Input.GetKey(KeyCode.UpArrow) & transform.position.y <= 4.5)//위를 눌렀다면
        {
            transform.Translate(Vector2.up * 2.0f * Time.deltaTime);//위로 speed만큼 이동

        }
        if (Input.GetKey(KeyCode.DownArrow) & transform.position.y >= -4.5)//아래를 눌렀다면
        {
            transform.Translate(Vector2.down * 2.0f * Time.deltaTime);//아래로 speed만큼 이동

        }
       


    }
}
