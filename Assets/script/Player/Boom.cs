using UnityEngine;
using System.Collections;

public class Boom : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D coll)//충돌 체크 함수
    {

        if (coll.gameObject.tag == "BULLET_R" )
        {
            
            Destroy(coll.gameObject);
        }
        if (coll.gameObject.tag == "BULLET_B")
        {
          
            Destroy(coll.gameObject);
        }


    }
    void Start()
    {
        Destroy(this.gameObject, 5f);
    }
    void Update()
    {
       
            transform.Translate(Vector2.up * 3f * Time.deltaTime);

      

    }
    
}
     
