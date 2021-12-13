using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int P1Life = 3;
    public int P2Life = 3;
    public PowerUpObject P1Powerup;
    public PowerUpObject P2Powerup;
    [SerializeField]
    private TextMeshProUGUI countdownText;
    [SerializeField]
    private int countdownTime = 3;
    [SerializeField]
    private GameObject[] P1lifeIcons;
    [SerializeField]
    private GameObject[] P2lifeIcons;
    

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

    public void PlayerHit(string Player) {
        if (Player == "Player 1") {
            P1Life--;
        } else {
            P2Life--;
        }
    }

    public void PlayerHit(string Player, int amout) {
        if (Player == "Player 1") {
            P1Life-= amout;
        } else {
            P2Life-=amout;
        }
    }

    public void addHealth(string Player, int amout) {
        // if Player is Player 1 and the final health is less than 4, add health. If the health is over 4, set it as 4. 
        if (Player == "Player 1") {
            if (P1Life + amout <= 4) {
                P1Life += amout;
            } else if (P1Life + amout > 4){
                P1Life = 4;
            }
        } else {
            if (P2Life + amout < 4) {
                P2Life += amout;
            } else if (P2Life + amout > 4) {
                P2Life = 4;
            }
        }
    }

    public void usePowerUp(GameObject Player) {
        if (Player.name == "Player 1") {
            //if P1Powerup is not -1, instantiate the powerup with the p1Powerup from array
            if (P1Powerup != null) {
                P1Powerup.usePowerUp(Player);
            }
            P1Powerup = null;
        } else {
            //repeat for P2
            if (P2Powerup != null) {
                P2Powerup.usePowerUp(Player);
            }
            
            P2Powerup = null;
        }
    }
    public void setPowerUp(string player, PowerUpObject powerup) {
        if (player == "Player 1") {
            P1Powerup = powerup;
        } else {
            P2Powerup = powerup;
        }
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
        if (P1Life <= 0) {
            death("Player 1");
        }
        if (P2Life <= 0) {
            death("Player 2");
        }
        for (int i = P1lifeIcons.Length-1; i >= 0 ; i--) {
            if (i < P1Life) {
                P1lifeIcons[i].SetActive(true);
            } else {
                P1lifeIcons[i].SetActive(false);
            }
        }
        for (int i = P2lifeIcons.Length-1; i >= 0; i--) {
            if (i < P2Life) {
                P2lifeIcons[i].SetActive(true);
            } else {
                P2lifeIcons[i].SetActive(false);
            }
        }
    }



}
