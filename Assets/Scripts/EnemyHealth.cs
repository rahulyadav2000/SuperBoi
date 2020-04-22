using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float Health = 100f;
    public Animator ani;
    public GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            ani.SetBool("Death", true);
            Invoke("IsDeadCompleted", 0.500f);
            Destroy(Enemy.gameObject, 0.6f);
        }
    }
    void IsDeadCompleted()
    {
        ani.SetBool("Death", false);
    }
   
    public void TakeDamage(float damageAmount)
    {
        Health -= damageAmount;
    }
}
