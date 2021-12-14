using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Controller : MonoBehaviour 
{
    [SerializeField]
    private GameObject pillar;
    [SerializeField]
    private float timeInterval = 4f;
    [SerializeField]
    private TextMeshProUGUI timerText;

    private float timer = 0;

    // Start is called before the first frame update
    void Start() {
        Time.timeScale = 0;
        StartCoroutine(countdown());
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
    IEnumerator countdown() {
        int countdownTimer = 5;
        while (countdownTimer > 0) {
            yield return new WaitForSecondsRealtime(1f);
            countdownTimer--;
            timerText.text = countdownTimer.ToString();
        }
        timerText.gameObject.SetActive(false);
        Time.timeScale = 1;
        
    }
}

