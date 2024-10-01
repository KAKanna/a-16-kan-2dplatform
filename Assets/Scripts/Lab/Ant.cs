using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant : Enemy
{
    [SerializeField] private Vector2 velocity;
    [SerializeField] private Transform[] movepoints;

    public void Start()
    {
        Init(10);
        Debug.Log($"Health Ant {Health}");

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
        if (rb.position.x <= movepoints[0].position.x && velocity.x < 0)
        {
            Flip();
        }
        else if (rb.position.x >= movepoints[1].position.x && velocity.x > 0)
        {
            Flip();
        }
    }
    public void Flip()
    {
        velocity *= -1;

        Vector2 charScale = transform.localScale;
        charScale.x *= -1;
        transform.localScale = charScale;
    }
}
