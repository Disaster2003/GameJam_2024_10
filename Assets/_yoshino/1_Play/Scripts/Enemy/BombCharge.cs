using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCharge : MonoBehaviour
{
    private GameObject UICounter; // �A�C�e���J�E���^�[
    private float speedMove;      // �ړ����x
    [SerializeField] float accel; // �����x
    private float timer;          // �^�C�}�[

    // Start is called before the first frame update
    void Start()
    {
        UICounter = GameObject.Find("txtTimer");
        speedMove = 0; // �ړ����x�̏�����
        timer = 1;     // �^�C�}�[�̏�����
    }

    // Update is called once per frame
    void Update()
    {
        // �J�������ł̃��[���h���W�ɕϊ�����
        Vector3 UIposition = Camera.main.ScreenToWorldPoint(UICounter.GetComponent<RectTransform>().transform.position);
        if (Vector3.Distance(transform.position, UIposition) < 1)
        {
            // ���g��j������
            Destroy(gameObject);
        }
        else if(timer <= 0)
        {
            // �A�C�e���̃J�E���g�����Ă���UI�ɋ߂Â�
            transform.position = Vector3.MoveTowards(transform.position, UIposition, speedMove);
            speedMove += accel * Time.deltaTime;
        }
        else
        {
            // ���Ԍo��
            timer += -Time.deltaTime;
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
