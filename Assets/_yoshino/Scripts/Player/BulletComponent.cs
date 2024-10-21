using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.StandaloneInputModule;

public class BulletComponent : MonoBehaviour
{
    private enum STATE_BULLET
    {
        PLAYER = 1,
        ENEMY = -1,
    }
    [SerializeField, Header("�e�̐w�c")]
    private STATE_BULLET state_bullet;

    [SerializeField, Header("�ړ����x")]
    private float speedMove;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    /// <summary>
    /// �ړ�����
    /// </summary>
    private void Move()
    {
        transform.Translate((int)state_bullet * speedMove * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // null�`�F�b�N
        if (collision != null) return;

        if(collision.tag == "Enemy")
        {
            // ���g��j�󂷂�
            Destroy(gameObject);
        }
    }
}
