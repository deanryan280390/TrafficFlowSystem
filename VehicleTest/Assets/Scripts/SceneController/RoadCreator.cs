using System;
using UnityEngine;

namespace SceneController
{
    public class RoadCreator : MonoBehaviour
    {
        #region Fields

        private Vector3 _offset = new Vector3(0, 0, 0);

        #endregion

        #region Methods

        /// <summary>
        /// Builds the roads for infinity length
        /// </summary>
        public void BuildRoad()
        {
            // this rebuild the infinity scene with all the objects
            Destroy(GameObject.Find(Globals.SceneGameObjects.Lanes));
            GameObject lanes = Instantiate(Resources.Load(Globals.ResourcesPaths.Lanes)) as GameObject;
            lanes.transform.position =
                new Vector3(0, 0, GameObject.Find(Globals.SceneGameObjects.Player).transform.position.z);

            //Destroy(GameObject.Find("OppositeLanes"));
            Destroy(GameObject.Find(Globals.SceneGameObjects.OppositeLanes));
            GameObject oppositeLanes = Instantiate(Resources.Load(Globals.ResourcesPaths.OppositeLanes)) as GameObject;
            oppositeLanes.transform.position = new Vector3(-3.72f, 0,
                GameObject.Find(Globals.SceneGameObjects.Player).transform.position.z);

            Destroy(GameObject.Find(Globals.SceneGameObjects.Partitions));
            GameObject partitions = Instantiate(Resources.Load(Globals.ResourcesPaths.Partitions)) as GameObject;
            partitions.transform.position = new Vector3(-1.886f, 0.28f,
                GameObject.Find(Globals.SceneGameObjects.Player).transform.position.z);

            lanes.name = Globals.SceneGameObjects.Lanes;
            oppositeLanes.name = Globals.SceneGameObjects.OppositeLanes;
            partitions.name = Globals.SceneGameObjects.Partitions;
        }

        #endregion
    }
}