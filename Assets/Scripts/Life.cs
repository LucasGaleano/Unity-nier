using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public int points = 1;
    public bool inmortal;


    private void Update()
    {
        if (points <= 0)
        {
            if (gameObject.CompareTag("Player"))
            {
                gameObject.SetActive(false);
            }
            else
            {
                Destroy(gameObject);
            }
            
        }
    }

    public void recieveDamage(int amount)
    {
        if (!inmortal)
        {
            points -= amount;
        }
    }

    public bool isAlive()
    {
        return points < 0;
    }
}
