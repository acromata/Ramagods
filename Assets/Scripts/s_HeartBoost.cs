using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_HeartBoost : MonoBehaviour
{
    public int amountToBoost;
    private s_PlayerHealth s_H;


    void Awake()
    {
        s_H = GetComponent<s_PlayerHealth>();
    }

    public void gainHearts()
    {
        if(s_H.fullHealth == true)
        {
            s_H.numOfHearts = s_H.numOfHearts + amountToBoost;
            s_H.health = s_H.health + s_H.numOfHearts;
        }
        else
        {
            s_H.health = s_H.health + s_H.numOfHearts;
            s_H.numOfHearts = s_H.numOfHearts + amountToBoost;
        }
        Debug.Log("Hearts Gained");
        Destroy(gameObject);
    }


}
