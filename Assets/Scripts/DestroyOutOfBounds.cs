using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float bounds = 30;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (System.Math.Abs(transform.position.z) > bounds || System.Math.Abs(transform.position.x) > bounds)
        {
            Destroy(gameObject);
        }

    }
}
