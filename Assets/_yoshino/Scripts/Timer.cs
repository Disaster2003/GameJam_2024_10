using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private static Timer instance; // クラスのインスタンス

    private float timer; // タイマー

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            // Singleton
            instance = this;
        }

        timer = 1; // タイマーの初期化
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("imgFade").GetComponent<Image>().fillAmount > 0) return;

        // タイマーの更新
        timer += Time.deltaTime;
        GetComponent<Text>().text = timer.ToString("F1") + "s";
    }

    /// <summary>
    /// インスタンスを取得する
    /// </summary>
    public static Timer GetInstance() { return instance; }

    /// <summary>
    /// タイマーを取得する
    /// </summary>
    public float GetTimer() { return timer; }
}
