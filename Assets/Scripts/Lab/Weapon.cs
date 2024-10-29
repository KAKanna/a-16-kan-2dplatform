using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private int damage;
    public int Damage
    {
        get
        {
            return damage;
        }
        set
        {
            damage = value;
        }
    }
    protected string owner;

    public abstract void OnHitWith(Characters x);

    public abstract void Move();
    public void Init(int _damage,string _owner)
    {
        Damage = _damage;
        owner = _owner;
    }
    public int GetShootDirection()
    {
        return 1;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }
}
