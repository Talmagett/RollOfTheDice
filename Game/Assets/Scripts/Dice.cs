using UnityEngine;
using Toolboxes;
public class Dice : SingletonComponent<Dice>
{
    [SerializeField] private Side[] _sides;
    [SerializeField] private LayerMask _diceLayer;
    public int GetNumber(Vector3 direction)
    {
        Physics.Raycast(transform.position, direction, out RaycastHit qq, 1, _diceLayer);
        print(qq.transform.name);
        if (Physics.Raycast(transform.position, direction, out RaycastHit hit, 1, _diceLayer) && hit.transform.TryGetComponent(out Side side))
        {
            return side.Value;
        }
        return 1;
    }
}