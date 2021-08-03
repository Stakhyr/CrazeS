using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaking : MonoBehaviour
{
  

    private Vector3 initialPosition;
    Vector3 directionOfShake = Vector3.forward;
    public float amplitude; // the amount it moves
    public float frequency; // the period of the earthquake

    void Start()
    {
        initialPosition = transform.position; // store this to avoid floating point error drift
    }



    void FixedUpdate()
    {
        transform.position = initialPosition + directionOfShake * Mathf.Sin(frequency * Time.deltaTime) * amplitude;
    }
}
