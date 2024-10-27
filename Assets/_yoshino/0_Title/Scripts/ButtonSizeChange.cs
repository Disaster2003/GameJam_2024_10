using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BottonSizeChange : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    public float scaleSpeed = 2.0f;          // 拡大・縮小の速度
    public float maxScale = 1.2f;       // 最大サイズ倍率
    public float minScale = 1.0f;       // 最小サイズ倍率（通常のサイズ）

    private bool isHovering = false;  // マウスがUI上にあるかどうかのフラグ
    private RectTransform rectTransform; // UI要素のRectTransform
    private float targetScale;         // 現在のスケールターゲット
    private Vector3 initialScale;

    // 初期化処理
    void Start()
    {
        rectTransform = GetComponent<RectTransform>(); // RectTransformコンポーネントを取得
        targetScale = minScale; // 初期ターゲットスケールを最小スケールに設定
        initialScale = rectTransform.localScale;
    }

    // フレームごとの更新処理
    void Update()
    {
        if (isHovering) // マウスがUI上にある場合
        {
            // スケールを更新
            rectTransform.localScale = Vector3.Lerp(rectTransform.localScale, new Vector3(targetScale, targetScale, 1), Time.unscaledDeltaTime * scaleSpeed);

            // スケールのターゲットを切り替え
            if (Mathf.Abs(rectTransform.localScale.x - targetScale) < 0.01f) // スケールが目標に近づいたら
            {
                targetScale = targetScale == minScale ? maxScale : minScale; // ターゲットを切り替える
            }
        }
    }

    // マウスがUI要素に乗った時の処理
    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true; // マウスがUI上に乗った状態にする
        Debug.Log("Enter");
    }

    // マウスがUI要素から離れた時の処理
    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false; // マウスがUIから離れた状態にする
        rectTransform.localScale = initialScale; // 初期スケールに戻す
        Debug.Log("Enter");
    }
}
