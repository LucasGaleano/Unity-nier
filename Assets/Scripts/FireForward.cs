using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireForward : MonoBehaviour
{

    public GameObject shoot;
    private float nextFireAllow;
    public float fireRate = 1f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (Time.time > nextFireAllow)
        {
            nextFireAllow = Time.time + fireRate;
            Instantiate(shoot, transform.position, transform.rotation);
        }
    }
}
