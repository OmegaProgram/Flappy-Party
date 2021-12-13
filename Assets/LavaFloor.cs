using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LavaFloor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.transform.tag == "Player") {
            GameManager.instance.PlayerHit(other.transform.name, 4);
        }
    }
}
