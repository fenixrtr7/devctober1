﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    float timeToSpawn, angulo = 0; 
    public float minRandom = 1.8f, maxRandom = 5;
    public GameObject carPrefab;

    public bool carFall = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InvokeCar());
    }

    IEnumerator InvokeCar()
    {
        timeToSpawn = Random.Range(minRandom, maxRandom);
        yield return new WaitForSeconds(timeToSpawn);

        if (carFall)
        {
            angulo = 180;
        }
        GameObject car = Instantiate(carPrefab,this.transform.position, Quaternion.Euler(0,0,angulo));
        if (!carFall)
        {
            car.GetComponent<CarEnemy>().speed *= -1;
        }
        StartCoroutine(InvokeCar());
    }
}
