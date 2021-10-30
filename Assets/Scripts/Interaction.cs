using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.name == "Interaction")
        {
            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                Debug.Log("Interaction");
            }
        }

    }
}
