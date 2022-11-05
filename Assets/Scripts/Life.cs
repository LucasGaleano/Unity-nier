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
            Destroy(gameObject);
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
