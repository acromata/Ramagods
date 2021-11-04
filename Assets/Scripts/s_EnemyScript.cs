using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_EnemyScript : MonoBehaviour
{
    public int health;
    [SerializeField] private float speed;
    private bool movingRight = true;
    public Transform groundDetection;




    void Update()
    {



        // Movement
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 5f, LayerMask.GetMask("Ground"));
        if(groundInfo.collider == false)
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }





        {
            // Health
            if(health <= 0)
            {
                Destroy(gameObject);
            }
        }

    }



    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Enemy - Damage taken");
        }
}
