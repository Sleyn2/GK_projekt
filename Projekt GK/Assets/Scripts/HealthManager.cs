using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    private int change;

    public Image[] hearts;

    public PlayerController thePlayer;

    public float invincibilityLength;
    private float invincibilityCounter;

    public Renderer playerRenderer;
    private float flashCounter;
    public float flashLength = 0.1f;

    private bool isRespawning;
    private Vector3 respawnPoint;


    public CharacterController charController;

    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        change = maxHealth;
        //thePlayer = FindObjectOfType<PlayerController>();

        respawnPoint = thePlayer.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(invincibilityCounter>0)
        {
            invincibilityCounter -= Time.deltaTime;

            flashCounter -= Time.deltaTime;
            if (flashCounter <= 0)
            {
                playerRenderer.enabled = !playerRenderer.enabled;
                flashCounter = flashLength;
            }

            if(invincibilityCounter <=0)
            {
                playerRenderer.enabled = true;
            }
        }
        for (int i = 0; i < change; i++)
            if (currentHealth < i + 1)
            {
                Destroy(hearts[i].gameObject);
                change--;
            }
    }

    public void HurtPlayer(int damage, Vector3 direction)
    {
        if (invincibilityCounter<=0)
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                Respawn();
            }
            else
            {
                thePlayer.Knockback(direction);

                invincibilityCounter = invincibilityLength;

                playerRenderer.enabled = false;

                flashCounter = flashLength;
            }
        }     
    }

    public void Respawn()
    {
        charController.enabled = false;
        thePlayer.transform.position = respawnPoint;
        currentHealth = maxHealth;
        charController.enabled = true;
    }

    public void HealPlayer(int healAmount)
    {
        currentHealth += healAmount;
        if(currentHealth>maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
