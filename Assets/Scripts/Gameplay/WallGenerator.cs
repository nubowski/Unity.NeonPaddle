using System;
using UnityEngine;

namespace Gameplay
{
    public class WallGenerator : MonoBehaviour
    {
        public GameObject wallPrefab;
        public float wallThickness = 1.0f;

        private void Start()
        {
            GenerateWall();
        }

        void GenerateWall()
        {
            // get screen bound
            Vector2 screenBounds =
                Camera.main.ScreenToWorldPoint((new Vector3(Screen.width, Screen.height,
                    Camera.main.transform.position.z)));
            
            // top
            GenerateWall(new Vector2(0, screenBounds.y), new Vector2(screenBounds.x * 2, wallThickness));
            
            // left
            GenerateWall(new Vector2(-screenBounds.x, 0), new Vector2(wallThickness, screenBounds.y * 2));
            
            // right
            GenerateWall(new Vector2(screenBounds.x, 0), new Vector2(wallThickness, screenBounds.y * 2));
        }

        void GenerateWall(Vector2 position, Vector2 size)
        {
            var wall = Instantiate(wallPrefab, position, Quaternion.identity);
            wall.transform.localScale = size;
        }
    }
}