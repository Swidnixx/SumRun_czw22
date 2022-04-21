using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 100;

    void Start()
    {
        rotationSpeed = Random.Range(0.75f * rotationSpeed, 1.25f * rotationSpeed);
    }

    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
