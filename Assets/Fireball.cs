using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Fireball : MonoBehaviour
{
    [SerializeField]
    public float speed = 5;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // make velocity of the object travel left relative to the object at a constant speed
        rb.velocity = transform.right * -speed;

        if (transform.position.x < -20) {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.transform.tag == "Player") {
            // set collider to trigger
            GetComponent<Collider2D>().isTrigger = true;
            GameManager.instance.PlayerHit(other.transform.name);
        } else if (other.transform.tag == "bullet") {
            // create 2 clone of itself and rotate them 25 degrees up and down, make them smaller and move slower
            GameObject clone1 = Instantiate(gameObject, transform.position, Quaternion.Euler(0, 0, 35));
            GameObject clone2 = Instantiate(gameObject, transform.position, Quaternion.Euler(0, 0, -35));
            clone1.transform.localScale = 0.8f * clone1.transform.localScale;
            clone1.GetComponentInChildren<TrailRenderer>().startWidth = 0.8f * clone1.GetComponentInChildren<TrailRenderer>().startWidth;
            clone2.transform.localScale = 0.8f * clone2.transform.localScale;
            clone2.GetComponentInChildren<TrailRenderer>().startWidth = 0.8f * clone2.GetComponentInChildren<TrailRenderer>().startWidth;
            clone1.GetComponent<Fireball>().speed *= 1.2f;
            clone2.GetComponent<Fireball>().speed *= 1.2f;
            //get rid of constraints for position in rigidbody
            clone1.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            clone2.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            // destroy the original object
            Destroy(gameObject);
        }
    }
}
