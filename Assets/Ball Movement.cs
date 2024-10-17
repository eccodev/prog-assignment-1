using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class BallMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        AddStartingForce();
    }


    private void AddStartingForce()
    {
        float x = Random.value < 0.5f ? -1.0f : 1.0f;
        float y Random.value < 0.5f ? Random.Range(-1.0f, 0.5f) : 
            Random.Range(-1.0f, 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
