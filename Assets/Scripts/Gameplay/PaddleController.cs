using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
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
        
        // positioning

        var newPosition = transform.position + Vector3.right * x;

        newPosition.x = Mathf.Clamp(newPosition.x, -boundary, boundary);

        transform.position = newPosition;
    }
}
