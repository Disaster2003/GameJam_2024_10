using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPGauge : MonoBehaviour
{
    [SerializeField, Header("体力画像番号")]
    private int indexHP;

    // Update is called once per frame
    void Update()
    {
        if(indexHP <= PlayerComponent.GetInstance().GetHp())
        {
            // 画像の表示
            GetComponent<Image>().enabled = true;
        }
        else
        {
            // 画像の非表示
            GetComponent<Image>().enabled = false;
        }
    }
}
