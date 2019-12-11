using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    
    private int health = 1;
    private int maxHealth = 3;
    private float box = 0;

    [SerializeField] private GameObject heart1;
    [SerializeField] private GameObject heart2;
    [SerializeField] private GameObject heart3;

    [SerializeField] GameObject player;

    [SerializeField] GameObject deadMenu;
    [SerializeField] GameObject winMenu;
    public static bool isDead = false;

    void Update()
    {

        health = health;
        
        if (health == 1)
        {
            heart1.SetActive(true);
            heart2.SetActive(false);
            heart3.SetActive(false);
        }
        else if (health == 2)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(false);
        }
        else if (health == 3)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
        }
        else
        {
            heart1.SetActive(false);
            heart2.SetActive(false);
            heart3.SetActive(false);
        }

        if (health > maxHealth)
        {
            health = maxHealth;
        }

        if (health <= 0)
        {
            DeadMenu();

        }

    }

    public void TakeDamage()
    {
        health--;
        Debug.Log(health);
    }
    
    public void TakeHealth()
    {
        health++;
    }

    public void TakeBox()
    {
        box++;
        
    }

    public void DeadMenu()
    {
        deadMenu.SetActive(true);
        player.SetActive(false);
        
    }

    public void CheckWin()
    {
        if (box > 0)
        {
            winMenu.SetActive(true);
            player.SetActive(false);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
        deadMenu.SetActive(false);
    }
    
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
        deadMenu.SetActive(false);
        isDead = false;
    }

    public void QuitGame()
    {
        Application.Quit();
        deadMenu.SetActive(false);
    }
}
