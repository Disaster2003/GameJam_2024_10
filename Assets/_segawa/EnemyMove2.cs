using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymove2 : MonoBehaviour
{
    public Vector2 titen;   //�~�܂�ꏊ
    public float MoveSpeed;//�ړ����x

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        LeftRight(1);   //�E���̎w�肳�ꂽ�����ֈړ�
        LeftRight(-1);  //�����̎w�肳�ꂽ�����ֈړ�
    }
    //���E�ړ�
    private void LeftRight(int left)
    {
        if (left*transform.position.x < left*titen.x)    
        {
            transform.Translate(new Vector2(left * MoveSpeed * Time.deltaTime, 0));
            if (left * transform.position.x >= left * titen.x) Destroy(this);
        }

    }
}
