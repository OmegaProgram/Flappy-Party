using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//add it to asset menu
[CreateAssetMenu(fileName = "PowerUpObject", menuName = "PowerUpObject", order = 1)]
public class PowerUpObject : ScriptableObject
{
    public string powerUpName;
    public Sprite powerUpIcon;
    public GameObject powerUpPrefab;
    public GameObject ediblePowerUp;
    public bool spawnable;

    public void usePowerUp(GameObject Player) {
        Instantiate(powerUpPrefab, Player.transform.position + new Vector3(1f, 0), Quaternion.identity);
    }
    

}
