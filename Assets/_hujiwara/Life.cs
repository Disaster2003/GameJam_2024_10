using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    int EnemyHP = 5;                                //�G��HP
    GameObject Item;                                //�h���b�v�A�C�e��
    // Start is called before the first frame update
    void Start()
    {
        
    }


    void TakeDamege(int damege)     //�G���_���[�W���󂯂�Ƃ��̏���
    {
        EnemyHP -= 1;          //damege���󂯂���HP����
        if (EnemyHP < 0)            //EnemyHP��0�ȉ��ɂȂ�����Die�𑗂�
        {
            EnemyHP = 0;
            Die();
        }
    }


    void Die()                      //�G�����S�������̏���
    {
        DropItem();                 //Die�������Ă�����A�C�e���h���b�v��Enemy�̍폜
        Destroy(gameObject);
    }

    void DropItem()
    {
        Vector3 dropposition = transform.position + new Vector3(0,1);         //�A�C�e���̈ʒu������Enemy�̈ʒu�H
        Instantiate(Item, dropposition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
