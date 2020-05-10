using System;
using UnityEngine;

namespace Controllers.Camera
{
    public class CameraController : MonoBehaviour
    {
        #region Fields

        private GameObject _player;
        private Vector3 _offset;

        #endregion

        #region Methods - Unity

        private void Awake()
        {
            _player = GameObject.Find(Globals.SceneGameObjects.Player);
        }

        private void Start()
        {
            _offset = transform.position - _player.transform.position;
        }

        private void LateUpdate()
        {
            transform.position = _player.transform.position + _offset;
        }

        #endregion
        
    }

}