using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCounter : MonoBehaviour
{
    private static ItemCounter instance; // クラスのインスタンス

    private int numberItem; // アイテム数

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            // Singleton
            instance = this;
        }

        numberItem = 0; // アイテム数の初期化
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// インスタンスを取得する
    /// </summary>
    public static ItemCounter GetInstance() { return instance; }

    /// <summary>
    /// アイテム数を取得する
    /// </summary>
    public int GetNumberItem() { return numberItem; }

    /// <summary>
    /// アイテム数を増やす
    /// </summary>
    public void IncreaseNumberItem() { if (numberItem < 20) numberItem++; }
}
