using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PhaseManager : MonoBehaviour
{
    private static PhaseManager instance; // クラスのインスタンス

    [SerializeField, Header("フェーズ間隔")] int[] intervalPhase;
    private int indexPhase;

    [SerializeField, Header("Spawner")] 
    private GameObject[] spawner = new GameObject[12];

    float Updateinterval;

    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("はい");

        if (instance == null)
        {
            // インスタンスの生成
            instance = this;
        }

        // フェーズ番号の初期化
        indexPhase = 0;

        Updateinterval = 2f;

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // フェーズ進行
        int timer = (int)GetComponent<Timer>().GetSurvivalTimer();
        if(Updateinterval < 0)
        {
            if (timer > 120)
            {
                UpdatePhase(timer, 1);
            }
            else
            {
                UpdatePhase(timer, 0);
            }
        }
        else
        {
            Updateinterval -= Time.deltaTime;
        }
       
    }

    /// <summary>
    /// インスタンスを取得する
    /// </summary>
    public static PhaseManager GetInstance() { return instance; }

    /// <summary>
    /// フェーズ番号を取得する
    /// </summary>
    public int GetIndexPhase() { return indexPhase; }

    /// <summary>
    /// フェーズを更新する
    /// </summary>
    /// <param name="_timer">タイマー</param>
    /// <param name="index">指定する秒数配列のインデックス</param>
    private void UpdatePhase(int _timer, int index)
    {
        
        if (_timer % intervalPhase[index] == 0)
        {
            Debug.Log(_timer);
            // フェーズの更新
            indexPhase++;
            EnemyDelete();
            SpawnerChange();
            BulletDelete();

            Updateinterval = 2f;

            audioSource.Play();

            Debug.Log("更新したよ");
        }
    }

    /// <summary>
    /// フェーズ進行時に敵を消去する
    /// </summary>
    private void EnemyDelete()
    {
        // "Enemy"タグを持つ全てのGameObjectを取得
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // 取得したGameObjectを一つずつ破壊
        foreach (GameObject enemy in enemies)
        {
            // 敵の死亡演出へ
            EnemyBase enemybase = enemy.GetComponent<EnemyBase>();
            enemybase.Dead();
        }

    }

    /// <summary>
    /// フェーズ進行時に敵を消去する
    /// </summary>
    private void BulletDelete()
    {
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject bullet in bullets)
        {
            BulletComponent bulletComponent = bullet.GetComponent<BulletComponent>();

            if(bulletComponent != null)
            {
                if (!bulletComponent.GetisPlayerBullet())
                {
                    bulletComponent.DestoryBullet();
                    continue;
                }
            }

            
        }
    }

    /// <summary>
    /// フェーズ進行時に使っていたスポナーをOFF、
    /// 次に使うスポナーをON
    /// </summary>
    private void SpawnerChange()
    {
        for(int i = 0; i < spawner.Length; i++)
        {
            if(i == indexPhase)
            {
                spawner[i].SetActive(true);
            }
            else
            {
                spawner[i].SetActive(false);
            }
        }

        
    }
}
