using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellShocker : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float pieceSpeed = 20f;
    private Rigidbody2D rb;
    [SerializeField]
    private GameObject shellPiece;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        rb.velocity = transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (!other.gameObject.CompareTag("Player")) {
            //instantiate 5 shell pieces that fly towards left in a random angle
            for (int i = 0; i < 5; i++) {
                GameObject piece = Instantiate(shellPiece, transform.position, Quaternion.identity);
                piece.GetComponent<Rigidbody2D>().velocity = new Vector2(-1f, Random.Range(-1, 1f)).normalized * pieceSpeed;
            }
            Destroy(gameObject);
        }
    }
}
