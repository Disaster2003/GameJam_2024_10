using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour
{
    // ゲームを終了させるメソッド
    public void QuitGame()
    {
        // ゲームがエディタで実行中の場合は、エディタを停止する
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // エディタを停止
#else
        Application.Quit(); // ビルド版でゲームを終了
#endif
        // 終了処理の後、必要に応じてリソースの解放などを行うことができます。
        Debug.Log("ゲームを終了しました。");
    }
}
