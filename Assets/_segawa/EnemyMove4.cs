using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymove4 : MonoBehaviour
{
    public Vector2 titen;           //�~�܂�ꏊ
    public float MoveLeftSpeed;     //���ړ��̑��x
    public float MoveUpSpeed;       //�㉺�̑��x
    public float Wait;              //�҂�����

    private int yoko;               //���ړ�����c�ړ��ɕς���
    private float matizikan;        // �҂����Ԃ̏���
    // Start is called before the first frame update
    void Start()
    {
        yoko = 0;
    }

    // Update is called once per frame
    void Update()
    {
        LeftRight(1);   //�E���̎w�肳�ꂽ�����ֈړ� 
        LeftRight(-1);  //�����̎w�肳�ꂽ�����ֈړ�
        Updown(1); //��Ɉړ�
        Updown(-1); //���Ɉړ�
        wait();
    }

    //titen.y ��-��������
    //matizikan ��ݒ肷��
    private void Way()
    {
        titen.y *= -1;
        matizikan =Wait;
    }

    //���E�Ɉړ�����
    private void LeftRight(int left)
    {
        if (left*transform.position.x < left*titen.x && yoko == 0)    
        {
            transform.Translate(new Vector2(left * MoveLeftSpeed * Time.deltaTime, 0));
            if (left * transform.position.x >= left * titen.x) yoko = 1;  //���ړ�����c�ړ��ɕς���
        }
    }

    //�㉺�Ɉړ�����
    private void Updown(int up)
    {
        if (up*transform.position.y < up*titen.y && yoko == 1 && matizikan <= 0)  
        {
            transform.Translate(new Vector2(0, up * MoveLeftSpeed * Time.deltaTime));
            if (up * transform.position.y >= up * titen.y) Way();
        }
    }

    //�҂����Ԃ̏���
    private void wait()
    {
        if (matizikan > 0)
        {
            matizikan -= Time.deltaTime;
        }
    }

}
