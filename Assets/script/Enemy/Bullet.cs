using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

    void OnBecameInvisible() //화면에서 탄막이 나가면 삭제시킨다.
    {
        Destroy(this.gameObject);
    }

}