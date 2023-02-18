﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseLife : MonoBehaviour
{
    public float damageDistance = 1f; // The damage the bat does to the player when attacking

    public Transform target; // The player object
    public Transform canvas; // The canvas object


    private void Start()
    {
        //target = GameObject.FindGameObjectWithTag("Player").transform; // Find the player object by tag
    }

    private void Update()
    {
        if (target != null && target.gameObject.activeInHierarchy)
        {
            // Calculate the distance between the bat and the player
            float distanceToPlayer = Vector2.Distance(transform.position, target.position);

            // Damage the player if the bat is close enough and hasn't attacked in the current attack cycle
            if (distanceToPlayer <= damageDistance  )
            {
                DamagePlayer();  
            }
        }

    }


    private void DamagePlayer()
    {
        canvas.GetComponent<LifeSystem>().LoseLife(); // Damage the player
        Invoke("Inactive", 0);
    }
    
    private void Inactive()
    {
        gameObject.SetActive(false);
    }
}
