using UnityEngine;
using TMPro;

public class FlappyBird : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private Vector2 upforce;
    [SerializeField]
    private KeyCode jumpKey = KeyCode.Space;
    [SerializeField]
    private KeyCode usePowerUpKey = KeyCode.F;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(jumpKey) && Time.timeScale == 1){
            rb.velocity = Vector2.zero;
            rb.AddForce(upforce);
        }
        if (Input.GetKeyDown(usePowerUpKey) && Time.timeScale == 1){
            usePowerUp();
        }
    }

    public void usePowerUp() {
        GameManager.instance.usePowerUp(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("homing egg")){
            Debug.Log("I got da homing egg!!!");
            Destroy(other.gameObject);
        }
    }

    

}
