using TMPro;
using UnityEngine;

public class Answer : MonoBehaviour
{
    [SerializeField] private int _correctAnswer;
    [SerializeField] private TMP_Text _animationText;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Animation _animation;
    [SerializeField] private int _number = 0;
    [SerializeField] private Door _door;
    [Space]
    [SerializeField] private AudioClip _correctAnswerClip;
    [SerializeField] private AudioClip _wrongAnswerClip;
    private Level _level;
    private AudioSource _audioSource;

    private void Awake()
    {
        _level = GetComponentInParent<Level>();
        _audioSource = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        _level.onLevelLoaded += LevelStarted;
    }
    private void OnDisable()
    {
        _level.onLevelLoaded -= LevelStarted;
    }
    private void LevelStarted()
    {
        CheckNumber(_number);
        _animation.Play();
        _animationText.text = _number.ToString();
        _text.text = _number.ToString();
    }
    private void SetNumber(int value)
    {
        if (_number == value) return;
        _number = value;
        _audioSource.PlayOneShot(_correctAnswer == value?_correctAnswerClip:_wrongAnswerClip);
        CheckNumber(_number);
        _animation.Play();
        _animationText.text = _number.ToString();
        _text.text = _number.ToString();
    }

    public void CheckNumber(int value)
    {
        _door.SetDoorState(_correctAnswer == value);
    }
    public void ResetNumber()
    {
        SetNumber(0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Side side))
        {
            SetNumber(side.Value);
        }
    }
}
