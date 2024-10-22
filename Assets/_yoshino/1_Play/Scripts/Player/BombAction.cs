using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAction : MonoBehaviour
{
    private void FixedUpdate()
    {
        // �|�[�Y��
        if(GameManager.GetInstance().GetIsPausing()) return;

        EnemyDelete();
    }

    /// <summary>
    /// �G����������
    /// </summary>
    private void EnemyDelete()
    {
        // "Enemy"�^�O�����S�Ă�GameObject���擾
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // �擾����GameObject������j��
        foreach (GameObject enemy in enemies)
        {
            GetComponent<EnemyBase>().Dead();
        }
    }
}
