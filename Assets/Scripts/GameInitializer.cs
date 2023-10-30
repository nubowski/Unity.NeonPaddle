using System;
using UI;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private UILoader uiLoader; // Reference to UILoader component via inspector.

    private void Start()
    {
        InitializeSystems();
        InitializeUI();
    }

    private void InitializeSystems()
    {
        // Future systems initialization.
    }

    private void InitializeUI()
    {
        if(uiLoader != null)
        {
            uiLoader.LoadUI();
        }
        else
        {
            Debug.LogError("UILoader not assigned in the inspector.");
        }
    }
}