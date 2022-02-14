using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float health;

    [SerializeField]
    string strTag;
    public float strength;
    public float defense;



    void Update()
    {
        PlayerHealth();
    }

    void PlayerHealth()
    {
        if (health <= 0)
        {
            Death();
        }
        else if (health > 9999)
        {
            Debug.Log($"The user died of a heart attack. Health: {health}");
            Death();
        }
    }

    // SUBTRACT FROM HEALTH 
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == strTag)
        {
            // Check to see if enemy has attack strength
            Debug.Log($"Got hit! Previous player health: {health}");
            try
            {
                float damage = 1; // damage to be replaced with enemy's strength
                health = health - (damage - defense);
            }
            // If calculation invalid, subtract 1 from health; fallback damage
            catch (System.Exception e)
            {
                Debug.Log($"FUCK: {e}");
                health--;
            }
            Debug.Log($"Got hit! Current player health: {health}");


        }
    }

    // DEATH SCREEN
    void Death()
    {
        Destroy(this.gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}