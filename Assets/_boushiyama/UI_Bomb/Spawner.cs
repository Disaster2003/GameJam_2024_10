using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject spritePrefab; // �v���n�u���i�[
    [SerializeField] private float upwardForce = 5f; // �c�����̔�΂���
    [SerializeField] private float sidewaysForce = 5f; // �������̔�΂���
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // �X�y�[�X�L�[�������ꂽ��
        {
            SpawnAndLaunch();
        }
    }

    void SpawnAndLaunch()
    {
        GameObject instance = Instantiate(spritePrefab, transform.position, Quaternion.identity);
        RandomSpriteSelector randomSpriteSelector = instance.GetComponent<RandomSpriteSelector>();
        if (randomSpriteSelector != null)
        {
            randomSpriteSelector.LaunchUpward(upwardForce); // �c�����ɔ�΂�
            randomSpriteSelector.LaunchSideways(sidewaysForce); // �������ɔ�΂�
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }
}
    
   
