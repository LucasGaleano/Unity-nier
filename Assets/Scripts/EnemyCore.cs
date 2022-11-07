using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyCore : MonoBehaviour
{
    public GameObject shoot;
    public GameObject shield;
    private float nextFireAllow;
    public float fireRate = 1f;
    private Array enemyCount;
    

    // Start is called before the first frame update
    void Start()
    {   
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
        Shield();

    }

    void Fire()
    {
        if (Time.time > nextFireAllow)
        {
            nextFireAllow = Time.time + fireRate;
            Instantiate(shoot, transform.position, transform.rotation);
        }
    }

    void Shield()
    {
        enemyCount =  GameObject.FindGameObjectsWithTag("Enemy");
        if (enemyCount.Length == 1)
        {        
            shield.SetActive(false);
            fireRate = 0.1f;
        }
    }
}
