using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot2 : EnemyShot
{
    public int RapidShot;   //�A�˒e��
    public float RapidWait; //�A�ˊԊu

    private float rapidmati;    //�A�ˊԊu�̏���
    private int rapidtama;      //�A�˒e���̏���
    // Start is called before the first frame update
    void Start()
    {
        spawnwait = 0;
        rapidmati = RapidWait;
        rapidtama = 0;
    }

    // Update is called once per frame
    void Update()
    {
        spawnwait += Time.deltaTime;
        if (spawnwait >= wait)  //�ҋ@���Ԃ𒴂�����
        {
            for (int i=0;i<RapidShot;i++)//�ݒ肵�����e������
            {
                if (rapidmati <= 0) rapidshot();
            }
            if(rapidtama==10)rapidreset();
            if(rapidmati!=0) rapidmati -= Time.deltaTime;

        }
    }

    //�A�˂̒e������
    private void rapidshot()
    {
        ShotSpawn();
        rapidmati = 0;
        rapidtama++;
        rapidmati = RapidWait;
    }

    //�A�˂̃��Z�b�g
    private void rapidreset()
    {
        spawnwait = 0;
        rapidtama = 0;

    }
}
