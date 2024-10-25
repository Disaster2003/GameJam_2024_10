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
        WAVE_STAY,      // 留まってSin波
        DOWN,           // 下降
        UP,             // 上昇
        WANDER,         // 徘徊
    }
    [SerializeField, Header("敵の動き方")]
    private STATE_ENEMY state_enemy;

    [SerializeField, Header("移動速度")]
    private float speedMove;

    [SerializeField, Header("目標地点")]
    private Vector3 positionGoal;
    [SerializeField, Header("上下幅")]
    private float widthVertical;
    private bool isArrived; // true = 目標地点に到着, false = 目標地点に未到達
    [SerializeField, Header("待機時間")]
    private float timeWait;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
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
            case STATE_ENEMY.DOWN:
                transform.Translate(speedMove * -Time.deltaTime, speedMove * 0.5f * -Time.deltaTime, 0);
                break;
            case STATE_ENEMY.UP:
                transform.Translate(speedMove * -Time.deltaTime, speedMove * 0.5f * Time.deltaTime, 0);
                break;
            case STATE_ENEMY.WANDER:
                if(speedMove < 0 && timer >= timeWait)
                {
                    timeWait = 0;
                    speedMove *= -1;
                }
                else if(timer >= timeWait * 0.5f)
                {
                    timeWait = 0;
                    speedMove *= -1;
                }
                timer += Time.deltaTime;

                transform.Translate(speedMove * -Time.deltaTime, 0, 0);
                break;
        }
    }
}
