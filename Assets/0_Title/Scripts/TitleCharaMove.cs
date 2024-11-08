using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCharaMove : MonoBehaviour
{
    public float speed = 2.0f;          // �ړ����x
    public float moveDistance = 50.0f;  // �ړ�����

    private RectTransform rectTransform;
    private float initialY;
    private bool movingUp = false;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        initialY = rectTransform.anchoredPosition.y;    //�����ʒu�̊l��
    }

    void Update()
    {
        Vector2 position = rectTransform.anchoredPosition;

        //������ւ̈ړ�
        if (movingUp)
        {
            position.y += speed * Time.deltaTime;
            if (position.y >= initialY + moveDistance)
            {
                position.y = initialY + moveDistance;
                movingUp = false;
            }
        }
        //�������ւ̈ړ�
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
