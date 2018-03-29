using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataProcessor : MonoBehaviour
{

    MadgwickAHRS ahrs;
    // private float lastTime;

    public string JSON { get; set; }

    private void Start()
    {
        ahrs = GameObject.Find("Hand").GetComponent<MadgwickAHRS>();
    }

    private void Update()
    {
        JSONToOrientation(JSON);
    }

    private void JSONToOrientation(string json)
    {
        // float deltaTime = Time.time - lastTime;
        // lastTime = Time.time;
        SensorData data = JsonUtility.FromJson<SensorData>(json); // deserialize JSON data
        if (data != null) // if serialization successful => pipe to AHRS algorithm
        {
            ahrs.accelerometer = data.accelerometer.ToVector();
            ahrs.magnetsensor = data.magnetometer.ToVector();
            ahrs.gyroscope = new Vector3(
                data.gyroscope.x * Mathf.Deg2Rad,
                data.gyroscope.y * Mathf.Deg2Rad,
                data.gyroscope.z * Mathf.Deg2Rad
                );

            //ahrs.samplePeriod = deltaTime; // time components could be used to adapt the sample rate
        }
    }
}
