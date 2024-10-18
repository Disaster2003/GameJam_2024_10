using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField,Header("敵オブジェクト")]
    public GameObject[] _enemy;
    [SerializeField, Header("待機時間")]
    public float wait;
    [SerializeField, Header("動く回数")]
    public int Hakai;

    private int number;             //randamu ni erabareta tekino indekkusu
    private float spawnwait;          //taikizikan no shori
    private int spawncount;         //teki no supo-nnsuu wo kazoeru

    // Start is called before the first frame update
    void Start()
    {
        spawncount = 0;
        spawnwait = 0;
    }

    // Update is called once per frame
    void Update()
    {
        spawnwait += Time.deltaTime;
        if (spawnwait >= wait)  //taikizikan wo koetara
        {
            EnemySpawn();
        }
        if (spawncount == Hakai)    //Hakai de setteisita atai bunn supo-nn sasetara
        {
            SpawnerDestroy();
        }
    }
    
    //teki wo sipo-nn saseru kansuu
    private void EnemySpawn()
    {
        number = Random.Range(0, _enemy.Length);
        Instantiate(_enemy[number],transform.position,transform.rotation);
        spawnwait = 0;
        spawncount++;
    }

    //supona- wo hakai suru kansuu
    private void SpawnerDestroy()
    {
        Destroy(this);
    }

}
