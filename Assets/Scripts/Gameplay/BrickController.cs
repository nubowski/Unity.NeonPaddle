using System;
using System.Security.Cryptography;
using UnityEngine;

namespace Gameplay
{
    public class BrickController : MonoBehaviour
    {
        public int hitPoints = 1;
        public Sprite[] hitSprites; // to show dmg 

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ball"))
            {
                TakeDamage();
            }
        }

        private void TakeDamage()
        {
            hitPoints--;

            if (hitPoints <= 0)
            {
                Destroy(gameObject); // BRUTEFORCE DESTROY!!!
            } else if (hitSprites.Length > 0)
            {
                GetComponent<SpriteRenderer>().sprite = hitSprites[hitPoints - 1]; // try to upd sprite to show the dmg
            }
        }
    }
}