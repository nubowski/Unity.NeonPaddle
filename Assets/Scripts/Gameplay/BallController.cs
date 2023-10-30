using System;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace Gameplay
{
    public class BallController : MonoBehaviour
    {
        public float speed = 15.0f;
        private Rigidbody2D _rb;
        private Vector2 _ballDirection;
        private bool _gameStared = false;

        private void Start()
        {
            // take the RB for something later on
            _rb = GetComponent<Rigidbody2D>();

            // ball init somehow
            _ballDirection = Vector2.up;
        }

        private void Update()
        {
            // check for launch
            if (!_gameStared && Input.GetKeyDown(KeyCode.Space))
            {
                _gameStared = true;
                _rb.velocity = _ballDirection * speed;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // bounce here?
            // collision to reverse the direction tho

            /*_ballDirection = Vector2.Reflect(_rb.velocity.normalized, collision.contacts[0].normal);
            _rb.velocity = _ballDirection * speed;*/

            if (!collision.gameObject.CompareTag("Paddle")) return;

            // hit factor
            float x = hitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.x);

            // calc the direction
            var dir = new Vector2(x, 1).normalized;

            // velocity
            _rb.velocity = dir * speed;
        }

        private float hitFactor(Vector2 ballPos, Vector2 paddlePos, float paddleWidth)
        {
            // так. 
            // 1 -0.5 0 0.5 1         <- x value
            // ==============         <- paddle  
            // guess так

            return (ballPos.x - paddlePos.x) / paddleWidth;
        }
    }
}