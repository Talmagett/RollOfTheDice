using System;
using UnityEngine;

public class CameraChanger : MonoBehaviour
{
    private Transform _target;
    private void Update()
    {
        if (transform.position == _target.position && transform.rotation == _target.rotation) return;

        transform.position = Vector3.Lerp(transform.position, _target.position, 8 * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, _target.rotation, 8 * Time.deltaTime);
    }
    internal void ChangeTarget(Level level)
    {
        if (_target != level.TargetCamera)
        {
            _target = level.TargetCamera;
        }
    }
}
