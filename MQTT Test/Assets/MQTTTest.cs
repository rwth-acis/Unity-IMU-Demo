using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

public class MQTTTest : MonoBehaviour
{

    private MqttClient client;
    private DataProcessor dataProcessor;


    // Use this for initialization
    void Start()
    {
        dataProcessor = GetComponent<DataProcessor>();

        // create client instance 
        client = new MqttClient("cloud11.dbis.rwth-aachen.de");

        // register to message received 
        client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

        string clientId = Guid.NewGuid().ToString();
        client.Connect(clientId);

        // subscribe to the topic "/test/hand"
        client.Subscribe(new string[] { "/test/hand" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });

    }
    void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
    {
        Debug.Log("Received: " + System.Text.Encoding.UTF8.GetString(e.Message));
        // pipe the result to the data processor
        dataProcessor.JSON = System.Text.Encoding.UTF8.GetString(e.Message);
    }

    // example for sending:
    //void OnGUI()
    //{
    //    if (GUI.Button(new Rect(20, 40, 80, 20), "Level 1"))
    //    {
    //        Debug.Log("sending...");
    //        client.Publish("hello/world", System.Text.Encoding.UTF8.GetBytes("Sending from Unity3D!!!"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
    //        Debug.Log("sent");
    //    }
    //}

}
