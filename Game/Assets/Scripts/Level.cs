using UnityEngine;
using Toolboxes;
public class Level : MonoBehaviour
{
    [SerializeField] private int _levelIndex;
    [SerializeField] private Transform _targetCamera;
    internal Transform TargetCamera => _targetCamera;
    internal event System.Action onLevelLoaded;
    public void Save()
    {
        PlayerPrefs.SetInt("LastLevel", _levelIndex);
        onLevelLoaded?.Invoke();
    }
}
