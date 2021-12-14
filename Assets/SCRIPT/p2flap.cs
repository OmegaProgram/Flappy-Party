using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p2flap : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private Vector2 upforce;
    
    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            rb.velocity = Vector2.zero;
            rb.AddForce(upforce); 
        }
    }
}
