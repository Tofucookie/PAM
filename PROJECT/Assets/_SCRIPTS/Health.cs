using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float health;

    [SerializeField]
    string strTag;


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
    }

    // SUBTRACT FROM HEALTH 
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == strTag)
        {
            Debug.Log(health);
            float v = health--;
        }
    }

    // DEATH SCREEN
    void Death()
    {
        Destroy(this.gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}