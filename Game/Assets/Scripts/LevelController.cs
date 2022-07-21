using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private Level[] _levels;
    [SerializeField] private bool _loadManually;
    [SerializeField] private int _index;
    private void Start()
    {
        int index = _loadManually ? _index : PlayerPrefs.GetInt("LastLevel", 1) - 1;
        Level level= _levels[index];
        Vector3 targetPos = level.GetComponentInChildren<Saver>().transform.position;
        Transform dice = FindObjectOfType<Dice>().transform;
        targetPos.y = dice.position.y;
        dice.position = targetPos;
    }
}