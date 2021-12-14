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

    [SerializeField]
    private float dustInterval = 1f;

    private float dustTimer = 1f;

    

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        transform.position = new Vector3(transform.position.x - Time.deltaTime * speed, transform.position.y);
        if (transform.position.x < -20) {
            Destroy(gameObject);
        }
        if (dustTimer <= 0) {
            makeDust();
            dustTimer = dustInterval;
        }
        dustTimer -= Time.deltaTime;
    }

    void makeDust() {
        Instantiate(dust, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.transform.tag == "P1" && kills == true || other.transform.tag == "P2" && kills == true) {
            GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(0).gameObject.SetActive(true);
            GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = other.transform.name + " Lost!";
            Time.timeScale = 0;
        }
    }
}
