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

    private int number;             //ランダムに選ばれた敵のインデックス
    private float spawnwait;          //待機時間の処理   
    private int spawncount;         //敵のスポーン数を数える

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
        if (spawnwait >= wait)
        {
            EnemySpawn();
        }
        if (spawncount == Hakai)
        {
            SpawnerDestroy();
        }
    }
    
    //敵をスポーンさせる関数
    private void EnemySpawn()
    {
        number = Random.Range(0, _enemy.Length);
        Instantiate(_enemy[number],transform.position,transform.rotation);
        spawnwait = 0;
        spawncount++;
    }

    //スポナーを破壊する関数
    private void SpawnerDestroy()
    {
        Destroy(this);
    }

}
