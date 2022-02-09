using UnityEngine;
using Level;

namespace Effects
{
    public class CellsEffects : Effect, ICellEffect
    {
        private bool _isStart = true;

        private void Start() 
        {
            AnswerClick.GetFalseAnswerEvent().AddListener((cell) => EaseInBounce(cell));
            AnswerClick.GetTrueAnswerEvent().AddListener((cell) => BounceEffect(cell));
            AnswerClick.GetTrueAnswerEvent().AddListener((cell) => StartParticles(cell.GetComponentInChildren<ParticleSystem>()));
        }

        protected override void BounceEffect(GameObject cell)
        {
            cell.GetComponent<Animator>().Play(BOUNCE_EFFECT);
        }
        
        protected override void EaseInBounce(GameObject cell)
        {
            cell.GetComponent<Animator>().Play(EASE_IN_BOUNCE_EFFECT);
        }
		
        private void StartParticles(ParticleSystem particles)
        {
            particles.Play();
        }
        
        public void PlayStartAnimation(ICellsGeneratable cellsGenerator)
        {
            if(_isStart)
            {
                for(int i = 0; i < cellsGenerator.CreatedCells().Count; i++)
                {
                    BounceEffect(cellsGenerator.CreatedCells()[i]);
                }
                _isStart = false;
            }
        }
        
        private void OnDisable() 
        {
            AnswerClick.GetFalseAnswerEvent().RemoveListener((cell) => EaseInBounce(cell));
            AnswerClick.GetTrueAnswerEvent().RemoveListener((cell) => BounceEffect(cell));
            AnswerClick.GetTrueAnswerEvent().RemoveListener((cell) => StartParticles(cell.GetComponent<ParticleSystem>()));
        }

        public override void LoadingScreenFadeInEffect(Animator loadingScreen)
        {
            throw new System.NotImplementedException();
        }

        protected override void FadeOutEffect(Animator blackScreen)
        {
            throw new System.NotImplementedException();
        }

        public override void FadeInEffect(Animator blackScreen)
        {
            throw new System.NotImplementedException();
        }
    }
}
