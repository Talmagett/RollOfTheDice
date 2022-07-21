using UnityEngine;

public class Saver : MonoBehaviour
{
    [SerializeField] private Door _lastLevel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_lastLevel)
                _lastLevel.SetDoorState(false);
            Level level= GetComponentInParent<Level>();
            level.Save();
            Camera.main.GetComponent<CameraChanger>().ChangeTarget(level);
        }
    }
}
