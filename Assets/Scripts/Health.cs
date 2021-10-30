using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHearts;
    public Sprite emptyHearts;
    private bool fullHealth;
    


    void Update()
    {
        
        // Checks if the health is full
        if(health > numOfHearts)
        {
            health = numOfHearts;
        }

        if(health == numOfHearts)
        {
            fullHealth = true;
        }
        else
        {
            fullHealth = false;
        }


        for (int i = 0; i < hearts.Length; i++)
        {
            
            if( i < health )
            {
                hearts[i].sprite = fullHearts;
            }
            else
            {
                hearts[i].sprite = emptyHearts;
            }


            if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        if(health <= 0)
        {
            die();
        }

    }
        
    // Healing
    void OnTriggerStay2D(Collider2D col)
    {
        // Health
        if(col.gameObject.name == "Heal")
        {
            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                heal();
            }
        }
        
        // Heart Boost
        if(col.gameObject.name == "HeartBoost")
        {
            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                numOfHearts = numOfHearts + 1;
                Debug.Log("Gained Hearts");
            }
        }
    }

    // Trap damage
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Trap")
        {
            health = health - 3;
            Debug.Log("Trap");
        }
    }




    void heal()
    {
        health = health + 1;
        Debug.Log("Healed");
    }

    void gainHearts()
    {
        if(fullHealth == true)
        {
            numOfHearts = numOfHearts + 1;
            health = health + numOfHearts;
        }
        else
        {
            health = health + numOfHearts;
            numOfHearts = numOfHearts + 1;
        }
        Debug.Log("Hearts Gained");
    }

    void die()
    {
        Destroy(gameObject, 0.2f);
    }
}

