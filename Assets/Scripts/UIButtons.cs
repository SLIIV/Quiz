using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    class UIButtons : MonoBehaviour, IUIButtons
    {
            [SerializeField] private GameObject _restartButton;
            [SerializeField] private float _restartDelay;
            [SerializeField] private GameObject _gameOverObject;
            private IGameOverable _gameOver;

            private void Start()
            {
                _gameOver = _gameOverObject.GetComponent<IGameOverable>();
                if(_gameOver == null)
                {
                    throw new System.Exception("Null reference exception: GameOver not contains interface IGameOverable");
                }
            }

            public void ShowRestartButton()
            {
                _gameOver.ShowBlackScreen();
                _gameOver.ShowRestartButton();
            }
            
            public void Restart()
            {
                _gameOver.ShowLoadingScreen();
                _gameOver.HideRestartButton();
                StartCoroutine(LoadSceneByDelay());
            }
            
            public IEnumerator LoadSceneByDelay()
            {
                yield return new WaitForSeconds(_restartDelay);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
    }
}
