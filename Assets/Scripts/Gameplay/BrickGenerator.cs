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
            var startPosition = new Vector2(-columns * 0.5f + 0.5f, rows * 0.5f - 0.5f);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (Random.Range(0f, 1f) > 0.5f) // brute forced 50% chance of generation
                    {
                        var localScale = brickPrefab.transform.localScale;
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