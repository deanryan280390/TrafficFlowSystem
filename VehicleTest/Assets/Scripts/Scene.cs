using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene : MonoBehaviour
{
    #region Fields
    
    private static GameObject _partitions;
    private static GameObject _playerLanes;
    public static GameObject OppositeLanes;
    private static GameObject _playerGameObject;
    
    #endregion

    #region Methods - Unity

    private void Awake()
    {
        Build();
    }

    #endregion
  
    #region Methods
    
    /// <summary>
    /// Builds the initial roads
    /// </summary>
    protected void Build()
    {
        // this builds the intial scene and objects for the game
        _partitions = Instantiate(Resources.Load(Globals.ResourcesPaths.Partitions)) as GameObject;
        _partitions.name = Globals.SceneGameObjects.Partitions;
        _playerLanes = Instantiate(Resources.Load(Globals.ResourcesPaths.Lanes)) as GameObject;
        _playerLanes.name = Globals.SceneGameObjects.Lanes;
        OppositeLanes = Instantiate(Resources.Load(Globals.ResourcesPaths.OppositeLanes)) as GameObject;
        if (OppositeLanes != null) OppositeLanes.name = Globals.SceneGameObjects.OppositeLanes;
        _playerGameObject = Instantiate(Resources.Load(Globals.ResourcesPaths.Car)) as GameObject;
        if (_playerGameObject != null)
        {
            _playerGameObject.AddComponent<Player>();
            _playerGameObject.name = Globals.SceneGameObjects.Player;
        }
        if (_playerLanes != null) _playerLanes.transform.position = Vector3.zero;
    }
    
    #endregion
}