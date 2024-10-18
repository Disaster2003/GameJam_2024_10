using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChacker : MonoBehaviour
{
    enum mode   //hakai suruka douka no mo-do
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
        _Dead();
    }

    //MainCamera no naka ni haitteiru aida ha Render ni suru
    private void OnWillRenderObject()
    {
        if (Camera.current.name == "Main Camera")
        {
            _mode = mode.Render;
        }
    }


    //MainCamera kara detara hakaisuru
    private void _Dead()
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
