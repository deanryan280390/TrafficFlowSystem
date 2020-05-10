using UnityEngine;

public class Car : MonoBehaviour
{
    #region Fields - Declared

    private float _currentSpeed = 0f;
    private float _maxSpeed = 10.0f;
    private float _accelerationTime = 60.0f;
    private System.Random _randomSeed = new System.Random();
    
    #endregion

    #region Fields

    private float _minSpeed;
    private float _timeGone;
  
    private int _randomCarSpeed;

    #endregion
    
    #region Properties

    public float CurrentSpeed
    {
        get { return _currentSpeed; }
        set { _currentSpeed = value; }
    }

    public float MaxSpeed
    {
        get { return _maxSpeed; }
        set { _maxSpeed = value; }
    }

    public float AccelerationTime
    {
        get { return _accelerationTime; }
        set { _accelerationTime = value; }
    }

    public float MovementSpeed
    {
        get { return _minSpeed; }
        set { _minSpeed = value; }
    }

    public float MinSpeed
    {
        get { return _minSpeed; }
        set { _minSpeed = value; }
    }

    public float TimeGone
    {
        get { return _timeGone; }
        set { _timeGone = value; }
    }

    #endregion

    #region Methods - Unity

    private void Awake()
    {
        //Set the random speed number between 2-20
        _randomCarSpeed = _randomSeed.Next(2, 20);
    }

    protected void Update()
    {
        Accelerate();
    }

    /// <summary>
    /// When car enters set game object to false
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        //This calls the trigger to disable the car object in the pool
        transform.gameObject.SetActive(false);
    }

    #endregion

    #region Methods

    /// <summary>
    /// Apply the acceleration to the car
    /// </summary>
    public void Accelerate()
    {
        //This sets a random speed for the opposing cars coming in the opposite direction
        transform.position += transform.forward * _randomCarSpeed * Time.deltaTime;
    }

    #endregion
}