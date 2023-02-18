using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{
    //public int startingLives = 1;
    public int health;
    public int currentLives;
    public bool lost = false;

    public Image[] lifeImages;
    public Sprite fullLife;
    public Sprite emptyLife;
    [SerializeField]private AudioSource healSound;
    [SerializeField]private AudioSource hurtSound;

    private void Start()
    {

    }

    public void LoseLife()
    {
        hurtSound.Play();
        health--;
        //UpdateLivesUI();

        if (health <= 0)
        {
            lost = true;
            // Player has lost all their lives, trigger game over logic
        }
    }
    public void GainLife()
    {
        healSound.Play();
        health++;
        //UpdateLivesUI();
        
    }

    private void Update() {
        UpdateLivesUI(); 
    }
    private void UpdateLivesUI()
    {
        if(health > currentLives)
        {
            health = currentLives;
        }

        for (int i = 0; i < lifeImages.Length; i++)
        {
            if (i < health)
            {
                lifeImages[i].sprite = fullLife;
            }
            else
            {
                lifeImages[i].sprite = emptyLife;
            }

            if (i < currentLives)
            {
                lifeImages[i].enabled = true;
            }
            else
            {
                lifeImages[i].enabled = false;
            }
        }
    }
}
