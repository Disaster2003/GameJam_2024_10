using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSpawn : MonoBehaviour
{
    [SerializeField, Header("�e")]
    private GameObject bullet;
    [SerializeField, Header("���ˊԊu")]
    private float intervalSpawnBullet;
    private float timerSpawn;

    // Start is called before the first frame update
    void Start()
    {
        // �^�C�}�[�̏�����
        timerSpawn = intervalSpawnBullet;
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
            timerSpawn = intervalSpawnBullet;
            Instantiate(bullet, transform.position + Vector3.left, Quaternion.identity);
        }
        timerSpawn += -Time.deltaTime;
    }
}
