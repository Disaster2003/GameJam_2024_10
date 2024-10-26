using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BombManager : MonoBehaviour
{
    [SerializeField, Header("�A�C�e���J�E���^�[")]
    private ItemCounter itemCounter;

   

    [SerializeField, Header("�{���X�|�i�[")]
    private Spawner[] spawner = new Spawner[20];

   

    [SerializeField, Header("�{�����o�̎���")]
    private float bombTime = 2f;

    private EnemyBase enemyBase;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            if (itemCounter.GetisBombChargeMax())
            {
                itemCounter.ResetBombChargeCounter();
                for(int i = 0; i < spawner.Length; i++)
                {
                    spawner[i].SpawnBomb();
                }
                EnemyDelete();
            }


        }
    }

    private IEnumerator ActionBomb(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);  // 2�b�ҋ@
        EnemyDelete();
       
    }

    private void EnemyDelete()
    {
        // "Enemy"�^�O�����S�Ă�GameObject���擾
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // �擾����GameObject������j��
        foreach (GameObject enemy in enemies)
        {
            if (enemy.name.Contains("EnemyBullet"))
            {
                // �e�̔j��
                Destroy(enemy);
                continue;
            }

            enemyBase = enemy.GetComponent<EnemyBase>();
            // �G�̎��S���o��
            enemyBase.Dead();
        }
    }

   
}
