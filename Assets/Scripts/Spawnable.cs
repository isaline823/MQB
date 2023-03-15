using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnable : MonoBehaviour
{
    public void SpawnIt()
    {
        GameObject.Instantiate(gameObject);
    }
}
