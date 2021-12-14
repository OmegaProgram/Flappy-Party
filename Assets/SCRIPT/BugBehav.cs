using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BugBehav : MonoBehaviour {
    [SerializeField]
    private GameObject bolt;

    [SerializeField]
    private float speed = 5;
    
    [SerializeField]
    private bool kills;

    [SerializeField]
    private float boltInterval = 4f;

    private float boltTimer = 4f;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        transform.position = new Vector3(transform.position.x - Time.deltaTime * speed, transform.position.y);
        if (transform.position.x < -20) {
            Destroy(gameObject);
        }
        if (boltTimer <= 0) {
            launchBolt();
            boltTimer = boltInterval;
        }
        boltTimer -= Time.deltaTime;
    }

    void launchBolt() {
        Instantiate(bolt, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.transform.tag == "P1" && kills == true || other.transform.tag == "P2" && kills == true) {
            GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(0).gameObject.SetActive(true);
            GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = other.transform.name + " Lost!";
            Time.timeScale = 0;
        }
    }
}
