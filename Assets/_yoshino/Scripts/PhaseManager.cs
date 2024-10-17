using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseManager : MonoBehaviour
{
    private static PhaseManager instance; // クラスのインスタンス

    [SerializeField] int[] intervalPhase; // フェーズ間隔
    private int indexPhase;             // フェーズ番号

    // Start is called before the first frame update
    void Start()
    {
        indexPhase = 0; // フェーズ番号の初期化
    }

    // Update is called once per frame
    void Update()
    {
        // フェーズ進行
        float timer = GetComponent<Timer>().GetTimer();
        if (timer > 120)
        {
            UpdatePhase(timer, 1);
        }
        else
        {
            UpdatePhase(timer, 0);
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
    private void UpdatePhase(float _timer, int index)
    {
        if (_timer % intervalPhase[index] < 0.01f)
        {
            // フェーズの更新
            indexPhase++;
            //EnemyDelete();
            //SpawnerChange();
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
            
        }
    }

    /// <summary>
    /// フェーズ進行時に使っていたスポナーをOFF、
    /// 次に使うスポナーをON
    /// </summary>
    private void SpawnerChange()
    {
        // ゲームオブジェクトの配列を取得
        GameObject[] allObjects = FindObjectsByType<GameObject>(FindObjectsSortMode.None);

        // 配列内の各ゲームオブジェクトをループで処理
        foreach (GameObject obj in allObjects)
        {
            // オブジェクトの名前が "Spawner" + indexPhase を含んでいるかチェック
            if (obj.name.Contains("Spawner" + indexPhase))
            {
                obj.SetActive(true);
            }
            else if (obj.name.Contains("Spawner"))
            {
                obj.SetActive(false);
            }
        }
    }
}
