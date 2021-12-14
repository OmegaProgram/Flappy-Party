using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour 
{
    [SerializeField]
    private GameObject pillar;
    [SerializeField]
    private float timeInterval = 4f;
    private float timer = 0;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (timer <= 0) {
            spawnPillar();
            timer = timeInterval;
        }
        timer -= Time.deltaTime;
    }

    void spawnPillar() {
        Instantiate(pillar, new Vector3(20, Random.Range(-3.82f, -1.27f)), Quaternion.identity);
    }
}
