using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour 
{
    [SerializeField]
    private float speed = 1;

    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update() {
        transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
        if (transform.position.x < -35.6f) {
            transform.position = new Vector3(35.6f, 0, 0);
        }
    }
}
