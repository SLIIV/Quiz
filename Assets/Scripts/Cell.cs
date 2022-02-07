using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class Cell : MonoBehaviour
{
    public Image ObjectImage { get { return _objectImage; } }
    public ObjectInCell ObjectInCell { get { return _objectInCell; } }
    public bool IsTrueAnswer { get { return _isRightAnswer; } }
    [SerializeField] private Image _objectImage;
    private ObjectInCell _objectInCell;
    private bool _isRightAnswer = false;
    
    public void SetAnswerTrue()
    {
        _isRightAnswer = true;
    }
    
}
