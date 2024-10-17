using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Input.GetKey(KeyCode.AU)
            _direction = Vector2.up;
        }   else if (Input.GetKey(KeyCode.AD)
            _direction = Vector2.down;
        }   else {
                _direction = Vector2.zero;
        }

    // Update is called once per frame
    void Update()
    {
        
    }
}
