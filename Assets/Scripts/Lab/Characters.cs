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

    public HealthManager healthbar;
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

    public void InitializeHealthBar(int maxHealth)
    {
        healthbar.SetMaxHealth(maxHealth);
        healthbar.UpdateHealthBar(maxHealth);
    }
    public void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log($"{this.name} took {this.Health}");
        IsDead();
    }
    public void Init(int health)
    {
        Health = health;
    }
}
