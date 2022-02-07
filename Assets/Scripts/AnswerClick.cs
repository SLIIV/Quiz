using UnityEngine;
using UnityEngine.Events;

public class AnswerClick : MonoBehaviour
{
    private static OnFalseAnswerEvent _onTrueAnswer = new OnFalseAnswerEvent();
    private static OnFalseAnswerEvent _onFalseAnswer = new OnFalseAnswerEvent();
	
    public void CheckAnswer(Cell cell)
    {
        if(cell.IsTrueAnswer)
        {
            _onTrueAnswer.Invoke(cell.gameObject);
        }
        else
        {
            _onFalseAnswer.Invoke(cell.gameObject);
        }
    }
	
    public static OnFalseAnswerEvent GetTrueAnswerEvent()
    {
        return _onTrueAnswer;
    }
	
    public static OnFalseAnswerEvent GetFalseAnswerEvent()
    {
        return _onFalseAnswer;
    }
}

public class OnFalseAnswerEvent : UnityEvent<GameObject>
{

}

public class OnTrueAnswerEvent : UnityEvent<GameObject>
{

}
