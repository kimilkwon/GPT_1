using UnityEngine;
using System.Collections;

public class LaserChange : MonoBehaviour {

    public GameObject Laser_R =null;
    public GameObject Laser_B = null;

    public bool Change = true;

   void Change_Laser()
    {
        if(Change==true)
        {
            Delete();
            Debug.Log("1");
            Instantiate(Laser_B, this.transform.position, Quaternion.identity);
        }
        else
        {
            Delete();
            Debug.Log("2");
            Instantiate(Laser_R, this.transform.position, Quaternion.identity);
        }
    }
    public void BoolTurn()
    {
        if (Change == true)
        {
            Change = false;
            Change_Laser();
        }
        else
        {
            Change = true;
            Change_Laser();
        }
    }

    void Delete()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("LaserUI");

        // Bullet 태그를 가진 오브젝트를 모두 찾아서 배열에 추가
        foreach (GameObject ob in obj)
        {
            Destroy(ob);
            
        }
    }
    // Use this for initialization
    void Start () {
        Change_Laser();
    }
	
	// Update is called once per frame
	void Update () {
        

    }
}
