using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BombUI : ShieldUI {
    void Start()
    {
        if (img == null)
        {
            img = gameObject.GetComponent<Image>();

        }
        if (button == null)
        {
            button = gameObject.GetComponent<UnityEngine.UI.Button>();
        }
        if (disableOnStart)
            ResetCoolTime();
    }

    // Update is called once per frame
    void Update()
    {
        Left_Time();

    }

}
