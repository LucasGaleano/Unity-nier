using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveAtPlayer : MonoBehaviour
{
    private GameObject player;
    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveTo = (player.transform.position - transform.position).normalized;
        moveTo.y = 0;
        transform.Translate(moveTo * speed * Time.deltaTime, Space.World);
    }
}
