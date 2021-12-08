using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellPiece : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        //if player, deal 1 damage to that player
        if (other.gameObject.tag == "Player") {
            GameManager.instance.PlayerHit(other.gameObject.name);
        }
    }
}
