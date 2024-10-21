using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private enum STATE_ENEMY
    {
        STRAIGHT,       // ���i
        LEFT_AND_RIGHT, // ���E
        WAVE_MOVE,      // �����Ȃ���Sin�g
        WAVE_STAY       // ���܂���Sin�g
    }
    [SerializeField, Header("�G�̓�����")]
    private STATE_ENEMY state_enemy;

    [SerializeField, Header("�����ʒu")]
    private Vector3 positionInitialize;
    [SerializeField, Header("�ړ����x")]
    private float speedMove;

    [SerializeField, Header("�ڕW�n�_")]
    private Vector3 positionGoal;
    [SerializeField, Header("�㉺��")]
    private float widthVertical;
    private bool isArrived;
    [SerializeField, Header("�ҋ@����")]
    private float timeWait;

    // Start is called before the first frame update
    void Start()
    {
        // �����z�u
        transform.position = positionInitialize;

        // ������Ԃ̏�����
        isArrived = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    /// <summary>
    /// �ړ�����
    /// </summary>
    private void Move()
    {
        float sinY = Mathf.Sin(Time.time);

        switch (state_enemy)
        {
            case STATE_ENEMY.STRAIGHT:
                transform.Translate(speedMove * -Time.deltaTime, 0, 0);
                break;
            case STATE_ENEMY.LEFT_AND_RIGHT:
                if(transform.position == positionGoal)
                {
                    // ���g�̔j��
                    Destroy(gameObject);
                }

                transform.position = Vector3.MoveTowards(transform.position, positionGoal, speedMove * Time.deltaTime);
                break;
            case STATE_ENEMY.WAVE_MOVE:
                transform.Translate(speedMove * -Time.deltaTime, 0, 0);
                transform.position = new Vector3(transform.position.x, widthVertical * sinY);
                break;
            case STATE_ENEMY.WAVE_STAY:
                if (isArrived)
                {
                    if(timeWait > 0)
                    {
                        // �ҋ@��
                        timeWait += -Time.deltaTime;
                        return;
                    }

                    transform.position = new Vector3(transform.position.x, widthVertical * sinY);
                }
                else
                {
                    if (transform.position == positionGoal)
                    {
                        // ����
                        isArrived = true;
                    }

                    transform.position = Vector3.MoveTowards(transform.position, positionGoal, speedMove * Time.deltaTime);
                }
                break;
        }
    }
}
