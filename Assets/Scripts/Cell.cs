using UnityEngine;
using UnityEngine.UI;

namespace Level
{
    [RequireComponent(typeof(Animator))]
    public class Cell : MonoBehaviour
    {
        public Image ObjectImage { get { return _objectImage; } }
        public bool IsTrueAnswer { get { return _isRightAnswer; } }
        [SerializeField] private Image _objectImage;
        private bool _isRightAnswer = false;
        
        public void SetAnswerTrue()
        {
            _isRightAnswer = true;
        }
        
    }
}