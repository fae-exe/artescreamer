using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LoopAnimator : AutoAnimator
{

    public override void Update()
    {

        if (!isActive)
        {
            return;
        }

        animationSlider = animationSlider + Time.deltaTime * animationSpeed;

        if (animationSlider > 100.0f)
        {
            animationSlider = animationSlider % 100.0f;
        }

        // Evaluates the curve if it has any keys; if not it's just linear.
        easedValue = curve.keys.Length > 0 ? curve.Evaluate(animationSlider / 100) : animationSlider / 100;

        // Use the magnitude to determine the apparent value and inverse value.
        value = easedValue * magnitude;
        valueInv = (1.0f - easedValue) * magnitude;
    }
}