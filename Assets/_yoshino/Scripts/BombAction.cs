using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    private void FixedUpdate()
    {
        // ここで処理を行う。
        // 更新処理はTime.fixedDeltaTimeを用いる。
    }

    private void OnDestroy()
    {
        Time.timeScale = 1;
    }
}
