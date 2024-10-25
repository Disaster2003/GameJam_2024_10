using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSpawn : MonoBehaviour
{
    [SerializeField, Header("íe")]
    private GameObject bullet;
    [SerializeField, Header("î≠éÀä‘äu")]
    private float intervalSpawnBullet;
    private float timerSpawn;

    // Start is called before the first frame update
    void Start()
    {
        // É^ÉCÉ}Å[ÇÃèâä˙âª
        timerSpawn = intervalSpawnBullet;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnBullet();
    }

    /// <summary>
    /// íeÇê∂ê¨Ç∑ÇÈ
    /// </summary>
    private void SpawnBullet()
    {
        if (timerSpawn <= 0)
        {
            // íeÇÃê∂ê¨
            timerSpawn = intervalSpawnBullet;
            Instantiate(bullet, transform.position + Vector3.left, Quaternion.identity);
        }
        timerSpawn += -Time.deltaTime;
    }
}
