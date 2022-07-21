using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceSide : MonoBehaviour
{
    [SerializeField] private Vector3 _side;
    private Image _image; 
    private UIDiceSides _diceSides;
    private void Awake()
    {
        _diceSides =transform.parent.GetComponentInParent<UIDiceSides>();
        _image = GetComponent<Image>();
    }
    private void OnEnable()
    {
        DiceMover.onMoved+= ChangeIcon;
    }
    private void OnDisable()
    {
        DiceMover.onMoved -= ChangeIcon;
    }
    private void ChangeIcon()
    {/*
        if (_diceSides == null)
        {
            _diceSides = GetComponentInParent<UIDiceSides>();
        }
        if (_image == null)
        { 
        _image = GetComponent<Image>();
        }*/
        _image.sprite = _diceSides.GetImage(_side);
    }
}
