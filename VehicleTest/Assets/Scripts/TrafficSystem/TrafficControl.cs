using System;
using System.Collections;
using System.Collections.Generic;
using CarSystem;
using UnityEngine;

namespace TrafficSystem
{
    public class TrafficControl : MonoBehaviour
    {
        #region Fields

        private List<GameObject> _spawnPoints;
        public static int CarCount = 1;

        #endregion
    
        #region Methods - Unity

        private void Start()
        {
            _spawnPoints = new List<GameObject>();
            //Calls the pool object and sets up Car Object and Script
            StartCoroutine(TrafficFlowController());
        }

        #endregion
    
        #region Methods 
    
        /// <summary>
        /// TrafficFlowController sets up traffic flow controller
        /// </summary>
        /// <param name="repeatTime"></param>
        /// <returns></returns>
        IEnumerator TrafficFlowController(float repeatTime = 0.5f)
        {
            while(true)
            {
                TrafficFlow();
                yield return new WaitForSeconds(repeatTime);
            }
        }
    
        /// <summary>
        /// this controls traffic with object pooling
        /// </summary>
        private void TrafficFlow()
        {
            // This uses object pooling to reuse car objects
            GameObject obj = ObjectPooling.Current.GetPooledGameObject();
            if (obj != null)
            {
                obj.transform.position = RandomSpawnsPoint().transform.position;
                Car car = obj.GetComponent<Car>();

                //Set Random colour to the shader for each car
                Renderer rend = obj.transform.GetComponent<Renderer>();
                rend.material.shader = Shader.Find(Globals.ShaderInformation.DiffuseShader);
                rend.material.SetColor(Globals.ShaderInformation.ShaderColor, UnityEngine.Random.ColorHSV());
                obj.SetActive(true);
                _spawnPoints.Clear();
            }
        }

        /// <summary>
        /// Create random spawn points to mimic the random traffic patterns
        /// </summary>
        /// <returns></returns>
        public GameObject RandomSpawnsPoint()
        {
            //This set random spawn points for each car that is created this is robust the more spawn points/ lanes you add the function will adjust to this
            int spawnCount = 0;

            System.Random randomNumber = new System.Random();

            foreach (Transform parent in GameObject.Find(Globals.SceneGameObjects.OppositeLanes).transform)
            {
                if (parent.gameObject.name.Contains(Globals.SceneGameObjects.VehicleSpawn))
                {
                    spawnCount++;
                    _spawnPoints.Add(parent.gameObject);
                }
                foreach (Transform child in parent)
                {
                    if (child.name.Contains(Globals.SceneGameObjects.VehicleSpawn))
                    {
                        spawnCount++;
                        _spawnPoints.Add(child.gameObject);
                    }
                }
            }
            int randomSpawnPointNumber = randomNumber.Next(0, spawnCount);
            return _spawnPoints[randomSpawnPointNumber];
        }
    
        #endregion
    }
}