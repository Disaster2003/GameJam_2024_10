using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderOutDeleteObject : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<Renderer>().isVisible)
        {
            // é©êgÇÃîjâÛ
            Destroy(gameObject);
        }
    }
}
