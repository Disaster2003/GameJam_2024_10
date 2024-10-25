using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAction : MonoBehaviour
{
    private void FixedUpdate()
    {
        // ƒ|[ƒY’†
        if(GameManager.GetInstance().GetIsPausing()) return;

        EnemyDelete();
    }

    /// <summary>
    /// “G‚ğÁ‹‚·‚é
    /// </summary>
    private void EnemyDelete()
    {
        // "Enemy"ƒ^ƒO‚ğ‚Â‘S‚Ä‚ÌGameObject‚ğæ“¾
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // æ“¾‚µ‚½GameObject‚ğˆê‚Â‚¸‚Â”j‰ó
        foreach (GameObject enemy in enemies)
        {
            if (enemy.name.Contains("EnemyBullet"))
            {
                // ’e‚Ì”j‰ó
                Destroy(enemy);
                continue;
            }

            // “G‚Ì€–S‰‰o‚Ö
            GetComponent<EnemyBase>().Dead();
        }
    }
}
