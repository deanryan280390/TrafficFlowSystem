using System;
using CarSystem;
using SceneController;
using UI;
using UnityEngine;

namespace Player
{
    public class Player : Car
    {
        #region Fields - Declared

        private float _playerSpeed = 0;
        private float _constantSpeed = 0;
        private float _minSpeed = 1.0f;
        private float _maxSpeed = 10.0f;

        #endregion

        #region Fields

        private GameObject _scriptManagerGameObject;
        private RoadCreator _roadCreator;
        private UiManager _uiManager;

        #endregion

        #region Methods - Unity

        private void Awake()
        {
            _scriptManagerGameObject = GameObject.Find(Globals.Components.ScriptManager);
            _roadCreator = _scriptManagerGameObject.GetComponent<RoadCreator>();
            _uiManager = GameObject.Find(Globals.Components.UiController).GetComponent<UiManager>();
        }

        private void Update()
        {
            // this allows the user to access Ui elements directly and change them depending on circumstance
            Accelerate();
            _constantSpeed = int.Parse(_uiManager.ConstantRateInputField.text);
            _minSpeed = int.Parse(_uiManager.MinSpeedInputField.text);
            _maxSpeed = int.Parse(_uiManager.MaxSpeedInputField.text);
        }

        private void OnTriggerEnter(Collider other)
        {
            // Trigger when to build next road section
            _roadCreator.BuildRoad();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Player "Car" acceleration can be controller via the ui and apply this to the player(car) object
        /// </summary>
        protected new void Accelerate()
        {
            // this checks if you want to use a constant speed and more realistic min.max speed this can be changed via the PLayer Constant Rate Toggle in UI elements in Game
            if (_uiManager.PlayerConstantRateToggle.isOn == false)
            {
                //Curavble Speed that can be changed via the Ui Elements
                _playerSpeed = Mathf.SmoothStep(_minSpeed, _maxSpeed, base.TimeGone / base.AccelerationTime);
                transform.position += transform.forward * _playerSpeed * Time.deltaTime;
                base.TimeGone += Time.deltaTime;
            }
            else
            {
                //this controls constant speed for player car
                transform.position += transform.forward * _constantSpeed * Time.deltaTime;
            }
        }


        #endregion
    }
}