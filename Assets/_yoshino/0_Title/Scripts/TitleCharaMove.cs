using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCharaMove : MonoBehaviour
{
    public float speed = 2.0f;          // ˆÚ“®‘¬“x
    public float moveDistance = 50.0f;  // ˆÚ“®‹——£

    private RectTransform rectTransform;
    private float initialY;
    private bool movingUp = false;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        initialY = rectTransform.anchoredPosition.y;    //‰ŠúˆÊ’u‚ÌŠl“¾
    }

    void Update()
    {
        Vector2 position = rectTransform.anchoredPosition;

        //ã•ûŒü‚Ö‚ÌˆÚ“®
        if (movingUp)
        {
            position.y += speed * Time.deltaTime;
            if (position.y >= initialY + moveDistance)
            {
                position.y = initialY + moveDistance;
                movingUp = false;
            }
        }
        //‰º•ûŒü‚Ö‚ÌˆÚ“®
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
