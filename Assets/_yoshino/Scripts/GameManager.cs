using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public enum STATE_SCENE
    {
        TITLE, // タイトル画面
        PLAY,  // プレイ画面
        CLEAR, // クリア画面
        OVER,  // ゲームオーバー画面
        NONE,  // 未設定
    }
    private STATE_SCENE state_scene;

    [SerializeField, Header("クリアタイム")]
    private int timeClear;

    [SerializeField, Header("フェードイン/アウト用画像")]
    private Image imgFade;
    [SerializeField, Header("フェードイン/アウト用倍率")]
    private float fadeTime;
    private bool isFadeOut; // true = フェードアウト, false = フェードイン

    private bool isPausing; // true = ポーズ中, false = ポーズ解除

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            // インスタンスの生成
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        // シーンの初期化
        state_scene = STATE_SCENE.TITLE;

        imgFade.color = Color.black; // フェードアウト状態
        isFadeOut = false;           // フェードインに
    }

    // Update is called once per frame
    void Update()
    {
        switch (state_scene)
        {
            case STATE_SCENE.TITLE:
                break;
            case STATE_SCENE.PLAY:
                SetPause();
                GameSet();
                break;
            case STATE_SCENE.CLEAR:
                break;
            case STATE_SCENE.OVER:
                break;
        }
    }

    private void FixedUpdate()
    {
        FadeInOrOut(Time.fixedDeltaTime);
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
        if(SceneManager.GetActiveScene().buildIndex != (int)state_scene) return;

        if (Timer.GetInstance().GetSurvivalTimer() >= timeClear)
        {
            // ゲームクリア画面へ
            SetNextScene(STATE_SCENE.CLEAR);
        }
        if (PlayerComponent.GetInstance().GetHp() <= 0)
        {
            // ゲームオーバー画面へ
            SetNextScene(STATE_SCENE.OVER);
        }
    }

    /// <summary>
    /// 次のシーンに設定する
    /// </summary>
    /// <param name="_state_scene">設定するシーン</param>
    public void SetNextScene(STATE_SCENE _state_scene = STATE_SCENE.NONE)
    {
        state_scene = _state_scene;
        imgFade.enabled = true;
        isFadeOut = true;
        Time.timeScale = 0;
    }

    /// <summary>
    /// クリアタイムを取得する
    /// </summary>
    public float GetClearTime() {  return timeClear; }


    /// <summary>
    /// フェードイン/アウト
    /// </summary>
    /// <param name="_fixedDeltaTime">更新時間</param>
    private void FadeInOrOut(float _fixedDeltaTime)
    {
        if (isFadeOut)
        {
            if (imgFade.color == Color.black)
            {
                // 次のシーンへ
                isFadeOut = false;
                SceneManager.LoadSceneAsync((int)state_scene);
            }
            // フェードアウト
            imgFade.color = Color.Lerp(imgFade.color, Color.black, fadeTime * _fixedDeltaTime);
        }
        else if(imgFade.color != Color.clear)
        {
            if (imgFade.color.a < 0.05f)
            {
                // 判定の削除
                imgFade.enabled = false;
                Time.timeScale = 1;
                return;
            }
            // フェードイン
            imgFade.color = Color.Lerp(imgFade.color, Color.clear, fadeTime * _fixedDeltaTime);
        }
    }

    /// <summary>
    /// ポーズの状態を取得する
    /// </summary>
    public bool GetIsPausing() {  return isPausing; }

    /// <summary>
    /// ポーズ処理
    /// </summary>
    private void SetPause()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // ポーズ画面の切り替え
            isPausing ^= true;
        }
        if (isPausing)
        {
            // deltaTimeをOFF
            Time.timeScale = 0;
            return;
        }
        else if (FindFirstObjectByType<BombAction>() == null)
        {
            // deltaTimeをON
            Time.timeScale = 1;
        }
    }
}
