using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    [SerializeField] private GameObject _restartButton;
    [SerializeField] private LevelChanger _levelChanger;
    [SerializeField] private LevelEffects _levelEffects;
    [SerializeField] private float _restartDelay;

    private void Start()
    {
        _levelChanger.OnGameOver.AddListener(()=> ShowRestartButton());
    }

    private void ShowRestartButton()
    {
        _restartButton.SetActive(true);
    }
	
    public void Restart()
    {
        _restartButton.SetActive(false);
        _levelEffects.LoadingScreenFadeInEffect();
        StartCoroutine(LoadSceneByDelay());
    }
	
    public IEnumerator LoadSceneByDelay()
    {
        yield return new WaitForSeconds(_restartDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
