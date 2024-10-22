using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public GameObject Shot;             //�e�̃v���r���[
    public float wait;                  //�ҋ@����


    protected float spawnwait;          //�ҋ@���Ԃ̏���

    // Start is called before the first frame update
    void Start()
    {
        spawnwait = 0;

    }

    // Update is called once per frame
    void Update()
    {
        spawnwait += Time.deltaTime;
        //�ҋ@���Ԃ𒴂�����e���X�|�[��������
        if (spawnwait >= wait)
        {

            ShotSpawn();
            spawnwait = 0;
        }

    }

    //�e���X�|�[��������֐�
    public void ShotSpawn()
    {
        Instantiate(Shot, transform.position, transform.rotation);
    }
}
