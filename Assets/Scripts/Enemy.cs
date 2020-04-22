using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator ani;
    //public bool Attack;
    public float dis;
    public CharacterController player;
   // public GameObject grdPoint;
    public bool isPatrol;
    private Patrol patrol;
    // Start is called before the first frame update
    void Start()
    {
        patrol = GetComponent<Patrol>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
       
            if(collision.gameObject.CompareTag("Player"))
            {
                
                patrol.enabled = false;
                ani.SetBool("Attack", true);
            }
       
    }

    // Update is called once per frame
    void Update()
    {
        dis = Vector2.Distance(player.transform.position, gameObject.transform.position);
        
        
            if (dis > 2)
            {
                ani.SetBool("Attack", false);
                patrol.enabled = true;
                // grdPoint.SetActive(true);

            }

            else
            {
                ani.SetBool("Attack", true);
                patrol.enabled = false;
                // grdPoint.SetActive(false);
            }
        
        
    }
    
}
