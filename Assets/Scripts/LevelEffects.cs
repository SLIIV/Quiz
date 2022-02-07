using UnityEngine;

public class LevelEffects : MonoBehaviour
{
    [SerializeField] private Animator _blackWindow;
    [SerializeField] private Animator _loadingWindow;
    [SerializeField] private LevelChanger _levelChanger;
    private const string FADE_OUT_EFFECT = "FadeOut";
    private const string FADE_IN_EFFECT = "FadeIn";
    private const string LOADING_SCREEN_FADE_IN_EFFECT = "LoadingScreenFadeIn";
    
    private void Start() 
    {
        _levelChanger.OnGameOver.AddListener(() => FadeInEffect());
    }

    public void LoadingScreenFadeInEffect()
    {
        _loadingWindow.gameObject.SetActive(true);
        _loadingWindow.Play(LOADING_SCREEN_FADE_IN_EFFECT);
    }

    private void FadeOutEffect()
    {

        _blackWindow.Play(FADE_OUT_EFFECT);
    }

    private void FadeInEffect()
    {
        _blackWindow.gameObject.SetActive(true);
        _blackWindow.Play(FADE_IN_EFFECT);
    }
	
    private void OnDisable()
    {
        _levelChanger.OnGameOver.RemoveListener(() => FadeInEffect());
    }
}
