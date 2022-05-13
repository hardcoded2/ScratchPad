using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class SetTrackedObjectToFirstConnectedTracker : MonoBehaviour
{
    private List<int> knownTrackerIDs;
    [SerializeField] private int TrackerIndexToSelect; //0 for the first, 1 for the second
    private SteamVR_TrackedObject.EIndex SelectedEIndex = SteamVR_TrackedObject.EIndex.None;
    private SteamVR_TrackedObject _trackedObject;
    public void OnEnable()
    {
        _trackedObject = GetComponent<SteamVR_TrackedObject>();
        knownTrackerIDs = new List<int>();
        SteamVR_Events.DeviceConnected.Listen(OnDeviceConnected);
    }
    
    private void OnDeviceConnected(int DeviceIDasEIndex, bool connected)
    {
        bool previouslySeen = knownTrackerIDs.Contains(DeviceIDasEIndex);
        if (previouslySeen && !connected)
        {
            knownTrackerIDs.Remove(DeviceIDasEIndex);
            if (SelectedEIndex == (SteamVR_TrackedObject.EIndex) DeviceIDasEIndex &&  SelectedEIndex != SteamVR_TrackedObject.EIndex.None)
            {
                SelectedEIndex = SteamVR_TrackedObject.EIndex.None;
                //if we want to try to connect to another active tracker if the first goes off
                /*
                foreach (var trackerID in knownTrackerIDs)
                {
                    SelectedEIndex = (SteamVR_TrackedObject.EIndex)trackerID;
                    _trackedObject.SetDeviceIndex(trackerID);
                    break;
                }
                */
                if (SelectedEIndex == SteamVR_TrackedObject.EIndex.None)
                {                    
                    _trackedObject.SetDeviceIndex((int)SelectedEIndex);
                    _trackedObject.enabled = false;
                }
            }
        }

        if (connected)
        {
            //only look at new devices that are trackers
            ETrackedDeviceClass deviceClass = OpenVR.System.GetTrackedDeviceClass((uint)DeviceIDasEIndex);
            
            if (deviceClass != ETrackedDeviceClass.GenericTracker) //we're only looking for generic trackers
                return;
            
            if (!previouslySeen)
            {
                knownTrackerIDs.Add(DeviceIDasEIndex);
            }

            if (SelectedEIndex == SteamVR_TrackedObject.EIndex.None) //if we're not aware of a tracker, use this one
            {
                SelectedEIndex = (SteamVR_TrackedObject.EIndex) DeviceIDasEIndex; 
                _trackedObject.SetDeviceIndex(DeviceIDasEIndex);
                _trackedObject.enabled = true;
            }
            
        }
    }
}
