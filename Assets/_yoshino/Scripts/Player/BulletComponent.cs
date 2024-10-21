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

        if(collision.tag == "Enemy")
        {
            // ©g‚ğ”j‰ó‚·‚é
            Destroy(gameObject);
        }
    }
}
