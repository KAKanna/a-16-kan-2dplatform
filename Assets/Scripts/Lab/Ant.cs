using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ant : Enemy
{
    [SerializeField] private Vector2 velocity;
    [SerializeField] private Transform[] movePoints;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Init(20);
        DamageHit = 5;
        Behavior();
    }
    //moving not warp
    public void FixedUpdate()
    {
        Behavior();
    }
    //Here is speed s=v*t
    public override void Behavior()
    {
        //             point at now    speed          time(fixupdate)
        //                  ^            ^                  ^
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        if (rb.position.x <= movePoints[0].position.x && velocity.x < 0)
        {
            Flip();
        }
        else if (rb.position.x >= movePoints[1].position.x && velocity.x > 0)
        {
            Flip();
        }
    }

    public void Flip()
    {
        velocity.x *= -1;

        Vector3 charScale = transform.localScale;
        charScale.x *= -1;
        transform.localScale = charScale;
    }
}
