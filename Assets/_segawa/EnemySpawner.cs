using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField,Header("敵オブジェクト")]
    public GameObject[] _enemy;
    [SerializeField, Header("待機時間")]
    public int wait;

    private int number;             //ランダムに選ばれた敵のインデックス
    private int spawnwait;          //待機時間の処理   
    private int spawncount;         //敵のスポーン数を数える
    private GameObject GameObj;

    // Start is called before the first frame update
    void Start()
    {
        spawncount = 0;
        spawnwait = 0;
    }

    // Update is called once per frame
    void Update()
    {
        spawnwait++;
        if (spawnwait % wait == 0)
        {
            EnemySpawn();
        }
    }
    
    //敵をスポーンさせる関数
    private void EnemySpawn()
    {
        number = Random.Range(0, _enemy.Length);
        GameObj = Instantiate(_enemy[number]);
        GameObj.transform.position = transform.position;
        spawncount++;
    }

    //スポナーを破壊する関数
    private void SpawnerDestroy()
    {
        Destroy(this);
    }
}
