using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cannon : MonoBehaviour
{
    [SerializeField] float turnSpeed = 4f;
    [SerializeField] float senseRange = 5f;
    [SerializeField] float cannonBallSpeed = 10f;
    [SerializeField] float shootInterval = 3f;
    [SerializeField] GameObject cannonBall;
    [SerializeField] Transform barrelPos;

    private Camera mainCamera;
    private float nextBallTime = 0f;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        float distToTarget = Vector3.Distance(transform.position, mainCamera.transform.position);
        if(distToTarget < senseRange)
        {
            FacePlayer();
            ShootPlayer();
        }        
    }

    private void FacePlayer()
    {
        Vector3 lookDirection = (mainCamera.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(lookDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, turnSpeed * Time.deltaTime);
    }

    private void ShootPlayer()
    {
        if(Time.time > nextBallTime)
        {
            //shoot player
            GameObject newBall = (GameObject)Instantiate(cannonBall);
            if (newBall != null)
            {
                newBall.transform.position = barrelPos.position;
                newBall.transform.rotation = barrelPos.rotation;
                Rigidbody rb = newBall.GetComponent<Rigidbody>();
                rb.angularVelocity = Vector3.zero;
                rb.velocity = barrelPos.forward * cannonBallSpeed;
            }
            nextBallTime = Time.time + shootInterval;
        }
        
    }
}
