using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        // if it's not a player, destroy itself
        if (other.gameObject.tag != "Player") {
            Destroy(gameObject);
        }
    }
}
