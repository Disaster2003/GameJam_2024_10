using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UI_Getitem : MonoBehaviour
{
    public int score = 0;
    public int targetScore = 20; // UIを切り替えるスコア
    public GameObject newUI; // 切り替えるUI RED
    public GameObject oldUI; // 現在のUI BLUE
    public TMP_Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        oldUI.SetActive(true);
        newUI.SetActive(false);
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        // スペースキーを押したらスコア加算
        if (Input.GetKeyDown(KeyCode.I))
        {
            AddScore(1);
        }
    }
    void AddScore(int item)
    {
        score += item;
        Debug.Log("Score: " + score);
        UpdateScoreText();
        // スコアがターゲットに達したらUIを切り替え
        if (score >= targetScore)
        {
            SwitchUI();
        }
    }
    void UpdateScoreText()
    {
        scoreText.text = "×" + score;       //スコア表示
    }
    //古いUIを消して新しいUIを表示する
    void SwitchUI()
    {
        oldUI.SetActive(false);
        newUI.SetActive(true);
    }
}
