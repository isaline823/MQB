using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Door : MonoBehaviour
{
    [SerializeField] private bool _isOpenableDoor = false, _isOpened = false;
    public bool NeedKey = false;
    private Vector3 _openedAngle, _closedAngle;
    [SerializeField] private float _openingDuration = 1, _openingAngle = 110;
    public bool CanTeleport = true;
    private void Start()
    {
        if (_isOpened)
        {
            _openedAngle = transform.eulerAngles;
            _closedAngle = transform.eulerAngles - _openingAngle * Vector3.up;
        }
        else
        {
            _openedAngle = transform.eulerAngles + _openingAngle * Vector3.up;
            _closedAngle = transform.eulerAngles;
        }
    }
    public void ActivateDoor(Key key = null)
    {
        if (_isOpenableDoor && (!NeedKey || (NeedKey && key != null && key.IsGoodKey(this))))
        {
            print("start animate");
            _isOpened = !_isOpened;

            Vector3 target = _isOpened ? _openedAngle : _closedAngle;
            transform.DORotate(target, _openingDuration, RotateMode.Fast);
            StartCoroutine(DesableTeleportation());
        }

    }


    private IEnumerator DesableTeleportation()
    {
        CanTeleport = false;
        yield return new WaitForSeconds(_openingDuration);
        CanTeleport = true;
    }

}
