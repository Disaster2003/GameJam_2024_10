using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // deltaTimeをOFF
        Time.timeScale = 0;
    }

    private void FixedUpdate()
    {
        // ポーズ中
        if(GameManager.GetInstance().GetIsPausing()) return;

        // ここで処理を行う。
        // 更新処理はTime.fixedDeltaTimeを用いる。
    }
}
