using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove7 : Enemymove
{
    public float wait;          //�҂����Ԃ��w�肷��ϐ�

    private float matizikan;    //�҂����Ԃ̏���
    private int way;            //�����̏��� 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        matizikan += Time.deltaTime;
        //�����̎w��
        if (wait <= matizikan && way % 2 == 0)ReverseWay();
        else if (wait/2 <= matizikan&&way%2 == 1)ReverseWay();

        //�ړ�
        if(way%2== 0)Move();
        else ReverseMove();
    }

    //���Ε����Ɉړ�����
    private void ReverseMove()
    {
        transform.Translate(new Vector2(MoveSpeed * Time.deltaTime,0));//�G���ړ�������

    }

    //�����𔽑΂ɂ���
    private void ReverseWay()
    {
        way++;
        matizikan = 0;
    }
}
