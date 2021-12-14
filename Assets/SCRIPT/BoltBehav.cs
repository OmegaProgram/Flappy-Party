using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoltBehav : MonoBehaviour {
    private float speed = 5;

    private GameObject player1;
    private GameObject player2;

    private float targetX = 1500;

    private float targetY = 1500;

    // Start is called before the first frame update
    void Start() {
        player1 = GameObject.FindGameObjectsWithTag("P1")[0];
        player2 = GameObject.FindGameObjectsWithTag("P2")[0];
    }

    // Update is called once per frame
    void Update() {
        if(targetX == 1500 && targetY == 1500) {
            targetX = transform.position.x - Time.deltaTime * speed - 0.05f;
            targetY = Mathf.Abs(player1.transform.position.y + player2.transform.position.y) / 2;
        }

        transform.position = new Vector3(transform.position.x - Time.deltaTime * speed - 0.05f, 
                                         transform.position.y);

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetX, targetY),
                                                 Time.deltaTime * speed - 0.05f);
                                                 
        if (transform.position.x < -20) {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.transform.tag == "P1" || other.transform.tag == "P2") {
            GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(0).gameObject.SetActive(true);
            GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = other.transform.name + " Lost!";
            Time.timeScale = 0;
        }
    }
}
