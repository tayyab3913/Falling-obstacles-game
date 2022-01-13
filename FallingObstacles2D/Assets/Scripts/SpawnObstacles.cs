using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject[] spawnPoints;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("InstantiateObstacles", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InstantiateObstacles()
    {
        int destroyOneObstacle = Random.Range(0, 5);
        GameObject[] tempHolder = new GameObject[5];
        for(int i=0; i<spawnPoints.Length;i++)
        {
            tempHolder[i] = Instantiate(obstacle, spawnPoints[i].transform.position, spawnPoints[i].transform.rotation);
        }
        Destroy(tempHolder[destroyOneObstacle].gameObject);
        //Debug.Log("Index: " + destroyOneObstacle);
    }
}
