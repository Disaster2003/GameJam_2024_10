using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPGauge : MonoBehaviour
{
    [SerializeField, Header("�̗͉摜�ԍ�")]
    private int indexHP;

    // Update is called once per frame
    void Update()
    {
        if(indexHP <= PlayerComponent.GetInstance().GetHp())
        {
            // �摜�̕\��
            GetComponent<Image>().enabled = true;
        }
        else
        {
            // �摜�̔�\��
            GetComponent<Image>().enabled = false;
        }
    }
}
