using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public float speed = 500.0f;
    public float maxLifeTime = 10.0f;
    public float currentLifeTime = 0f;
    public int poolAmount = 10;
    public GameObject bulletPrefab;

    public GameObject[] bullets;

    private void Awake()
    {

        bullets = new GameObject[poolAmount];
        for (int i = 0; i < poolAmount; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);
            //bullet.GetComponent<Bullet>().maxLifeTime = 10.0f;
            //bullet.GetComponent<Bullet>().Project(this.transform.up);

            bullets[i] = bullet;
        }
    }
    
    /*private void Project(Vector2 direction)
    {
        currentLifeTime += Time.deltaTime;
        if (currentLifeTime > maxLifeTime)
        {
            GetComponent<Bullet>().Dissappear();
        }
        
        _rigidbody.AddForce(direction * this.speed);
        
        //Destroy(this.gameObject, this.maxLifeTime)
    }*/

    public GameObject SpawnBullet()
    {
        for (int i = 0; i < bullets.Length; i++)
        {
            if (bullets[i].activeInHierarchy)
            {
                bullets[i].SetActive(true);
                return bullets[i].gameObject;
            }
        }

        return null;
    }


    /*public GameObject objectToPool;
    public List<GameObject> thePool = new List<GameObject>();
    public int startAmount;

    private void Start()
    {
        for (int i = 0; i < startAmount; i++)
        {
            thePool.Add(Instantiate(this.objectToPool));
            thePool[i].SetActive(false);
            thePool[i].transform.parent = transform;
        }
    }

    public GameObject SpawnObject(Vector3 position, Quaternion rotation)
    {
        GameObject toReturn;

        toReturn = thePool[0];
        thePool.RemoveAt(0);
        
        toReturn.SetActive(true);
        toReturn.transform.position = position;
        toReturn.transform.rotation = rotation;

        return toReturn;
    }*/
}
