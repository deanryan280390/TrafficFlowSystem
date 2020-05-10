using Controllers.Camera;
using SceneController;
using TrafficSystem;
using UI;
using UnityEngine;

namespace System
{
    public class Master : MonoBehaviour
    {
        #region Fields
        private GameObject _scriptManagerGameObject;
        #endregion

        #region Fields - Unity
    
        [SerializeField]
        public float PoolAmount = 20; // this is so object pool amount can be changed in editor , great for tests or design team can change freely

        [SerializeField]
        public bool IsExpanding = true;
    
        #endregion

        #region Methods

        private void Awake()
        {
            // this is one focal point that intialised all the script that are need to run the game
            _scriptManagerGameObject = GameObject.Find(Globals.Components.ScriptManager);
            DontDestroyOnLoad(this);
            _scriptManagerGameObject.AddComponent<UiController>();
            _scriptManagerGameObject.AddComponent<RoadCreator>();
            _scriptManagerGameObject.AddComponent<Scene>();
            Camera.main.gameObject.AddComponent<CameraController>();    
            _scriptManagerGameObject.AddComponent<ObjectPooling>();
            _scriptManagerGameObject.AddComponent<TrafficControl>();
            Destroy(_scriptManagerGameObject.GetComponent<UiController>());
        }
    
        #endregion
    }
}