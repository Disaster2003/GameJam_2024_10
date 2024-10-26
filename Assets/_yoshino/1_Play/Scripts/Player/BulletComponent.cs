using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletComponent : MonoBehaviour
{
    private enum STATE_BULLET
    {
        PLAYER = 1, // プレイヤー陣営
        ENEMY = -1, // 敵陣営
    }
    [SerializeField, Header("弾の陣営")]
    private STATE_BULLET state_bullet;

    [SerializeField, Header("移動速度")]
    private float speedMove;

    [SerializeField, Header("破壊された後に出てくるエフェクト")]
    private GameObject breakSprite;

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
        if (collision == null) return;

       
        switch (state_bullet)
        {
            case STATE_BULLET.PLAYER:
                if (collision.CompareTag("Enemy"))
                {  
                    //プレハブの生成
                    Instantiate(breakSprite, transform.localPosition , Quaternion.identity);
                    // 自身の破壊
                    Destroy(gameObject);
                }
                break;
            case STATE_BULLET.ENEMY:
                if (collision.name == "Player")
                {
                    //プレハブの生成
                    Instantiate(breakSprite, transform.localPosition, Quaternion.identity);
                    // 自身の破壊
                    Destroy(gameObject);
                }
                break;
        }
    }

    public bool GetisPlayerBullet()
    {
        return state_bullet == STATE_BULLET.PLAYER;
    }

    public void DestoryBullet()
    {
        Destroy(gameObject);
    }


}
