using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] int damage;
    public int Damage
    {
        get{return damage;}
        set{damage = value;}
    }
    public IShootable shooter;

    public abstract void OnHitWith(Characters characters);

    public abstract void Move();
    public void Init(int newDamage,IShootable newOwner)
    {
        Damage = newDamage;
        shooter = newOwner;
    }

    public int GetShootDirection()
    {
        float shootDir = shooter.SpawnPoint.position.x - shooter.SpawnPoint.parent.position.x;
        if (shootDir > 0)
        { return 1; }
        else
        {
            return -1;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        OnHitWith(other.GetComponent<Characters>());

        Destroy(this.gameObject, 2f);
    }
  
}
