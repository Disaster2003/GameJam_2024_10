using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCharge : MonoBehaviour
{
    private GameObject UICounter;
    private float speedMove;
    [SerializeField, Header("�����x")]
    private float accel;
    [SerializeField, Header("�ҋ@����")]
    private float timerWait;

    // Start is called before the first frame update
    void Start()
    {
        UICounter = GameObject.Find("txtTimer");
        speedMove = 0; // �ړ����x�̏�����
    }

    // Update is called once per frame
    void Update()
    {
        // �J�������ł̃��[���h���W�ɕϊ�
        Vector3 UIposition = Camera.main.ScreenToWorldPoint(UICounter.GetComponent<RectTransform>().transform.position);
        if (Vector3.Distance(transform.position, UIposition) < 1)
        {
            // ���g�̔j��
            Destroy(gameObject);
        }
        else if(timerWait <= 0)
        {
            // �A�C�e���̃J�E���g�����Ă���UI�ɋ߂Â�
            transform.position = Vector3.MoveTowards(transform.position, UIposition, speedMove);
            speedMove += accel * Time.deltaTime;
        }
        else
        {
            // ���Ԍo��
            timerWait += -Time.deltaTime;
        }
    }

    private void OnDestroy()
    {
        // null�`�F�b�N
        if (UICounter == null) return;

        // �A�C�e������+1����
        UICounter.GetComponent<ItemCounter>().IncreaseBombChargeCounter();
    }
}
