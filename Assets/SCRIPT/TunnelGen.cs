using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelGen : MonoBehaviour 
{
    [SerializeField]
    private GameObject caveWall;

    [SerializeField]
    private GameObject bug;

    [SerializeField]
    private GameObject worm;

    [SerializeField]
    private float timeInterval;

    [SerializeField]
    private float upperBound;

    [SerializeField]
    private float lowerBound;

    [SerializeField]
    private float chanceOfBoltBug;

    [SerializeField]
    private float chanceOfWorm;

    private float timer = 0;
    private float height = -4f;
    private bool tendsUp = true;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        float random;
        if (timer <= 0) {
            random = Random.Range(0f, 100f);

            if (height > upperBound) {
                tendsUp = false;
            } else if (height < lowerBound) {
                tendsUp = true;
            }

            if (tendsUp == false) {
                height += Random.Range(-0.5f, 0.1f);
            } else {
                height += Random.Range(-0.1f, 0.5f);
            }

            if (random <= chanceOfBoltBug) {
                spawnCaveWall();
                spawnBug();
            } else {
                spawnCaveWall();
            }

            random = Random.Range(0f, 100f);

            if (random <= chanceOfWorm) {
                spawnCaveWall();
                spawnWorm();
            } else {
                spawnCaveWall();
            }

            timer = timeInterval;
        }
        timer -= Time.deltaTime;
    }

    void spawnCaveWall() {
        Instantiate(caveWall, new Vector3(20, height), Quaternion.identity);
    }

    void spawnBug() {
        Instantiate(bug, new Vector3(20, height + 2.555f), Quaternion.identity);
    }

    void spawnWorm() {
        Instantiate(worm, new Vector3(20, Random.Range(0f, 100f) > 50? height * -2 : height*2), Quaternion.identity);
    }
}
