using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private GameObject snowMan;
    [SerializeField] private GameObject littleSnowMan;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerHealth playerHealth;
            playerHealth= other.gameObject.GetComponent<PlayerHealth>();
            playerHealth.TakeHealth();
            snowMan.SetActive(false);
            littleSnowMan.SetActive(true);
        }
    }
}
