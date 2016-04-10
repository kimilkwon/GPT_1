using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShieldUI : MonoBehaviour {
    public Image img;
    public UnityEngine.UI.Button button;
    public float coolTime = 12.0f;
    public bool disableOnStart = false;
    public float leftTime = 0.0f;
	// Use this for initialization
	void Start () {
	if(img ==null)
        {
            img = gameObject.GetComponent<Image>();
            
        }
    if(button == null)
        {
            button = gameObject.GetComponent<UnityEngine.UI.Button>();
        }
        if (disableOnStart)
            ResetCoolTime();
	}
   
    // Update is called once per frame
    void Update () {
	if(leftTime>0)
        {
            leftTime -= Time.deltaTime;
            if(leftTime<0)
            {
                leftTime = 0;
                if(button)
                {
                    button.enabled = true;
                }
            }
            float ratio = 1.0f - (leftTime / coolTime);
            if (img)
                img.fillAmount = ratio;

        }
	}
    public bool Check_CoolTime()
    {
        if (leftTime > 0)
        {
            return false;
        }
        else
            return true;
    }
    public void ResetCoolTime()
    {
        leftTime = coolTime;
        if (button)
            button.enabled = false;
    }
}
