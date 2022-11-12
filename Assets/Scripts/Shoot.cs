using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public List<string> avoidCollapseObjects = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (avoidCollapseObjects.All(item => !other.CompareTag(item)))
        {
            //Debug.Log("Collision: " + other.tag + " name:" + other.name + " With: " + tag + " name: " + name);
            Destroy(gameObject);
            Life otherLife = other.gameObject.GetComponent<Life>();
            if(otherLife != null)
            {
                otherLife.recieveDamage(1);
            }

        }
    }
}
