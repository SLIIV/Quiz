using UnityEngine;

public class CellsEffects : MonoBehaviour
{
    [SerializeField] private CellsGenerator _cellsGenerator;
    private const string BOUNCE_EFFECT = "Bounce";
    private const string EASE_IN_BOUNCE_EFFECT = "EaseInBounce";
    private bool _isStart = true;

    private void Start() 
    {
        _cellsGenerator.OnPullGenerated.AddListener((pull) => PlayStartAnimation());
        AnswerClick.GetFalseAnswerEvent().AddListener((cell) => EaseInBounce(cell));
        AnswerClick.GetTrueAnswerEvent().AddListener((cell) => BounceEffect(cell));
    }

    private void BounceEffect(GameObject cell)
    {
        cell.GetComponent<Animator>().Play(BOUNCE_EFFECT);
        if(_isStart)
        {
            _cellsGenerator.OnPullGenerated.RemoveListener((pull) => PlayStartAnimation());
            _isStart = false;
        }
    }
	
    private void EaseInBounce(GameObject cell)
    {
        cell.GetComponent<Animator>().Play(EASE_IN_BOUNCE_EFFECT);
    }
	
    private void PlayStartAnimation()
    {
        if(_isStart)
        {
            for(int i = 0; i < _cellsGenerator.CreatedCells.Count; i++)
            {
                BounceEffect(_cellsGenerator.CreatedCells[i]);
            }
       	}
    }
	
    private void OnDisable() 
    {
        AnswerClick.GetFalseAnswerEvent().RemoveListener((cell) => EaseInBounce(cell));
        AnswerClick.GetTrueAnswerEvent().RemoveListener((cell) => BounceEffect(cell));
    }
}
