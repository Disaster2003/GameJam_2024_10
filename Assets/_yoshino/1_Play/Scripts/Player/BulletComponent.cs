using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletComponent : MonoBehaviour
{
    private enum STATE_BULLET
    {
        PLAYER = 1, // ƒvƒŒƒCƒ„[w‰c
        ENEMY = -1, // “Gw‰c
    }
    [SerializeField, Header("’e‚Ìw‰c")]
    private STATE_BULLET state_bullet;

    [SerializeField, Header("ˆÚ“®‘¬“x")]
    private float speedMove;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    /// <summary>
    /// ˆÚ“®ˆ—
    /// </summary>
    private void Move()
    {
        transform.Translate((int)state_bullet * speedMove * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // nullƒ`ƒFƒbƒN
        if (collision != null) return;

        switch (state_bullet)
        {
            case STATE_BULLET.PLAYER:
                if (collision.CompareTag("Enemy"))
                {
                    // ©g‚Ì”j‰ó
                    Destroy(gameObject);
                }
                break;
            case STATE_BULLET.ENEMY:
                if (collision.name == "Player")
                {
                    // ©g‚Ì”j‰ó
                    Destroy(gameObject);
                }
                break;
        }
    }

    public bool Getsb()
    {
        return state_bullet == STATE_BULLET.PLAYER;
    }
}
