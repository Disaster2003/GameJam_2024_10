using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private enum STATE_ENEMY
    {
        STRAIGHT,       // ���i
        LITTLE_MOVE,    // ���傢�i��Ŏ~�܂�
        WAVE_MOVE,      // �����Ȃ���Sin�g
        WAVE_STAY,      // ���܂���Sin�g
        WAVE_STAY2,     // ���܂���Sin�g
        WAVE_STAY3,     // ���܂���Sin�g
        DOWN,           // ���~
        UP,             // �㏸
        WANDER,         // �p�j
        WANDER2,        // �p�j
    }
    [SerializeField, Header("�G�̓�����")]
    private STATE_ENEMY state_enemy;

    [SerializeField, Header("�ړ����x")]
    private float speedMove;

    [SerializeField, Header("�ڕW�n�_")]
    private Vector3 positionGoal;
    [SerializeField, Header("�㉺��")]
    private float widthVertical;
    private bool isArrived; // true = �ڕW�n�_�ɓ���, false = �ڕW�n�_�ɖ����B
    [SerializeField, Header("�ҋ@����")]
    private float timeWait;
    private float timer;

    private EnemyBase enemyBase;


    // Start is called before the first frame update
    void Start()
    {
        CSVInit();

        // ������Ԃ̏�����
        isArrived = false;
        enemyBase = GetComponent<EnemyBase>();
        positionGoal.y = transform.localPosition.y; 
    }

    // Update is called once per frame
    void Update()
    {
        if (!enemyBase.GetDeathFlag())
        {
            Move();
        }      
    }

    void CSVInit()
    {
        if(state_enemy == STATE_ENEMY.STRAIGHT ||
            state_enemy == STATE_ENEMY.WAVE_MOVE)
        {
            // ����͑ΏۊO
            return;
        }

        // CSV�̓ǂݍ���
        TextAsset csvFile = Resources.Load("EnemyMove") as TextAsset; // Resources�ɂ���CSV�t�@�C�����i�[
        StringReader reader = new StringReader(csvFile.text); // TextAsset��StringReader�ɕϊ�
        List<string[]> csvData = new List<string[]>(); // CSV�t�@�C���̒��g�����郊�X�g
        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine(); // 1�s���ǂݍ���
            csvData.Add(line.Split(',')); // csvData���X�g�ɒǉ�����
        }

        int i;
        for (i = 1; i < csvData.Count; i++)
        {
            if (Enum.TryParse(csvData[i][0], true, out STATE_ENEMY state))
            {
                if (state_enemy == state) break;
            }
        }

        // CSV�̑��
        speedMove = float.Parse(csvData[i][1]);
        positionGoal = new Vector3(float.Parse(csvData[i][2]), float.Parse(csvData[i][3]));
        widthVertical = float.Parse(csvData[i][4]);
        timeWait = float.Parse(csvData[i][5]);
    }

    /// <summary>
    /// �ړ�����
    /// </summary>
    private void Move()
    {
        switch (state_enemy)
        {
            case STATE_ENEMY.STRAIGHT:
                transform.Translate(speedMove * -Time.deltaTime, 0, 0);
                break;
            case STATE_ENEMY.LITTLE_MOVE:
                transform.position = Vector3.MoveTowards(transform.position, positionGoal, speedMove * Time.deltaTime);
                break;
            case STATE_ENEMY.WAVE_MOVE:
                transform.Translate(speedMove * -Time.deltaTime, 0, 0);
                float sinY = Mathf.Sin(Time.time);
                transform.position = new Vector3(transform.position.x, widthVertical * sinY);
                break;
            case STATE_ENEMY.WAVE_STAY:
            case STATE_ENEMY.WAVE_STAY2:
            case STATE_ENEMY.WAVE_STAY3:
                if (isArrived)
                {
                    if(timeWait > 0)
                    {
                        // �ҋ@��
                        timeWait += -Time.deltaTime;
                        return;
                    }

                    timer += Time.deltaTime;
                    sinY = Mathf.Sin(timer);
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
            case STATE_ENEMY.DOWN:
                transform.Translate(speedMove * -Time.deltaTime, speedMove * 0.5f * -Time.deltaTime, 0);
                break;
            case STATE_ENEMY.UP:
                transform.Translate(speedMove * -Time.deltaTime, speedMove * 0.5f * Time.deltaTime, 0);
                break;
            case STATE_ENEMY.WANDER:
            case STATE_ENEMY.WANDER2:
                if(speedMove > 0 && timer >= timeWait)
                {
                    timer = 0;
                    speedMove *= -1;
                }
                else if(speedMove < 0 && timer >= timeWait * 0.5f)
                {
                    timer = 0;
                    speedMove *= -1;
                }
                timer += Time.deltaTime;

                transform.Translate(speedMove * -Time.deltaTime, 0, 0);
                break;
        }
    }
}
