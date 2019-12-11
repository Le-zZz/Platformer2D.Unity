using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxWin : MonoBehaviour
{

    [SerializeField] private GameObject box;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerHealth playerHealth;
            playerHealth= other.gameObject.GetComponent<PlayerHealth>();
            playerHealth.TakeBox();
            box.SetActive(true);
        }
    }
}
