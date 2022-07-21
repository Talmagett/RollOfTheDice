using UnityEngine;
using TMPro;

public class Symbol : MonoBehaviour
{
    [SerializeField] private char _symbol;
    [SerializeField] private TMP_Text _text;
    private void OnValidate()
    {
        if (string.IsNullOrEmpty(gameObject.scene.name)) return;
        if (_text == null || _symbol == ' ') return;
        this.gameObject.name = _symbol.ToString();
        _text.text= _symbol.ToString();
    }
}