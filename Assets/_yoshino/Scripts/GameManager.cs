using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance; // クラスのインスタンス

    private enum STATE_SCENE
    {
        TITLE, // タイトル画面
        PLAY,  // プレイ画面
        CLEAR, // クリア画面
        OVER,  // ゲームオーバー画面
        NONE,  // 未設定
    }
    private STATE_SCENE state_scene;

    [SerializeField] int timeClear; // クリアタイム

    [SerializeField] Image imgFade; // フェードイン/アウト用画像
    private bool isFadeOut; // フェードアウトするかどうか

    // Start is called before the first frame update
    void Start()
    {
        // Singleton
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        state_scene = STATE_SCENE.TITLE; // シーンの初期化

        imgFade.fillAmount = 1; // フェードアウト状態
        isFadeOut = false;      // フェードインに
    }

    // Update is called once per frame
    void Update()
    {
        switch (state_scene)
        {
            case STATE_SCENE.TITLE:
                break;
            case STATE_SCENE.PLAY:
                GameSet();
                break;
            case STATE_SCENE.CLEAR:
                break;
            case STATE_SCENE.OVER:
                break;
        }

        FadeInOrOut();
    }

    /// <summary>
    /// インスタンスを取得する
    /// </summary>
    public static GameManager GetInstance() { return instance; }

    /// <summary>
    /// ゲーム終了条件での分岐処理
    /// </summary>
    private void GameSet()
    {
        if (Timer.GetInstance().GetTimer() >= timeClear)
        {
            // ゲームクリア画面へ
            SetNextScene(STATE_SCENE.CLEAR);
        }
        //if()
        //{
        //    // ゲームオーバー画面へ
        //    SetNextScene(STATE_SCENE.OVER);
        //}
    }

    /// <summary>
    /// 次のシーンに設定する
    /// </summary>
    /// <param name="_state_scene"></param>
    private void SetNextScene(STATE_SCENE _state_scene = STATE_SCENE.NONE)
    {
        state_scene = _state_scene;
        isFadeOut = true;
    }

    /// <summary>
    /// フェードイン/アウト
    /// </summary>
    private void FadeInOrOut()
    {
        if (isFadeOut)
        {
            if (imgFade.fillAmount >= 1)
            {
                // 次のシーンへ
                isFadeOut = false;
                SceneManager.LoadSceneAsync((int)state_scene);
            }
            // フェードアウト
            imgFade.fillAmount += Time.deltaTime;
        }
        else if(imgFade.fillAmount > 0)
        {
            // フェードイン
            imgFade.fillAmount += -Time.deltaTime;
        }
    }
}
