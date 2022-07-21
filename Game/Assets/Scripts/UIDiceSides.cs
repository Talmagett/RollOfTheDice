using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDiceSides : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;
    internal Sprite GetImage(Vector3 direction)
    {
        return _sprites[Dice.Singleton.GetNumber(direction)-1];
    }
}