using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {
    [SerializeField] Animation _mainMenuAnimator;
    [SerializeField] AnimationClip _fadeOutAnimationClip;
    [SerializeField] AnimationClip _fadeInAnimationClip;

    public void OnFadeOutComplete()
    {
        Debug.Log("FadeOut Complete");
    }

    public void OnFadeInComplete()
    {
        Debug.Log("FadeIn Complete");
    }


    public void FadeOut()
    {
        _mainMenuAnimator.Stop();
        _mainMenuAnimator.clip = _fadeOutAnimationClip;
        _mainMenuAnimator.Play();
        UIManager.Instance.SetDummyCameraActive(false);
        OnFadeOutComplete();
    }
    public void FadeIn()
    {
        _mainMenuAnimator.Stop();
        _mainMenuAnimator.clip = _fadeInAnimationClip;
        _mainMenuAnimator.Play();
        UIManager.Instance.SetDummyCameraActive(true);
        OnFadeInComplete();
    }


}
