using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TimerControlManeger : MonoBehaviour
{
    public RectTransform[] uiElements; // 拡大するUIの配列
    public float scaleDuration = 10f; // 拡大にかかる時間（10秒）
    public float maxScale = 10f;      //拡大サイズ
    public float waitBeforeHide = 2f; // 消えるまでの時間

    // Start is called before the first frame update
    void Start()
    {
        // 全てのUIを非表示に
        HideAllUI();
    }

    // Update is called once per frame
    void Update()
    {
        ShowAndScaleUI(PhaseManager.GetInstance().GetIndexPhase());
    }
    // 指定したインデックスのUI要素を表示する関数

    public void ShowAndScaleUI(int index)
    {
        if (index < 0 || index >= uiElements.Length)
        {
            Debug.LogWarning("インデックスが無効です: " + index);      //指定したインデックス以外の入力でエラー

            return;
        }

        StartCoroutine(ScaleAndHideUI(uiElements[index]));      //インデックスが有効な場合に拡大、削除の関数を呼び出す
    }

    
    private IEnumerator ScaleAndHideUI(RectTransform uiElement) //拡大表示と非表示にしたいUIの指定
    {
        // UIを表示
        uiElement.gameObject.SetActive(true);

        // 拡大のための時間経過
        float elapsedTime = 0f;
        Vector3 initialScale = uiElement.localScale;    //元の画像サイズの取得
        Vector3 targetScale = initialScale * maxScale;  //指定サイズ

        while (elapsedTime < scaleDuration)
        {
            //拡大処理を滑らかにするための処理
            uiElement.localScale = Vector3.Lerp(initialScale, targetScale, elapsedTime / scaleDuration);

            //初期の大きさから指定した大きさまで拡大するまで加算
            elapsedTime += Time.deltaTime;

            //次のフレームまで待機
            yield return null;      
        }
        uiElement.localScale = targetScale; // 最終的なスケールに設定

        // 指定された時間待つ
        yield return new WaitForSeconds(waitBeforeHide);

        // UIを非表示
        uiElement.gameObject.SetActive(false);
    }

    // すべてのUIを非表示にする関数
    private void HideAllUI()
    {
        foreach (RectTransform uiElement in uiElements)
        {
            uiElement.gameObject.SetActive(false);      //UIを非表示にする
        }
    }
}
