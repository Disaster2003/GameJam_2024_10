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
    [SerializeField, Header("弾の陣営")]
    private STATE_BULLET state_bullet;

    [SerializeField, Header("移動速度")]
    private float speedMove;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    /// <summary>
    /// 移動処理
    /// </summary>
    private void Move()
    {
        transform.Translate((int)state_bullet * speedMove * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // nullチェック
        if (collision != null) return;

        if(collision.tag == "Enemy")
        {
            // 自身を破壊する
            Destroy(gameObject);
        }
    }
}
