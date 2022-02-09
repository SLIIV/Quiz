using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class GameOver : MonoBehaviour, IGameOverable
    {
        [SerializeField] private GameObject _restartButton;
        [SerializeField] private GameObject _blackScreen;
        [SerializeField] private GameObject _loadingScreen;
        [SerializeField] private GameObject _levelEffectsObject;
        private IEffecteble _levelEffects;

        private void Start() 
        {
            _levelEffects = _levelEffectsObject.GetComponent<IEffecteble>();
            if(_levelEffects == null)
            {
                throw new System.Exception("Null reference exception: LevelEffectsObject not contains interface ILevelEffects");
            }
        }

        public void ShowRestartButton()
        {
            _restartButton.SetActive(true);
        }

        public void HideRestartButton()
        {
            _restartButton.SetActive(false);
        }

        public void ShowBlackScreen()
        {
            _levelEffects.FadeInEffect(_blackScreen.GetComponent<Animator>());
        }
		
        public void ShowLoadingScreen()
        {
            _loadingScreen.gameObject.SetActive(true);
            _levelEffects.LoadingScreenFadeInEffect(_loadingScreen.GetComponent<Animator>());
        }
    }
}
