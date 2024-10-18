using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed; //�ړ����鑬�x
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    //�e���ړ�����
    public void Move()
    {
        transform.Translate(new Vector2(-Speed * Time.deltaTime, 0));
    }

    //�v���C���[�ɓ��������������
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" )
        {
            Destroy(gameObject);
        }
    }
}
