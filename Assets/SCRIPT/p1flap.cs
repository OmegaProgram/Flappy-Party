using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class p1flap : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private Vector2 upforce;

    public void activatePower() {

    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("homing egg")) {
            Debug.Log("I got da homing egg!!!");
            Destroy(other.gameObject);
        } 
        if (other.gameObject.CompareTag("shellshocker")) { 
            Debug.Log("I got da shellshocker!!!");
            Destroy(other.gameObject);
        }
       
    }

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
         rb.velocity = Vector2.zero;
    }


    // Update is called once per frame
    
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            rb.velocity = Vector2.zero;
            rb.AddForce(upforce);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {  
        if (other.transform.tag == "Obstacle") {
                GameManager.instance.P1Lives -= 1;
                Debug.Log("p1 lost a Life"+ other.gameObject.name);
                GameObject collisonobj = other.gameObject;
                collisonobj.GetComponent<PolygonCollider2D>().enabled = false;
                if (GameManager.instance.P1Lives < 1) {
                    GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(0).gameObject.SetActive(true);
                    GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Player 2 Won";  
                    Time.timeScale = 0;
                    Debug.Log("p1 died");
                }
        }
        else if (other.transform.tag == "ground") {
            GameManager.instance.P1Lives -= 1;
                Debug.Log("p1 lost a Life" + other.gameObject.name);
                GameObject collisonobj = other.gameObject;
                if (GameManager.instance.P1Lives < 1) {
                    GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(0).gameObject.SetActive(true);
                    GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Player 2 Won";  
                    Time.timeScale = 0;
                    Debug.Log("p1 died");
                }
        }
    }
    IEnumerator countdown(float delay) {
        yield return new WaitForSecondsRealtime(delay);
        rb.velocity = Vector2.zero;
    }
    IEnumerator recover(float delay) {
        yield return new WaitForSecondsRealtime(delay);
        this.GetComponent<CircleCollider2D>().enabled = true;
    }
}





