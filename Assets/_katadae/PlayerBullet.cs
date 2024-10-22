using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float MoveSpeed;         // �ړ��l
    GameObject playerObj = null;     // �v���C���[�I�u�W�F�N�g
    int frameCount = 0;             // �t���[���J�E���g
    public  int deleteFrame;    // �폜�t���[��(650�����j

 
  

    // Start is called before the first frame update
    void Start()
    {
        // �q�G�����L�[�r���[�ɂ��� player ���擾
        playerObj = GameObject.Find("Player");
    }


 

    // Update is called once per frame
    void Update()
    {
        // �ʒu�̍X�V
        transform.Translate(MoveSpeed * Time.deltaTime, 0, 0);
        float distance = (playerObj.transform.position - transform.position).sqrMagnitude;

        // ���t���[���ŏ���
        if (++frameCount > deleteFrame)
        {
            Destroy(gameObject);
        }

       
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {


        //�G�l�~�[�q�b�g�Ń_���[�W
        if (collision.gameObject.tag == "Enemy")
        {

            Destroy(gameObject);

        }
    }

  }
