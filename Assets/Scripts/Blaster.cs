using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : MonoBehaviour
{
    public float Speed = 150;

    public float TimeToLive = 2;

    private float timeToLiveLeft;

    void Start()
    {
        timeToLiveLeft = TimeToLive;
    }

    void Update()
    {
        this.transform.position += this.transform.forward * Speed * Time.deltaTime;

        timeToLiveLeft -= Time.deltaTime;

        if(timeToLiveLeft < 0)
            Destroy(this.gameObject);
    }
}
