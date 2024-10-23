using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    [SerializeField, Header("�Q�[���J�n���̈ʒu")]
    private Vector3 startposition;

    [SerializeField, Header("�����������ۂ̈ʒu")]
    private Vector3 positionInitialize;

    [SerializeField, Header("�X�N���[���I���ʒu��x���W")]
    private float position_xEnd;
    [SerializeField, Header("�ړ����x")]
    private float speedMove;


    // Start is called before the first frame update
    void Start()
    {
        // �����z�u
        transform.position = startposition;
    }

    // Update is called once per frame
    void Update()
    {
        // �O�i�̃X�N���[��
        transform.Translate(speedMove * Time.deltaTime, 0, 0);

        if (transform.position.x <= position_xEnd)
        {
            // �����ʒu�ɖ߂�
            transform.position = positionInitialize;
        }
    }
}
