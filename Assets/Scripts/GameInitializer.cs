using System;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
        [SerializeField] private GameObject uiLoaderPrefab;

        private void Start()
        {
                InitializeSystems();
                InitializeUI();
        }

        private void InitializeSystems()
        {
                // for future stuff for ini/upload/bundle/whatever
        }

        private void InitializeUI()
        {
             // simple UI starter
             Instantiate(uiLoaderPrefab);
        }
}