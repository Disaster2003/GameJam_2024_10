using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject enemyprefab;
    private Life life;
    int EnemyHP = 5;                   //�G��HP
    Rigidbody2D rb;
    public float at = 1f;              //�G�l�~�[�̍U����
    public float Espeed;               //�G�l�~�[�̃X�s�[�h
    public float PHP = 1f;             //�v���C���[��HP(��)
    public float EAI = 1f;             //Enemies Appear Interval�̗��C�G���o������Ԋu
    public float EAPY = 0f;            //�|�|position�̗�,�G�l�~�[�����o�����邙���W
    public float EMS = 3f;             //Enemy Move Speed�̗��A�G�l�~�[�̈ړ����x
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        life = GetComponent<Life>();
        InvokeRepeating(nameof(Appear), 0f, EAI);
    }
   
   �@public void Appear()           //�G�l�~�[���E����o�������鏈��
    {
        Vector3 EAP = new Vector3(Screen.width, EAPY, 0);
        EAP = Camera.main.ScreenToWorldPoint(EAP);
        EAP.z = 0;

        GameObject enemy = Instantiate(enemyprefab, EAP, Quaternion.identity);
        StartCoroutine(MoveEnemy(enemy));
    }

    private System.Collections.IEnumerator MoveEnemy(GameObject enemy)
    {
        while (enemy != null)
        {
            enemy.transform.position += Vector3.left * Espeed * Time.deltaTime;
            if (enemy.transform.position.x < Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x)        //��ʊO�ɏo����j��
            {
                Destroy(enemy);
            }
            yield return null;          //���̃t���[���܂ő҂�
        }
    }
    public void Eattack(Collision collision)                  //�G�̍U��
    {
        if(collision.gameObject.CompareTag("Player"))
        {
           // PHP php = collision.gameObject.GetComponent<PHP>      //�v���C���[�̃X�N���v�g�����킩��Ȃ��̂�
       Debug.Log("�v���C���[���_���[�W���󂯂�");                   //�R�����g�ɂ��Ă��܂��i�G�l�~�[���v���C���[��
        }                                                           //�ɓ����������̏���)    
        
        
    }

    public void Damege(int damege)     //�G���_���[�W���󂯂�Ƃ��̏���
    {
        EnemyHP -= 1;          //damege���󂯂���HP����
        if (EnemyHP < 0)            //EnemyHP��0�ȉ��ɂȂ�����Die�𑗂�
        {
            EnemyHP = 0;
            life.Die();
        }
    }
    
    public void UnNormalDestory()   //�{���Ȃǂ̃A�C�e���h���b�v���Ȃ�
    {

    }
   
    // Update is called once per frame
    void Update()
    {
        if (EnemyHP < 0)
        {
            life.NormalDestory();
        }
    }
}
