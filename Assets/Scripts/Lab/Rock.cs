using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Weapon
{
    public Rigidbody2D rb2d;
    [SerializeField] public Vector2 force;

    public override void OnHitWith(Characters x)
    {
        
    }
    public override void Move()
    {
        Debug.Log("ROCK");
    }

    private void Start()
    {
        Move();
        Damage = 40;
    }
}
