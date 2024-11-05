using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Weapon
{
    public Rigidbody2D rb2d;
    [SerializeField] public Vector2 force;

    private void Start()
    {
        Init(20, this.shooter);
        force = new Vector2(GetShootDirection() *100, 400);
        Move();
    }
 
    public override void Move()
    {
        rb2d.AddForce(force, ForceMode2D.Impulse);
    }

    public override void OnHitWith(Characters characters)
    {
        if (characters is Player)
            characters.TakeDamage(this.Damage);
    }
}
