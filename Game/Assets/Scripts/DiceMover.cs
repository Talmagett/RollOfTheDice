using System.Collections;
using UnityEngine;

public class DiceMover : MonoBehaviour
{
    [SerializeField] private Transform _dice;
    [SerializeField] private Transform _startTransform;
    [SerializeField] private Transform _targetTransform;
    [SerializeField] float _timeToReachTarget = 0.4f;
    [SerializeField] private LayerMask _wallsLayer;
    internal static event System.Action onMoved;

    private bool _canControl = true;
    private float _deltaTime;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.1f);
    }
    void Update()
    {
        GetInput();
        if (_canControl) return;
        MoveRotate();
    }
    private void GetInput()
    {
        if (transform.position == _targetTransform.position && _dice.rotation == _targetTransform.rotation)
        {
            if (!_canControl)
            {
                onMoved?.Invoke();
                _canControl = true;
            }
        }

        if (!_canControl) return;

        float horMove = 0, verMove = 0;
        horMove = Input.GetAxisRaw("Horizontal");
        if (horMove == 0)
            verMove = Input.GetAxisRaw("Vertical");
        if (horMove == 0 && verMove == 0) return;

        Vector3 dir = new Vector3(horMove, 0, verMove);

        _startTransform.position = transform.position;
        _startTransform.rotation = _dice.rotation;

        _targetTransform.position = transform.position;
        _targetTransform.rotation = transform.rotation;
        if (Physics.CheckSphere(_targetTransform.position + dir, 0.1f, _wallsLayer))
            return;
        if (!Physics.CheckSphere(_targetTransform.position + dir + (Vector3.up*-0.5f), 0.3f,1>>0))return;
        _targetTransform.position += dir;
        dir = new Vector3(dir.z, 0, -dir.x);
        Quaternion eulers = Quaternion.AngleAxis(90.0f, dir) * _dice.rotation;

        _targetTransform.rotation = eulers;
        _deltaTime = 0;
        _canControl = false;
    }
    private void MoveRotate()
    {
        _deltaTime += Time.deltaTime / _timeToReachTarget;

        transform.position = Vector3.Lerp(_startTransform.position, _targetTransform.position, _deltaTime);
        _dice.rotation = Quaternion.Lerp(_startTransform.rotation, _targetTransform.rotation, _deltaTime);
    }
}