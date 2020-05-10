using System;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace TrafficSystem
{
    public class ObjectPooling : MonoBehaviour
    {
        #region Fields - Declared

        private readonly string MasterLabel = "Master";
        private readonly string OppositeCarLabel = "OppositeCar";
    
        #endregion

        #region Fields

        public static ObjectPooling Current;
        private List<GameObject> _pooledObjectsList;
        private Master _master;
        private UiManager _uiManager;

        #endregion

        #region Methods - Unity

        private void Awake()
        {
            Current = this;
            _master = GameObject.Find(MasterLabel).GetComponent<Master>();
            _pooledObjectsList = new List<GameObject>();
        }

        private void Start()
        {
            // this sets up the pool objects of type car in the scene , pool amount can be changed by the design team Via the Master Script in the Editor
            for (int i = 0; i < _master.PoolAmount; i++)
            {
                GameObject obj = Instantiate(Resources.Load(Globals.ResourcesPaths.OppositeCar)) as GameObject;
                if (obj != null)
                {
                    obj.name = OppositeCarLabel;
                    obj.SetActive(false);
                    _pooledObjectsList.Add(obj);
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Return the Game object to the pool
        /// </summary>
        /// <returns></returns>
        public GameObject GetPooledGameObject()
        {
            //Gets the pool object and send this one object to Traffic Control Script
            foreach (GameObject poolObject in _pooledObjectsList)
            {
                if (!poolObject.activeInHierarchy)
                {
                    return poolObject;
                }
            }

            if (_master.IsExpanding) // if you want the pool list to expand , this can be adjusted via the Master Script in the Editor for the design team
            {
                GameObject obj = Instantiate(Resources.Load(Globals.ResourcesPaths.OppositeCar)) as GameObject;
                _pooledObjectsList.Add(obj);
                return obj;
            }

            return null;
        }

        #endregion
    }
}