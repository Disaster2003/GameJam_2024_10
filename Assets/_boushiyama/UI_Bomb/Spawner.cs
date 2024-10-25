using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject spritePrefab; // プレハブを格納
    [SerializeField] private float upwardForce = 5f; // 縦方向の飛ばす力
    [SerializeField] private float sidewaysForce = 5f; // 横方向の飛ばす力
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // スペースキーが押されたら
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
            randomSpriteSelector.LaunchUpward(upwardForce); // 縦方向に飛ばす
            randomSpriteSelector.LaunchSideways(sidewaysForce); // 横方向に飛ばす
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }
}
    
   
