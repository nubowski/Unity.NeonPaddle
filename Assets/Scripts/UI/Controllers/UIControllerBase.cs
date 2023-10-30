using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI
{
    public abstract class UIControllerBase : MonoBehaviour
    {
        protected UIDocument _uiDocument;

        private void Awake()
        {
            _uiDocument = GetComponent<UIDocument>();
            if (_uiDocument == null)
            {
                Debug.LogError("UIDocument component is missing!");
            }
        }

        public abstract void InitializeUI();
    }
}