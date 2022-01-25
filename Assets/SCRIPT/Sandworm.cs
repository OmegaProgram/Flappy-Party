using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sandworm : MonoBehaviour {
    [SerializeField]
    private GameObject dust;

    [SerializeField]
    private float speed = 5;
    
    [SerializeField]
    private bool kills;

    private float angle = 0;

    [SerializeField]
    private float maxAngleOffset = 15f;

    [SerializeField]
    private float minAngleOffset = -15f;

    private float targetX = 1500;

    private float targetY = 1500;
    
    private GameObject player1;
    private GameObject player2;

    // Start is called before the first frame update
    void Start() {
        player1 = GameObject.FindGameObjectsWithTag("P1")[0];
        player2 = GameObject.FindGameObjectsWithTag("P2")[0];

        targetX = transform.position.x + Random.Range(minAngleOffset, maxAngleOffset) - Time.deltaTime * 5 - 0.05f;
        targetY = -transform.position.y * 2;

        if (transform.position.y < targetY) {
            angle = Mathf.Atan2(targetY, targetX) * Mathf.Rad2Deg - 180;
        } else {
            angle = Mathf.Atan2(targetY, targetX) * Mathf.Rad2Deg;
        }
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    // Update is called once per frame
    void Update() {
        targetX = targetX - Time.deltaTime * 5;
        transform.position = new Vector3(transform.position.x - Time.deltaTime * 5, transform.position.y);
        
        if (transform.position.x < -20) {
            Destroy(gameObject);
        }

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetX, targetY),
                                                 Time.deltaTime * speed - 0.05f);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.transform.tag == "P1" && kills == true || other.transform.tag == "P2" && kills == true) {
            GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(0).gameObject.SetActive(true);
            GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = other.transform.name + " Lost!";
            Time.timeScale = 0;
        }
    }
}
