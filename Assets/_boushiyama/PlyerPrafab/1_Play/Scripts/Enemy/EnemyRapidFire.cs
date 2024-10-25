using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRapidFire : MonoBehaviour
{
    [SerializeField, Header("�e")]
    private GameObject bullet;
    [SerializeField, Header("���ˊԊu")]
    private float intervalSpawnBullet;
    private float timerSpawn;

    [SerializeField, Header("�e��")]
    private int ammo;
    private int ammoRemain;
    [SerializeField, Header("�A�ˊԊu")]
    private float intervalSpawnRapid;
    private float timerRapid;

    // Start is called before the first frame update
    void Start()
    {
        // �^�C�}�[�̏�����
        timerSpawn = intervalSpawnBullet;
        timerRapid = intervalSpawnRapid;

        // �e���̏�����
        ammoRemain = ammo;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnBullet();
    }

    /// <summary>
    /// �e�𐶐�����
    /// </summary>
    private void SpawnBullet()
    {
        if (timerSpawn <= 0)
        {
            // �e�̐���
            if(timerRapid <= 0)
            {
                timerRapid = intervalSpawnRapid;
                ammoRemain--;
                Instantiate(bullet, transform.position + Vector3.left, Quaternion.identity);

                if(ammoRemain <= 0)
                {
                    timerSpawn = intervalSpawnBullet;
                }
            }
            else
            {
                timerRapid -= intervalSpawnBullet;
            }
        }
        else
        {
            timerSpawn += -Time.deltaTime;
        }
    }
}
