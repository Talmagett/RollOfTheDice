using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resetter : MonoBehaviour
{
    [SerializeField] private Answer _answers;
    [SerializeField] private LineRenderer _lineRenderer;
#if UNITY_EDITOR
    private void OnValidate()
    {
        if (string.IsNullOrEmpty(gameObject.scene.name)) return;
        if (_answers == null) return;
        SetLink();
    }
#endif
    private void Start()
    {
        SetLink();
    }
    [ContextMenu("SetLink")]
    private void SetLink()
    {
        _lineRenderer.SetPosition(0,Vector3.zero);
        _lineRenderer.SetPosition(_lineRenderer.positionCount-1, _answers.transform.position- transform.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _answers.ResetNumber();
        }
    }
}