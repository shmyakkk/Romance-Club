using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour
{
    public Animator faderAnimator;
    private Action onAnimationEndCallback;

    private const string FADE_IN = "Fade_In";
    private const string FADE_OUT = "Fade_Out";

    public void FadeIn(Action onAnimationEnd)
    {
        onAnimationEndCallback = onAnimationEnd;

        faderAnimator.Play(FADE_IN, 0, 0f);

        StartCoroutine(WaitForAnimationEnd(FADE_IN));
    }

    IEnumerator WaitForAnimationEnd(string animationName)
    {
        while (!faderAnimator.GetCurrentAnimatorStateInfo(0).IsName(animationName))
        {
            yield return null;
        }

        float animationLength = faderAnimator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(animationLength);

        onAnimationEndCallback?.Invoke();
    }
}
