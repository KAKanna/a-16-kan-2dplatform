using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : Weapon
{
    [SerializeField] float speed;

    private void Start()
    {
        speed = 4.0f * GetShootDirection();

        Damage = 30;
        Move();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public override void Move()
    {
        float newX = transform.position.x + speed * Time.fixedDeltaTime;
        float newY = transform.position.y;
        Vector2 newPosition = new Vector2(newX, newY);
        transform.position = newPosition;
    }

    public override void OnHitWith(Characters characters)
    {
        if (characters is Enemy)
        characters.TakeDamage(this.Damage);
        
    }
    
}
