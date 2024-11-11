using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public abstract class Characters : MonoBehaviour
{
    [SerializeField] private int health;
    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
        }
    }

    public HealthBar healthBar;
    public int maxHealth;
    public int currentHealth;
    public Animator anim; 
    public Rigidbody2D rb;

    public bool IsDead()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
            return true;
        }
        else return false;
    }
    public void InitHealthBar(int initialHealth)
    {
        maxHealth = initialHealth;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        //healthBar.UpdatsHealthBar(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        Health -= damage;
        Debug.Log($"{this.name} took {this.Health}");
        IsDead();
    }
    public void Init(int newHealth)
    {
        Health = newHealth;
        newHealth = maxHealth;
    }
}
