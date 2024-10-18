using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChacker : MonoBehaviour
{
    enum mode   //”j‰ó‚·‚é‚©‚Ç‚¤‚©‚Ìmode
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

    //MainCamera ‚Ì’†‚É“ü‚Á‚Ä‚éŠÔ‚ÍRender‚É‚·‚é
    private void OnWillRenderObject()
    {
        if (Camera.current.name == "Main Camera")
        {
            _mode = mode.Render;
        }
    }


    //MainCamera ‚©‚ço‚½‚ç”pŠü‚·‚é
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
