using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;
    private float originalY;
    private float randomOffset;
    private float randomHeight;
    private bool dead = false;
    // Start is called before the first frame update
    void Start()
    {
        originalY = transform.position.y;
        randomOffset = Random.Range(-20f, 20f);
        randomHeight = Random.Range(0.5f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead) {
            //move left while floating up and down with sinusoidal movement
            transform.position = new Vector3(transform.position.x, originalY + Mathf.Sin(3* Time.time + randomOffset) * randomHeight, transform.position.z);
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            // if x is less than -15, destroy the object
            if (transform.position.x < -15)
            {
                Destroy(gameObject);
            }
        } else {
            // stop animation
            GetComponent<Animator>().enabled = false;
            if (transform.position.y < -20)
            {
                Destroy(gameObject);
            }
        }
        
        
    }

    //if collides with object tagged bullet, set dead to true, flip the object upside down, and destroy the bullet
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            dead = true;
            transform.Rotate(0, 0, 180);
            // set rigidboy2d to dynamic so it can fall
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            // set boxcollider to trigger so it can fall
            GetComponent<BoxCollider2D>().isTrigger = true;
            Destroy(collision.gameObject);
        } else if (collision.gameObject.tag == "Player") {
            GameManager.instance.death(collision.transform.name);
        }
    }
}
