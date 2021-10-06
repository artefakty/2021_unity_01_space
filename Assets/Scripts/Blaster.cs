using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : MonoBehaviour
{
    public float Speed = 150;

    public float TimeToLive = 2;
    public float Damage = 10;

    public enum Shooter
    {
        Player,
        Opponent
    }

    public Shooter MyShooter;
    public GameObject HitEffect;

    private float timeToLiveLeft;

    private void Start()
    {
        timeToLiveLeft = TimeToLive;
    }

    private void Update()
    {
        this.transform.position += this.transform.forward * Speed * Time.deltaTime;

        timeToLiveLeft -= Time.deltaTime;

        if(timeToLiveLeft < 0)
            Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(MyShooter == Shooter.Player)
        {
            var shipEnemy = collision.gameObject.GetComponentInParent<ShipEnemy>();

            if (shipEnemy != null)
            {
                Instantiate(HitEffect, this.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
        if (MyShooter == Shooter.Opponent)
        {
            var shipPlayer = collision.gameObject.GetComponentInParent<ShipPlayer>();

            if (shipPlayer != null)
            {
                shipPlayer.DoDamage(Damage);

                Instantiate(HitEffect, this.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }
}
