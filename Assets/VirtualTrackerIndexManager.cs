using System;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class VirtualTrackerIndexManager : MonoBehaviour
{
    private List<int> knownTrackerIDs;
    public Action<IReadOnlyList<int>> OnTrackerIndexUpdatedAsEIndex;  
    public void OnEnable()
    {
        knownTrackerIDs = new List<int>();
        SteamVR_Events.DeviceConnected.Listen(OnDeviceConnected);
    }
    
    private void OnDeviceConnected(int DeviceIDasEIndex, bool connected)
    {
        bool previouslySeenTracker = knownTrackerIDs.Contains(DeviceIDasEIndex);
        if (previouslySeenTracker && !connected)
        {
            knownTrackerIDs.Remove(DeviceIDasEIndex);
        }

        if (connected)
        {
            //only look at new devices that are trackers
            ETrackedDeviceClass deviceClass = OpenVR.System.GetTrackedDeviceClass((uint)DeviceIDasEIndex);
            
            if (deviceClass != ETrackedDeviceClass.GenericTracker) //we're only looking for generic trackers
                return;
            
            if (!previouslySeenTracker)
            {
                knownTrackerIDs.Add(DeviceIDasEIndex);
            }
            else
            {
                Debug.LogWarning("Double added a tracker");
            }
        }
        OnTrackerIndexUpdatedAsEIndex.Invoke(knownTrackerIDs);
    }
}
