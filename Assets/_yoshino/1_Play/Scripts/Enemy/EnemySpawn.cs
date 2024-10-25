using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwan : MonoBehaviour
{
    [SerializeField, Header("�G")]
    private GameObject[] enemyArray;
    [SerializeField, Header("���ˊԊu")]
    private float intervalSpawnEnemy;
    private float timerSpawn;
    [SerializeField, Header("�������̍ő�l")]
    private int countSpawnMax;
    private int countSpawn;

    // Start is called before the first frame update
    void Start()
    {
        // �^�C�}�[�̏�����
        timerSpawn = intervalSpawnEnemy;

        // �������̏�����
        countSpawn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemy();
    }

    /// <summary>
    /// �G�𐶐�����
    /// </summary>
    private void SpawnEnemy()
    {
        if(countSpawn >= countSpawnMax)
        {
            // ���g�̔j��
            Destroy(gameObject);
        }

        if (timerSpawn <= 0)
        {
            timerSpawn = intervalSpawnEnemy;
            countSpawn++;
            int index = Random.Range(0, enemyArray.Length);
            Instantiate(enemyArray[index], transform.position + Vector3.left, Quaternion.identity);
        }
        timerSpawn += -Time.deltaTime;
    }
}
