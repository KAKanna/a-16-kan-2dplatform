using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Crocodile : Enemy, IShootable
{
    float attackRange;
    public float AttackRange { get {  return attackRange; } set {  attackRange = value; } }
    public Player player;
    [field: SerializeField]
    Transform spawnPoint;
    
    public Transform SpawnPoint {get { return spawnPoint; } set {  spawnPoint = value; } }

    [field: SerializeField]
    GameObject bullet;
    public GameObject Bullet {get { return bullet;} set { bullet = value; } }

    public float ReloadTime { get; set; }
    public float WaitTime { get; set; }
    
    public void Start()
    {
        Init(100);
        WaitTime = 0.0f;
        ReloadTime = 5.0f;
        DamageHit = 30;
        AttackRange = 6;
        player = GameObject.FindAnyObjectByType<Player>();

        
    }
    public void FixedUpdate()
    {
        WaitTime += Time.fixedDeltaTime;
        Behavior();
    }
    public override void Behavior()
    {
        Vector2 direction = player.transform.position - transform.position;
        float distance =  direction.magnitude;
        if (distance <= attackRange)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if (WaitTime >= ReloadTime)
        {
            GameObject obj = Instantiate(bullet, spawnPoint.position, Quaternion.identity);
            WaitTime = 0;
        }
    }
}
