using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 500.0f;
    public float maxLifeTime = 10.0f;
    public float currentLifeTime = 0f;
    private Rigidbody2D _rigidbody;

    private void OnEnable()
    {
        currentLifeTime = 0;
    }
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        currentLifeTime += Time.deltaTime;
        if (currentLifeTime > maxLifeTime)
        {
            Dissappear();
        }
        
        _rigidbody.AddForce(this.transform.up * this.speed);
    }

    /*public void Project(Vector2 direction)
    {
        currentLifeTime += Time.deltaTime;
        if (currentLifeTime > maxLifeTime)
        {
            Dissappear();
        }
        
        _rigidbody.AddForce(direction * this.speed);
        
        //Destroy(this.gameObject, this.maxLifeTime)
    }*/

    private void OnCollisionEnter2D(Collision2D col)
    {
        //Destroy(this.gameObject);
        
        Dissappear();
    }

    public void Dissappear()
    {
        gameObject.SetActive(false);
    }
}
