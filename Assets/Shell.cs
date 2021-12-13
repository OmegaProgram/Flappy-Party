using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;

    [SerializeField]
    private float health = 5f;

     
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
     rb.AddForce(Vector2.right * speed);
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("I hit" + other.gameObject.name);
        health--;
        if(health <= 0) {
            Destroy(gameObject);
        }
        speed = -speed;
    }

    
   
}
