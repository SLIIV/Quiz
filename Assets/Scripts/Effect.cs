using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Effects
{
    public abstract class Effect : MonoBehaviour
    {
        protected const string FADE_OUT_EFFECT = "FadeOut";
        protected const string FADE_IN_EFFECT = "FadeIn";
        protected const string LOADING_SCREEN_FADE_IN_EFFECT = "LoadingScreenFadeIn";
        protected const string BOUNCE_EFFECT = "Bounce";
        protected const string EASE_IN_BOUNCE_EFFECT = "EaseInBounce";

        public abstract void LoadingScreenFadeInEffect(Animator loadingScreen);
        protected abstract void FadeOutEffect(Animator blackScreen);
        public abstract void FadeInEffect(Animator blackScreen);
        protected abstract void BounceEffect(GameObject cell);
        protected abstract void EaseInBounce(GameObject cell);
        
    }
}
