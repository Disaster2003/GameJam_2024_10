using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCharaMove : MonoBehaviour
{
    public float speed = 2.0f;          // 移動速度
    public float moveDistance = 50.0f;  // 移動距離

    private RectTransform rectTransform;
    private float initialY;
    private bool movingUp = false;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        initialY = rectTransform.anchoredPosition.y;    //初期位置の獲得
    }

    void Update()
    {
        Vector2 position = rectTransform.anchoredPosition;

        //上方向への移動
        if (movingUp)
        {
            position.y += speed * Time.deltaTime;
            if (position.y >= initialY + moveDistance)
            {
                position.y = initialY + moveDistance;
                movingUp = false;
            }
        }
        //下方向への移動
        else
        {
            position.y -= speed * Time.deltaTime;
            if (position.y <= initialY - moveDistance)
            {
                position.y = initialY - moveDistance;
                movingUp = true;
            }
        }

        rectTransform.anchoredPosition = position;
    }
}
