using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : Weapon
{
    [SerializeField] float speed;

    public override void OnHitWith(Characters x)
    {

    }
    public override void Move()
    {
        Debug.Log("Banana");
    }

    private void Start()
    {
        Move();
        speed = 4;
        Damage = 30;
    }
}
