using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerControlManeger : MonoBehaviour
{
    public RectTransform[] uiElements; // 拡大するUIの配列
    public float scaleDuration = 10f; // 拡大にかかる時間（10秒）
    public float maxScale = 10f;      //拡大サイズ
    public float waitBeforeHide = 2f; // 消えるまでの時間

    // Start is called before the first frame update
    void Start()
    {
        // 初期状態で全てのUIを非表示に
        HideAllUI();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 10; i++) // 0から9までの数字キーをチェック
        {
            if (Input.GetKeyDown((KeyCode)(KeyCode.Alpha0 + i)))
            {
                ShowAndScaleUI(i);
                break; // 一度に一つだけ処理するためにループを抜ける
            }
        }
    }
    // 指定したインデックスのUI要素を表示する関数

    public void ShowAndScaleUI(int index)
    {
        if (index < 0 || index >= uiElements.Length)
        {
            Debug.LogWarning("インデックスが無効です: " + index);
            return;
        }

        StartCoroutine(ScaleAndHideUI(uiElements[index]));
    }

    private IEnumerator ScaleAndHideUI(RectTransform uiElement)
    {
        // UIを表示
        uiElement.gameObject.SetActive(true);

        // 拡大のための時間経過
        float elapsedTime = 0f;
        Vector3 initialScale = uiElement.localScale;
        Vector3 targetScale = initialScale * maxScale;

        while (elapsedTime < scaleDuration)
        {
            uiElement.localScale = Vector3.Lerp(initialScale, targetScale, elapsedTime / scaleDuration);
            elapsedTime += Time.deltaTime;
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
            uiElement.gameObject.SetActive(false);
        }
    }

   
}
