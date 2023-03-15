using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private List<Door> _doors;
    public bool IsGoodKey(Door otherDoor)
    {
        if (_doors.Count > 0)
        {
            foreach (Door door in _doors)
            {
                if (otherDoor == door) return true;
            }
        }
        return false;
    }
}
