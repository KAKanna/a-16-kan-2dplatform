using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crocodile : Enemy
{
    private float attackRange;
    private float player;

    public override void Behavior()
    {
        Debug.Log("This is Crocodile Behave");
    }
}
