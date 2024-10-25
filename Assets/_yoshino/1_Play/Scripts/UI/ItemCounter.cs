using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCounter : MonoBehaviour
{
    private static ItemCounter instance;

    [SerializeField, Header("ボムチャージの最大数")]
    private int countBombChargeMax;
    private int counterBombCharge;

    [SerializeField, Header("カウンター横")]
    private Image imgBomb;
    [SerializeField, Header("通常時画像")]
    private Sprite spNormal;
    [SerializeField, Header("最大値画像")]
    private Sprite spMax;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            // インスタンスの生成
            instance = this;
        }

        // ボムチャージの初期化
        counterBombCharge = 0;
        GetComponent<Text>().text = $"{counterBombCharge}/{countBombChargeMax}";

        //// 画像の初期化
        //imgBomb.sprite = spNormal;
    }

    /// <summary>
    /// インスタンスを取得する
    /// </summary>
    public static ItemCounter GetInstance() { return instance; }

    /// <summary>
    /// ボムチャージ数を取得する
    /// </summary>
    public int GetBombChargeCounter() { return counterBombCharge; }

    /// <summary>
    /// ボムチャージ数を増やす
    /// </summary>
    public void IncreaseBombChargeCounter()
    {
        if (counterBombCharge == countBombChargeMax)
        {
            //// 画像変更
            //imgBomb.sprite = spMax;
        }
        else if (counterBombCharge < countBombChargeMax)
        {
            // ボムチャージ数を増やす
            counterBombCharge++;
            GetComponent<Text>().text = $"{counterBombCharge}/{countBombChargeMax}";
        }
    }

    /// <summary>
    /// ボムチャージ数・画像のリセット
    /// </summary>
    public void ResetBombChargeCounter()
    { 
        counterBombCharge = 0;
        //imgBomb.sprite= spNormal;
    }
}
