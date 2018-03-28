using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SensorData {

    public AccelerometerData accelerometer;
    public Vector3 gyroscope;
    public MagnetometerData magnetometer;

    public SensorData(Vector3 v_accelerometer, Vector3 v_gyroscope, Vector3 v_magnetometer)
    {
        accelerometer = new AccelerometerData(v_accelerometer);
        gyroscope = v_gyroscope;
        magnetometer = new MagnetometerData(v_magnetometer, 0);
    }
}

[Serializable]
public class AccelerometerData
{
    public float x, y, z, sqrt;

    public AccelerometerData(Vector3 vector)
    {
        x = vector.x;
        y = vector.y;
        z = vector.z;
        sqrt = vector.magnitude;
    }

    public Vector3 ToVector()
    {
        Vector3 vector = new Vector3(x, y, z);
        return vector;
    }
}

[Serializable]
public class MagnetometerData
{
    public float x, y, z, hdirection;

    public MagnetometerData(Vector3 vector, float hdirection)
    {
        x = vector.x;
        y = vector.y;
        z = vector.z;
        this.hdirection = hdirection;
    }

    public Vector3 ToVector()
    {
        return new Vector3(x, y, z);
    }

}
