using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HoldAnimator : AutoAnimator
{
    public float decaySpeed;
    public bool isFull = false;

    public void Decay()
    {
        animationSlider = Mathf.Max(0, animationSlider - Time.deltaTime * decaySpeed);

        // Evaluates the curve if it has any keys; if not it's just linear.
        easedValue = curve.keys.Length > 0 ? curve.Evaluate(animationSlider / 100) : animationSlider / 100;

        // Use the magnitude to determine the apparent value and inverse value.
        value = easedValue * magnitude;
        valueInv = (1.0f - easedValue) * magnitude;
    }

    public override void Update()
    {

        if (!isActive)
        {
            Decay();
            return;
        }

        animationSlider = Mathf.Min(100.0f, animationSlider + Time.deltaTime * animationSpeed);

        if (animationSlider == 100.0f)
        {
            isFull = true;
        }

        // Evaluates the curve if it has any keys; if not it's just linear.
        easedValue = curve.keys.Length > 0 ? curve.Evaluate(animationSlider / 100) : animationSlider / 100;

        // Use the magnitude to determine the apparent value and inverse value.
        value = easedValue * magnitude;
        valueInv = (1.0f - easedValue) * magnitude;
    }
}