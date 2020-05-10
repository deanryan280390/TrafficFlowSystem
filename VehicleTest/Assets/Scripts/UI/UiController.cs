using System;
using UnityEngine;

namespace UI
{
    public class UiController : MonoBehaviour
    {
        private GameObject _uiController;

        protected void Awake()
        {
            // create the UI Controller object so the UI Manager can be referenced in the scene
            _uiController = Instantiate(Resources.Load(  Globals.ResourcesPaths.UiControllerPrefab)) as GameObject;
            if (_uiController != null)
            {
                _uiController.AddComponent<UiManager>();
                _uiController.name = Globals.Components.UiController;
            }
        }
    }
}