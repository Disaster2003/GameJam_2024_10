using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance; // クラスのインスタンス

    private enum STATE_SCENE
    {
        TITLE, // タイトル画面
        PLAY,  // プレイ画面
        CLEAR, // クリア画面
        OVER,  // ゲームオーバー画面
        NONE,  // 未選択
    }
    private STATE_SCENE state_scene;

    [SerializeField] int timeClear; // クリアタイム

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
    }

    // Update is called once per frame
    void Update()
    {
        switch (state_scene)
        {
            case STATE_SCENE.TITLE:
                break;
            case STATE_SCENE.PLAY:
                if(Timer.GetInstance().GetTimer() >= timeClear)
                {
                    // ゲームクリア画面へ
                    SetNextScene(STATE_SCENE.CLEAR);
                }
                //if()
                //{
                //    // ゲームオーバー画面へ
                //    SetNextScene(STATE_SCENE.OVER);
                //}
                break;
            case STATE_SCENE.CLEAR:
                break;
            case STATE_SCENE.OVER:
                break;
        }
    }

    /// <summary>
    /// インスタンスを取得する
    /// </summary>
    public static GameManager GetInstance() { return instance; }

    /// <summary>
    /// 次のシーンに設定する
    /// </summary>
    /// <param name="_state_scene"></param>
    private void SetNextScene(STATE_SCENE _state_scene = STATE_SCENE.NONE)
    {
        // nullチェック
        if(_state_scene == STATE_SCENE.NONE)
        {
            Debug.LogError("次のシーンが未設定です");
            return;
        }

        state_scene = _state_scene;
        SceneManager.LoadSceneAsync((int)state_scene);
    }
}
