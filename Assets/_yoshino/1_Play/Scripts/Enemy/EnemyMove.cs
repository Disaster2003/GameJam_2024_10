using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private enum STATE_ENEMY
    {
        STRAIGHT,       // 直進
        LEFT_AND_RIGHT, // 左右
        WAVE_MOVE,      // 動きながらSin波
        WAVE_STAY       // 留まってSin波
    }
    [SerializeField, Header("敵の動き方")]
    private STATE_ENEMY state_enemy;

    [SerializeField, Header("初期位置")]
    private Vector3 positionInitialize;
    [SerializeField, Header("移動速度")]
    private float speedMove;

    [SerializeField, Header("目標地点")]
    private Vector3 positionGoal;
    [SerializeField, Header("上下幅")]
    private float widthVertical;
    private bool isArrived;
    [SerializeField, Header("待機時間")]
    private float timeWait;

    // Start is called before the first frame update
    void Start()
    {
        // 初期配置
        transform.position = positionInitialize;

        // 到着状態の初期化
        isArrived = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    /// <summary>
    /// 移動処理
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
                    // 自身の破壊
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
                        // 待機中
                        timeWait += -Time.deltaTime;
                        return;
                    }

                    transform.position = new Vector3(transform.position.x, widthVertical * sinY);
                }
                else
                {
                    if (transform.position == positionGoal)
                    {
                        // 到着
                        isArrived = true;
                    }

                    transform.position = Vector3.MoveTowards(transform.position, positionGoal, speedMove * Time.deltaTime);
                }
                break;
        }
    }
}
