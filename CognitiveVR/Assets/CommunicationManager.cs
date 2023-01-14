using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sngty;
using System;

public class CommunicationManager : MonoBehaviour
{
    public SingularityManager singularityManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //if(Input.GetKeyDown(KeyCode.L))
        if(OVRInput.GetDown(OVRInput.Button.Any))
        {
            DebugLog("Getting started");
            ConnectandGet();
        }
    }

    private void DebugLog(string v)
    {
        Debug.Log("MBMB: "+v);
    }

    public void ConnectandGet()
    {
        List<DeviceSignature> pairedDevices = singularityManager.GetPairedDevices();

        if(pairedDevices.Count==0)
        {
            DebugLog("No devices paired");
            return;
        }

        foreach (var item in pairedDevices)
        {
            DebugLog("Name is " + item.name);
        }

        singularityManager.ConnectToDevice(pairedDevices[0]);

        singularityManager.onMessageRecieved.AddListener(OnCC);

        Debug.Log("Name "+pairedDevices[0].name);

        singularityManager.sendMessage("connection", pairedDevices[0]);

    }

    public void onConnected()
    {
        DebugLog("Connected to device!");
    }

    public void OnCC(string message)
    {
        DebugLog("Message recieved from deviceeeeee: " + message);
    }

    public void onMessageRecieved(string message)
    {
        DebugLog("Message recieved from device: " + message);
    }

    public void onError(string errorMessage)
    {
        DebugLog("Error with Singularity: " + errorMessage);
    }


}
