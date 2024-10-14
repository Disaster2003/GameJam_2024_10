using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseManager : MonoBehaviour
{
    private static PhaseManager instance; // クラスのインスタンス

    [SerializeField] int intervalPhase; // フェーズ間隔
    private int indexPhase;             // フェーズ番号

    // Start is called before the first frame update
    void Start()
    {
        indexPhase = 0; // フェーズ番号
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Timer>().GetTimer() % intervalPhase < 0.01f)
        {
            // フェーズの更新
            indexPhase++;
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
}
