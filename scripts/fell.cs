using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fell : MonoBehaviour
{
    
    public Transform target; // The player object
    public Transform Manager; // The Manager object
    private bool Fell = false;
    
    private void Start()
    {
        //target = GameObject.FindGameObjectWithTag("Player").transform; // Find the player object by tag
    }

    private void Update()
    {
        if (target != null)
        {
            // Calculate the distance between the bat and the player
            float distanceToPlayer = Vector2.Distance(transform.position, target.position);

            // Damage the player if the bat is close enough and hasn't attacked in the current attack cycle
            if (Fell)
            {
                DamagePlayer();
                DamagePlayer();
                DamagePlayer();
                DamagePlayer();
                DamagePlayer();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == target.gameObject)
        {
            Fell = true;
        }
    }


    private void DamagePlayer()
    {
        Manager.GetComponent<LifeSystem>().LoseLife(); // Damage the player     
        Invoke("Inactive", 0);
    }
    
    private void Inactive()
    {
        gameObject.SetActive(false);
    }
}