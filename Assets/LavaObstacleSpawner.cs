using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaObstacleSpawner : MonoBehaviour
{
    [System.Serializable]
    public struct Obstacle {
        public GameObject prefab;
        public float minY;
        public float maxY;
        public float minSpawnInterval;
        public float maxSpawnInterval;
        public float timer;
    }

    [SerializeField]
    private List<Obstacle> obstacles = new List<Obstacle>();
    private float[] timers;

    void Start()
    { 
        //create a timer for each obstacles in timers array
        timers = new float[obstacles.Count];
        for (int i = 0; i < timers.Length; i++)
        {
            timers[i] = Random.Range(obstacles[i].minSpawnInterval, obstacles[i].maxSpawnInterval);
        }
    }


    // Update is called once per frame
    void Update() {
        // loop through all timers using for loop, subtract it by deltaTime, and if it's less than 0, spawn the obstacle with same index
        for (int i = 0; i < timers.Length; i++)
        {
            timers[i] -= Time.deltaTime;
            if (timers[i] < 0)
            {
                SpawnObstacle(obstacles[i]);
                timers[i] = Random.Range(obstacles[i].minSpawnInterval, obstacles[i].maxSpawnInterval);
            }
        }
    }
    
    void SpawnObstacle(Obstacle obstacle) {
        // create a new obstacle at a random y position between minY and maxY
        float yPos = Random.Range(obstacle.minY, obstacle.maxY);
        Vector3 pos = new Vector3(13, yPos, transform.position.z);
        Instantiate(obstacle.prefab, pos, Quaternion.identity);
    }

}
