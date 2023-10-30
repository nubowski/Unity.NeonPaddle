using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay
{
    public class BrickGenerator : MonoBehaviour
    {
        public GameObject brickPrefab;
        public int rows = 5;
        public int columns = 8;
        public float padding = 0.5f; // space between

        private void Start()
        {
            GenerateBricks();
        }

        private void GenerateBricks()
        {
            var localScale = brickPrefab.transform.localScale;
            
            var totalBrickWidth = (localScale.x + padding) * columns - padding;
            var totalBrickHeight = (localScale.y + padding) * rows - padding;
            var startPosition = new Vector2(-totalBrickWidth * 0.5f, totalBrickHeight * 0.5f);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (Random.Range(0f, 1f) > 0.5f) // brute forced 50% chance of generation
                    {
                        var position = new Vector2(
                            startPosition.x + j * (localScale.x + padding),
                            startPosition.y - i * (localScale.y + padding));

                        Instantiate(brickPrefab, position, Quaternion.identity, transform);
                    }
                }
            }
        }
    }
}