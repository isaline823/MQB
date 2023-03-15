using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestal : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Color _originColor, _validatedColor;
    [SerializeField] private GameObject _target;
    [SerializeField] private List<GameObject> _others;
    [SerializeField] private bool _hasToActivateOthers;
    // Start is called before the first frame update
    void Start()
    {
        _renderer.material.color = _originColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _target)
        {
            _renderer.material.color = _validatedColor;
            if (_hasToActivateOthers && _others.Count > 0) foreach (GameObject otherGO in _others)
                {
                    otherGO.SetActive(!otherGO.activeSelf);
                }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _target)
        {
            _renderer.material.color = _originColor;
            if (_hasToActivateOthers && _others.Count > 0) foreach (GameObject otherGO in _others)
                {
                    otherGO.SetActive(!otherGO.activeSelf);
                }
        }
    }
}
