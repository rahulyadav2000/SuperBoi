using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Image healthBar;
    private PlayerHealth playerhealth;
    // Start is called before the first frame update
    void Start()
    {
        playerhealth = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = playerhealth.Health / 100;

    }


    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        var food = collision.gameObject.GetComponent<Food>();
        if(food)
        {
            playerhealth.IncreaseHealth(food.health);

            Destroy(collision.gameObject);
        }
    }*/

    /*public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        var food = hit.gameObject.GetComponent<Food>();
        if (food)
        {
            playerhealth.IncreaseHealth(food.health);

            Destroy(hit.gameObject);
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var food = collision.gameObject.GetComponent<Food>();
        if (food)
        {
            playerhealth.IncreaseHealth(food.health);

            Destroy(collision.gameObject);
        }
    }
}
