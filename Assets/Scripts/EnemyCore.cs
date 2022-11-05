using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyCore : MonoBehaviour
{
    public GameObject shoot;
    private GameObject player;
    public GameObject shield;
    private float nextFireAllow;
    public float fireRate = 1f;
    private Array enemyCount;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
        Shield();

    }

    void Fire()
    {
        Vector3 targetPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.LookAt(targetPosition);
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
