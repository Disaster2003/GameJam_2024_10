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

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().freezeRotation = true; // ��]�s��
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

        // ���g�̔j��
        Destroy(gameObject);
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
}
