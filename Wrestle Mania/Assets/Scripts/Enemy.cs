using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    private Rigidbody rb;
    private GameObject player;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }
    private void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        //here i used normalized to normalize the magnitude otherwise it will increase with distance
        rb.AddForce(lookDirection * speed);

        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }


    }
}
