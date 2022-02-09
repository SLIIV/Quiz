using UnityEngine;

namespace Effects
{
    public class LevelEffects : Effect, IEffecteble
    {
        public override void LoadingScreenFadeInEffect(Animator loadingScreen)
        {
            loadingScreen.Play(LOADING_SCREEN_FADE_IN_EFFECT);
        }

        protected override void FadeOutEffect(Animator blackScreen)
        {

            blackScreen.Play(FADE_OUT_EFFECT);
        }

        public override void FadeInEffect(Animator blackScreen)
        {
            blackScreen.gameObject.SetActive(true);
            blackScreen.Play(FADE_IN_EFFECT);
        }

        protected override void BounceEffect(GameObject cell)
        {
            throw new System.NotImplementedException();
        }

        protected override void EaseInBounce(GameObject cell)
        {
            throw new System.NotImplementedException();
        }
    }
}
