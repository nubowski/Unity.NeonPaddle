using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI
{
    public abstract class UIControllerBase : MonoBehaviour
    {
        protected UIDocument UIDocument;

        private void Awake()
        {
            UIDocument = GetComponentInParent<UIDocument>();
            if (UIDocument == null)
            {
                Debug.LogError("UIDocument component is missing!");
            }
        }

        public abstract void InitializeUI();
    }
}