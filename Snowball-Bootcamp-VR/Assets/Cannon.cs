using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] float turnSpeed = 4f;
    [SerializeField] float senseRange = 5f;

    private Camera mainCamera;
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        float distToTarget = Vector3.Distance(transform.position, mainCamera.transform.position);
        if(distToTarget < senseRange)
        {
            FacePlayer();
        }
        
    }

    private void FacePlayer()
    {
        Vector3 lookDirection = (mainCamera.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(lookDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, turnSpeed * Time.deltaTime);
    }
}
