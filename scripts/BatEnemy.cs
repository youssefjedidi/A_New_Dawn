using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatEnemy : MonoBehaviour
{
    public float attackRange = 2f; // The range at which the bat can attack the player
    public float attackSpeed = 5f; // The speed at which the bat moves when attacking
    public float attackCooldown = 2f; // The time in seconds between attacks
    public float damageDistance = 1; // The damage the bat does to the player when attacking

    public Transform target; // The player object
    public Transform Manager; // The Manager object
    private bool canAttack = true; // Whether the bat can currently attack or not
    private bool hasAttacked = false; // Whether the bat has already attacked the player in the current attack cycle
    private bool FacingRight = false;

    [SerializeField]private AudioSource zitSound;

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

            // If the player is within attack range and the bat can attack, then attack the player
            if (distanceToPlayer <= attackRange && canAttack)
            {
                AttackPlayer();
            }
            else if (distanceToPlayer > attackRange && !canAttack)
            {
                // Stop moving the bat if the player moves out of attack range during an attack cycle
                //GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                AttackPlayer();
            }

            // Damage the player if the bat is close enough and hasn't attacked in the current attack cycle
            if (distanceToPlayer <= damageDistance && !hasAttacked)
            {
                DamagePlayer();
                hasAttacked = true;
            }
        }
    }

    private void AttackPlayer()
    {
        canAttack = false; // Set canAttack to false so the bat can't attack again until the cooldown is over
        hasAttacked = false; // Reset the hasAttacked flag

        // Move the bat towards the player
        Vector2 direction = (target.position - transform.position).normalized;
        GetComponent<Rigidbody2D>().velocity = direction * attackSpeed;

        // Call the method to reset the canAttack variable after the cooldown period
        Invoke("ResetAttack", attackCooldown);
        if (direction.x > 0f)
        {
            if (!FacingRight)
            Flip();
        }
                else if (direction.x < 0f)
        {
            if (FacingRight)
            Flip();
        }
        //Debug.Log(direction);
    }

        private void Flip()
    {
        // Switch the way the player is labelled as facing.
        FacingRight = !FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void DamagePlayer()
    {
        if(target.GetComponent<PlayerController>().Protected)
        {
            zitSound.Play();
            Invoke("Inactive", 0.3f);
        }
        else
        {Manager.GetComponent<LifeSystem>().LoseLife();} // Damage the player
    }
    
    private void Inactive()
    {
        gameObject.SetActive(false);
        //Destroy(gameObject, 2.0f);
    }

    private void ResetAttack()
    {
        canAttack = true; // Set canAttack to true so the bat can attack again
    }
}
