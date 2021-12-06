using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2playerGun : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet; // bullet prefab
    [SerializeField]
    private float bulletSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // when right arrow is pressed, shoot a bullet at bulletSpeed
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GameObject newBullet = Instantiate(bullet, transform.position + transform.right * 0.5f, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, 0);
        }
    }

}
