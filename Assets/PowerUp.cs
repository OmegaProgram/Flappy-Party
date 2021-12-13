using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //remove gravity
        rb.gravityScale = 0;

    }

    // Update is called once per frame
    void Update()
    {
        //fly towards left at variable speed
        rb.velocity = -transform.right * speed;
    }

    //when player collides with powerup, run powerup function
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            PowerUpFunction();
        }
    }
   

    //overridable function to run when player collides with powerup
    public virtual void PowerUpFunction()
    {
        //destroy powerup
        
        
    }
}
