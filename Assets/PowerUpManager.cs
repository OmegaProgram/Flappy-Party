using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public static PowerUpManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public PowerUpObject[] powerUpObjects;
    private float timer;
    private float spawnDelay = 5f;
    [SerializeField]
    private float minY = -3f;
    [SerializeField]
    private float maxY = 5;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update() {
        //for every spawnDelay, spawn a random powerup from powerUps at x=20, y= random from -5 to 5. 
        timer += Time.deltaTime;
        if (timer > spawnDelay)
        {
            timer = 0;
            int randomIndex = Random.Range(0, powerUpObjects.Length);
            GameObject powerUp = Instantiate(powerUpObjects[randomIndex].ediblePowerUp, new Vector3(20, Random.Range(minY, maxY), 0), Quaternion.identity);
            powerUp.GetComponent<PowerUp>().powerUpObject = powerUpObjects[randomIndex];
        }
    }

}
