using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPGauge : MonoBehaviour
{
    [SerializeField, Header("�̗͉摜�ԍ�")]
    private int indexHP;

    [SerializeField, Header("�̗͉摜�ԍ�")]
    private Sprite activeSprite;

    [SerializeField, Header("�̗͉摜�ԍ�")]
    private Sprite nonactiveSprite;

    // Update is called once per frame
    void Update()
    {
        if(indexHP <= PlayerComponent.GetInstance().GetHp())
        {
            // �摜�̕\��
            GetComponent<Image>().sprite = activeSprite;
        }
        else
        {
            // �摜�̔�\��
            GetComponent<Image>().sprite = nonactiveSprite;
        }
    }
}
