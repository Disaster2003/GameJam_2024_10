using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEffectDestory : MonoBehaviour
{
    [SerializeField, Header("�G�t�F�N�g�̐�������")]
    private float effectTime = 1f;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        if(audioSource != null)
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.Play();
        }
        Destroy(gameObject, effectTime);
    }
}
