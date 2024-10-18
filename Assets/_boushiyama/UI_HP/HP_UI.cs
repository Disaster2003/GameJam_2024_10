using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_UI : MonoBehaviour
{
    public int maxHealth = 10; // 最大ライフ
    public int currentHealth; // 現在のライフ
    public Image[] heartImages; // ハートのImageコンポーネント

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();               //体力ゲージの表示関数
    }

    // Update is called once per frame
    void Update()
    {
        //キー入力でUIの増減関数を呼び出す

        if (Input.GetKeyDown(KeyCode.Space)) // スペースキーでダメージ
        {
            TakeDamage(1);
        }

        if (Input.GetKeyDown(KeyCode.H)) // Hキーで回復
        {
            Heal(1);
        }
    }
    //ダメージ
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
            

        UpdateHealthUI();   //体力ゲージの表示
    }
    //回復
    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
            

        UpdateHealthUI();   //体力ゲージの表示
    }


    //体力ゲージの表示関数
    void UpdateHealthUI()
    {
        for (int i = 0; i < heartImages.Length; i++)
        {
            if (i < currentHealth)
            {
                heartImages[i].enabled = true; // ハートを表示
            } 
            else
            {
                heartImages[i].enabled = false; // ハートを非表示
            }
                
        }
    }
}
