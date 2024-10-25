using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField, Header("�̗�")]
    private int hp;

    [SerializeField, Header("�A�C�e��")]
    private GameObject item;
    [SerializeField, Header("1/?�ŃA�C�e���h���b�v")]
    private int probability;

    [SerializeField, Header("���������̎���")]
    private float timeDeath;
    private float timerUntilDeath;

    [SerializeField, Header("���������̌�����")]
    private Sprite DeathSprite;

    

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().freezeRotation = true; // ��]�s��

        // �^�C�}�[�̏�����
        timerUntilDeath = 0;
    }

    private void FixedUpdate()
    {
        if (GetDeathFlag())
        {
            if (timerUntilDeath >= timeDeath)
            {
                // ���g�̔j��
                Destroy(gameObject);
            }
            // ��������
            timerUntilDeath += Time.fixedDeltaTime;
        }         
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // null�`�F�b�N
        if (collision == null) return;

        if (collision.CompareTag("Bullet"))
        {
            // �_���[�W
            hp--;

            if (hp <= 0)
            {
                // ���S�J�n
                Dead();
            }
        }
    }

    /// <summary>
    /// ���S����
    /// </summary>
    public void Dead()
    {
        if (hp <= 0)
        {
            ItemDrop();
        }

        // ��������
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);

        // �摜�̐؂�ւ�
        GetComponent<SpriteRenderer>().sprite = DeathSprite;
    }

    /// <summary>
    /// �A�C�e���𐶐�����
    /// </summary>
    private void ItemDrop()
    {
        // �m���̒T��
        probability = Random.Range(0, probability);
        if (probability == 0)
        {
            // �A�C�e���̐���
            Instantiate(item, transform.position, Quaternion.identity);
        }
    }

    public bool GetDeathFlag()
    {
        //�������̏�Ԃ���true��Ԃ�
        return GetComponent<SpriteRenderer>().color.a != 1;
    }
}
