using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWin : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerHealth playerHealth;
            playerHealth= other.gameObject.GetComponent<PlayerHealth>();
            playerHealth.CheckWin();
        }
    }
}
