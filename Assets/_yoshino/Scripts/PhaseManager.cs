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
        }
    }
}
