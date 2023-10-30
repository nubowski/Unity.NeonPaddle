using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    private bool _canMoveLeft = true;
    private bool _canMoveRight = true;
    
    public float speed = 30.0f;
    public float boundary = 20.0f;
    
    void Start()
    {
               
    }

    // Update is called once per frame
    void Update()
    {
        MovePaddle();
    }

    private void MovePaddle()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
    
        if (!_canMoveRight && x > 0) 
        {
            x = 0;
        }
        else if (!_canMoveLeft && x < 0) 
        {
            x = 0;
        }
    
        // positioning
        var newPosition = transform.position + Vector3.right * x;

        // do we need bounds at all??
        newPosition.x = Mathf.Clamp(newPosition.x, -boundary, boundary);

        transform.position = newPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Entered collision with: " + collision.gameObject.name);
        
        if (!collision.gameObject.CompareTag("Walls")) return;

        if (transform.position.x < collision.transform.position.x)
        {
            _canMoveRight = false;
        }
        else
        {
            _canMoveLeft = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) // Use OnCollisionExit2D
    {
        if (collision.gameObject.CompareTag("Walls"))
        {
            _canMoveLeft = true;
            _canMoveRight = true;
        }
    }
}
