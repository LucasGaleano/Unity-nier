using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinder : MonoBehaviour
{
    public GameObject shoot;
    private float nextFireAllow;
    public float fireRate = 1f;
    private int degreeShoot = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFireAllow)
        {
            nextFireAllow = Time.time + fireRate;
            Instantiate(shoot, transform.position, Quaternion.Euler(0, degreeShoot, 0));
            Instantiate(shoot, transform.position, Quaternion.Euler(0, degreeShoot + 90, 0));
            Instantiate(shoot, transform.position, Quaternion.Euler(0, degreeShoot + 180, 0));
            Instantiate(shoot, transform.position, Quaternion.Euler(0, degreeShoot + 270, 0));
            degreeShoot += 15;
        }
    }
}
