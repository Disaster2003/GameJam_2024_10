using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Life life;
    int EnemyHP = 5;            //�G��HP
    Rigidbody2D rb;
    float at = 1f;              //�G�l�~�[�̍U����
    public float PHP = 1f;      //�v���C���[��HP(��)
    public float EAI = 1f;             //Enemies Appear Interval�̗��C�G���o������Ԋu
    public float EAPY = 0f;             //�|�|position�̗�,�G�l�~�[�����o�����邙���W
    public float EMS = 3f;             //Enemy Move Speed�̗��A�G�l�~�[�̈ړ����x
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        life = GetComponent<Life>();
        InvokeRepeating(nameof(Appear), 0f, EAI);
    }
   
    void Appear()           //�G�l�~�[���E����o�������鏈��
    {
        Vector3 EAP = new Vector3(Screen.width, EAP, 0);
        EAP = Camera.main.ScreenToWorldPoint(EAP);
        EAP.z = 0;
    }
    void Eattack(Collision collision)                  //�G�̍U��
    {
        if(collision.gameObject.CompareTag("Player"))
        {
           // PHP php = collision.gameObject.GetComponent<PHP>      //�v���C���[�̃X�N���v�g�����킩��Ȃ��̂�
       Debug.Log("�v���C���[���_���[�W���󂯂�");                   //�R�����g�ɂ��Ă��܂��i�G�l�~�[���v���C���[��
        }                                                           //�ɓ����������̏���)    
        
        
    }

    void TakeDamege(int damege)     //�G���_���[�W���󂯂�Ƃ��̏���
    {
        EnemyHP -= 1;          //damege���󂯂���HP����
        if (EnemyHP < 0)            //EnemyHP��0�ȉ��ɂȂ�����Die�𑗂�
        {
            EnemyHP = 0;
            life.Die();
        }
    }
   
    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(-1f, rb.velocity.y);  //���ɐi��
    }
}
