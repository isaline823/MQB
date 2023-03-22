using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PedestalsManager : MonoBehaviour
{
    [SerializeField] private List<Pedestal> _pedestals;
    [SerializeField] private List<GameObject> _gameObjectsToActivate, _gameObjectsToInstantiateOnce;
    private bool _asAlreadyInstantiate = false, _allActivated = false;

    public void UpdatePedestalsManager()
    {
        _allActivated = true;
        foreach (Pedestal pedestal in _pedestals)
        {
            _allActivated = _allActivated && pedestal.IsValidated;
            if (!_allActivated) break;
        }
        SetActiveState(_gameObjectsToActivate, _allActivated);
        if (!_asAlreadyInstantiate && _allActivated) { InstantiateOnce(_gameObjectsToInstantiateOnce); }
    }

    private void InstantiateOnce(List<GameObject> gameObjectsToInstantiateOnce)
    {
        foreach (GameObject go in gameObjectsToInstantiateOnce)
        {
            Instantiate(go);
        }
        _asAlreadyInstantiate = true;
    }

    private void SetActiveState(List<GameObject> gameObjectsToActivate, bool allActivated)
    {
        foreach (GameObject gameObject in gameObjectsToActivate)
        {
            gameObject.SetActive(allActivated);
        }
    }
}
