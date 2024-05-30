using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TelegaRide : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float timeBefBack;
    public bool stop = false;
    enum dir
    {
        forward, backward
    }

    dir direct;
    void Start()
    {
        StartCoroutine(Ride());
    }

    void Update()
    {
        if (direct == dir.forward && !stop)
        {
            gameObject.transform.position += Vector3.forward * Time.deltaTime * speed;
        }
        if (direct == dir.backward)
        {
            gameObject.transform.position -= Vector3.forward * Time.deltaTime * speed;
        }
    }

    IEnumerator Ride()
    {
        direct = dir.forward;
        yield return new WaitForSeconds(timeBefBack);
        direct = dir.backward;
    }
}
