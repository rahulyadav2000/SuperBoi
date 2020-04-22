using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public Animator ani;
    public bool isFacingRight;
    public Transform player;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            ani.SetBool("Attacking", true);
            if (player.position.x > transform.position.x)
            {

                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (player.position.x < transform.position.x)
            {

                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }

}
