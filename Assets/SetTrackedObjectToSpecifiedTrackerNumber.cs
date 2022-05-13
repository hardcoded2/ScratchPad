using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class SetTrackedObjectToSpecifiedTrackerNumber : MonoBehaviour
{
    [SerializeField] private int TrackerIndexToSelect; //0 for the first, 1 for the second
    private SteamVR_TrackedObject.EIndex SelectedEIndex = SteamVR_TrackedObject.EIndex.None; //keep a shallow copy
    private SteamVR_TrackedObject TrackedObject;
    private VirtualTrackerIndexManager TrackerIndexManager;
    
    public void Start()
    {
        TrackedObject = GetComponent<SteamVR_TrackedObject>();
        TrackerIndexManager = FindObjectOfType<VirtualTrackerIndexManager>();
        TrackerIndexManager.OnTrackerIndexUpdatedAsEIndex += OnTrackerIndexUpdatedAsEIndex;
    }

    private void OnTrackerIndexUpdatedAsEIndex(IReadOnlyList<int> activeTrackers)
    {
        if (activeTrackers.Count < TrackerIndexToSelect) //not enough active trackers
        {
            if (SelectedEIndex != SteamVR_TrackedObject.EIndex.None)
            {
                //we used to have an active object, but not anymore
                SelectedEIndex = SteamVR_TrackedObject.EIndex.None;
                TrackedObject.SetDeviceIndex((int) SelectedEIndex);
                TrackedObject.enabled = false;
            }
            return;
        }

        SteamVR_TrackedObject.EIndex indexInList = (SteamVR_TrackedObject.EIndex) activeTrackers[TrackerIndexToSelect];
        if (SelectedEIndex == indexInList)
        {
            return; // our tracker index didn't change
        }
        
        //we changed from none or from another value
        SelectedEIndex = indexInList;
        TrackedObject.SetDeviceIndex((int) SelectedEIndex);
        TrackedObject.enabled = true;
    }

}
