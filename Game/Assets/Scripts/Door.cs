using System.Collections;
using UnityEngine;
[SelectionBase]
public class Door : MonoBehaviour
{
    [SerializeField] private Transform _animatingTransform;
    private bool _isOpened;
    public void SetDoorState(bool value)
    {
        _isOpened = value;
        StopAllCoroutines();
        StartCoroutine(StateAnimation());
    }
    private IEnumerator StateAnimation()
    {
        float height = _isOpened ? -1.5f : 0;
        Vector3 targetPos = new Vector3(_animatingTransform.position.x, height, _animatingTransform.position.z);
        while (_animatingTransform.position.y != height)
        {
            _animatingTransform.position = Vector3.MoveTowards(_animatingTransform.position, targetPos,Time.deltaTime*5);
            yield return null;
        }
    }
}