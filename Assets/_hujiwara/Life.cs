using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    float DropChance = 0.5f;        //�A�C�e���h���b�v�̊m�� 
    GameObject Item;                                //�h���b�v�A�C�e��
    // Start is called before the first frame update
    void Start()
    {
        
    }


   


    public void Die()                      //�G�����S�������̏���
    {

        DropItem();                 //Die�������Ă�����A�C�e���h���b�v��Enemy�̍폜
        Destroy(gameObject);
    }

    void DropItem()
    {
        if (Random.value  < DropChance)
        {
            Vector3 dropposition = transform.position;               //�A�C�e���̈ʒu������Enemy�̈ʒu
            Instantiate(Item, dropposition, Quaternion.identity);
            Debug.Log("drop");
        }
        else
        {
            Debug.Log("not drop");
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
