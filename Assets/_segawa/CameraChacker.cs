using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChacker : MonoBehaviour
{
    enum mode   //破壊するかどうかのmode
    {
        None,
        Render,
        RenderOut,
    }

    private mode _mode;
    // Start is called before the first frame update
    void Start()
    {
        _mode = mode.None;
    }

    // Update is called once per frame
    void Update()
    {
        isDead();
    }

    //MainCamera の中に入ってる間はRenderにする
    private void OnWillRenderObject()
    {
        if (Camera.current.name == "Main Camera")
        {
            _mode = mode.Render;
        }
    }


    //MainCamera から出たら廃棄する
    private void isDead()
    {
        if (_mode == mode.RenderOut)
        {
            Destroy(gameObject);
        }
        else if (_mode == mode.Render)
        {
            _mode = mode.RenderOut;
        }
    }
}
