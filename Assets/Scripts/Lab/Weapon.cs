using System.Collections;
using System.Collections.Generic;
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        OnHitWith(other.GetComponent<Characters>());

        Destroy(this.gameObject, 2f);
    }
    public int GetShootDirection()
    {
        float v = shooter.SpawnPoint.position.x - shooter.SpawnPoint.parent.position.x;
        float shootDir = v;
        if (shootDir > 0)
            return 1;
        else return -1;
    }
}
