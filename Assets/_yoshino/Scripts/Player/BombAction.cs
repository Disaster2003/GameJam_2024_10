using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // deltaTime��OFF
        Time.timeScale = 0;
    }

    private void FixedUpdate()
    {
        // �|�[�Y��
        if(GameManager.GetInstance().GetIsPausing()) return;

        // �����ŏ������s���B
        // �X�V������Time.fixedDeltaTime��p����B
    }
}
