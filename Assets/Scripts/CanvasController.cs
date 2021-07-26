using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    class CanvasController : MonoBehaviour
    {
        public static CanvasController Instance;
        void Awake()
        {
            if (Instance == null)
            Instance = this;
            gameObject.SetActive(false);
        }
    }

