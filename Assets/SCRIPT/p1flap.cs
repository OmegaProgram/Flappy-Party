using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1flap : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private Vector2 upforce;
    
    // Start is called before the first frame update
 void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            rb.velocity = Vector2.zero;
            rb.AddForce(upforce);
        }
    }

    public void activatePower() {
        
    }
 private void OnTriggerEnter2D(Collider2D other){
    if (other.gameObject.CompareTag("homing egg")){
        Debug.Log("I got da homing egg!!!");
        Destroy(other.gameObject);
    }
}

}
