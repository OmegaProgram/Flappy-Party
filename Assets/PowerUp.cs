using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public string powerUpName;
    public int id = -1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (id == -1)
        { 
            Destroy(gameObject);
        }
        // if x < -20, destroy this gameObject
        if (transform.position.x < -20)
        {
            Destroy(gameObject);
        }
        //move left at constant speed
        transform.Translate(Vector3.left * Time.deltaTime * 3);
    }

    //on collision 2d with player, set that player's powerup in GameManager to this powerup's name
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.setPowerUp(collision.gameObject.name, id);
            Destroy(gameObject);
        }
    }


}
