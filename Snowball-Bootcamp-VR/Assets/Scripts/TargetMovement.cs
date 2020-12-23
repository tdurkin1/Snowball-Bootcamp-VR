using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    Vector3 sinePos;
    float time;
    public float targetSpeed = 0.5f;
    public float movementAmplitude = .025f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        sinePos.z = Mathf.Sin(time * targetSpeed) * movementAmplitude;
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + sinePos.z); ;


    }
}
