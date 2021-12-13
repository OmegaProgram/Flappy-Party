using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public string powerUpName;
    public PowerUpObject powerUpObject;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (powerUpObject == null)
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

    
    public virtual void activateEffect(GameObject player) {
        //null
    }

    //on collision 2d with player, set that player's powerup in GameManager to this powerup's name
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            activateEffect(collision.gameObject);
            if (powerUpObject.spawnable) {
                GameManager.instance.setPowerUp(collision.gameObject.name, powerUpObject);
            }
            Destroy(gameObject);
        }
    }


}
