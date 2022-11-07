using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class MoveAtPlayer : MonoBehaviour
{
    private GameObject player;
    public float speed = 1f;
    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        characterController = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveTo = (player.transform.position - transform.position);
        moveTo.y = 0;
        //transform.Translate(moveTo * speed * Time.deltaTime, Space.World);
        characterController.Move(moveTo.normalized * speed * Time.deltaTime);
        transform.LookAt(new Vector3(player.transform.position.x,transform.position.y, player.transform.position.z),Vector3.up);

    }
}
