using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotationSmooth : PlayerRotation
{
    [Header("Smooth Rotation Properties")]
    [SerializeField] private float _smoothTime;
    [SerializeField] private Transform _horiRotHelper;

    private float _horiAngularVelocity;

    public override void Rotate()
    {
        base.Rotate();
    }

    protected override void RotateHorizontal()
    {
        _horiRotHelper.Rotate(Vector3.up * GetHorizontalValue(), Space.Self);
        transform.localRotation
            = Quaternion.Euler(
            0f, 
            Mathf.SmoothDampAngle(
                transform.localEulerAngles.y, 
                _horiRotHelper.localEulerAngles.y,
                ref _horiAngularVelocity,
                _smoothTime),
            0f);
    }
}
