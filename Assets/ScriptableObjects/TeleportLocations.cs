using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TeleportLocations : ScriptableObject
{
    [System.Serializable]
    public struct TeleportLocation
    {
        public string Key;
        public Vector3 TargetLocation;

    }
    public TeleportLocation[] Locations;
}
