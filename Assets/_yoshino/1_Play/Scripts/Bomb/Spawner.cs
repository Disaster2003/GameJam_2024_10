using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject spritePrefab; // ƒvƒŒƒnƒu‚ğŠi”[
    [SerializeField] private float upwardForce = 5f; // c•ûŒü‚Ì”ò‚Î‚·—Í
    [SerializeField] private float sidewaysForce = 5f; // ‰¡•ûŒü‚Ì”ò‚Î‚·—Í
    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.B))
        //{
        //   SpawnAndLaunch();
        //}
    }

    void SpawnAndLaunch()
    {
        GameObject instance = Instantiate(spritePrefab, transform.position, Quaternion.identity);
        RandomSpriteSelector randomSpriteSelector = instance.GetComponent<RandomSpriteSelector>();
        if (randomSpriteSelector != null)
        {
            randomSpriteSelector.LaunchUpward(upwardForce); // c•ûŒü‚É”ò‚Î‚·
            randomSpriteSelector.LaunchSideways(sidewaysForce); // ‰¡•ûŒü‚É”ò‚Î‚·
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    public void SpawnBomb()
    {
        SpawnAndLaunch();
    }
}
    
   
