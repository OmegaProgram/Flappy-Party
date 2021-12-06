using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int P1Life = 3;
    public int P2Life = 3;
    [SerializeField]
    private TextMeshProUGUI countdownText;
    [SerializeField]
    private int countdownTime = 3;

    public static GameManager instance;
    private void Awake() {
        if (instance != null) {
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void death(string player) {
        GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(0).gameObject.SetActive(true);
        GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = player + " Lost!";
        Time.timeScale = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        StartCoroutine(countdown());
    }

    IEnumerator countdown() {
        int countdownTimer = countdownTime;
        while (countdownTimer > 0) {
            countdownText.text = countdownTimer.ToString();
            yield return new WaitForSecondsRealtime(1f);
            countdownTimer--;
        }
        Time.timeScale = 1;
        countdownText.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
