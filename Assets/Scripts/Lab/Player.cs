using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Characters, IShootable
{
    [field: SerializeField]
    GameObject bullet;
    public GameObject Bullet { get { return bullet; } set { bullet = value; } }
    [field: SerializeField]
    Transform spawnPoint;
    public Transform SpawnPoint { get { return spawnPoint; } set { spawnPoint = value; } }

    public float ReloadTime { get; set; }
    public float WaitTime { get; set; }

    public void Shoot()
    {   
        if (Input.GetButtonDown("Fire1") && WaitTime >= ReloadTime)
        {
            GameObject obj = Instantiate(bullet, SpawnPoint.position, Quaternion.identity);
            Banana banana = obj.GetComponent<Banana>();
            banana.Init(5,this);
            WaitTime = 0;
        }
    }
   

    public void Start()
    {
        InitHealthBar(100);
        Init(100);
        WaitTime = 0.0f;
        ReloadTime = 1.0f;
    }
    void Update()
    {
        Shoot();
    }
    public void FixedUpdate()
    {
        WaitTime += Time.fixedDeltaTime;
    }

    public void OnHitWith(Enemy enemy)
    {
        TakeDamage(enemy.DamageHit);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            OnHitWith(enemy);
        }
    }

}
