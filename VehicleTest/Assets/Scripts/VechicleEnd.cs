using UnityEngine;

public class VechicleEnd : MonoBehaviour
{
    #region Fields
    
    private UiManager _uiManager;
    private string _carCountText;
    
    #endregion

    #region Methods - Unity
    
    private void Awake()
    {
        _uiManager = GameObject.Find(Globals.Components.UiController).GetComponent<UiManager>();
    }

    

    // this Trigger check the car that has passed the Player in the scene
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == Globals.SceneGameObjects.OppositeCar)
        {
            _carCountText = TrafficControl.CarCount.ToString();
            _uiManager.CarCountValue.text = _carCountText;
            TrafficControl.CarCount++;
        }
    }
    
    #endregion
}