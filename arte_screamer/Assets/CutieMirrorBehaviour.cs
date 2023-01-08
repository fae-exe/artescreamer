using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutieMirrorBehaviour : MonoBehaviour
{
    public HoldAnimator detectionGauge;
    public LoopAnimator cutieAnimator;

    public float xStretchRange;
    public float yStretchRange;
    public float floatAmplitude;

    public AnimationCurve shakingCurve;
    public Vector3 shakingVector;
    public float xShakeAmplitude;
    public float yShakeAmplitude;

    public float shakingInterval;
    public float shakingTimer;

    public Vector3 basePosition;
    public Vector3 baseScale;

    public Sprite cutieIsNotLooking;
    public Sprite cutiePhaseZero;
    public Sprite cutiePhaseOne;
    public float firstThreshold;
    public Sprite cutiePhaseTwo;
    public float secondThreshold;

    public bool isLooking;

    public SpriteRenderer cutieRenderer;

    public float LookingTimer;
    public float LookingMinInterval;
    public float LookingMaxInterval;
    public float LookingNextTime;

    public float LookingDecayer;
    public float LookingMinDuration;
    public float LookingMaxDuration;
    public float LookingCurrentDuration;

    public GameObject deathScreen;

    public void LaunchGauge(float GaugeSpeed = 25.0f)
    {
        if(isLooking)
        {
            detectionGauge.animationSpeed = GaugeSpeed;
            detectionGauge.ResumeAnim();
        }
    }

    public void StopGauge()
    {
        detectionGauge.PauseAnim();
    }

    void Shake ()
    {
        shakingVector = new Vector3(shakingCurve.Evaluate(detectionGauge.value) * UnityEngine.Random.Range(-1.0f, 1.0f),
        shakingCurve.Evaluate(detectionGauge.value) * UnityEngine.Random.Range(-1.0f, 1.0f),
        0);
    }

    // Start is called before the first frame update
    void Start()
    {
        cutieAnimator.LaunchAnim();
        basePosition = transform.position;
        baseScale = transform.localScale;
        deathScreen.SetActive(false);

        LookingNextTime = UnityEngine.Random.Range(LookingMinInterval, LookingMaxInterval);
        LookingCurrentDuration = UnityEngine.Random.Range(LookingMinDuration, LookingMaxDuration);
    }

    // Update is called once per frame
    void Update()
    {

        if (isLooking)
        {
            LookingDecayer = Mathf.Max(0, LookingDecayer - Time.deltaTime);
        }

        if (LookingDecayer == 0)
        {
            isLooking = false;
        }

        if (detectionGauge.isActive)
        {
            isLooking = true;
        }

        if (!isLooking)
        {
            LookingTimer += Time.deltaTime;
        }

        if (LookingTimer > LookingNextTime)
        {
            isLooking = true;

            LookingDecayer = LookingCurrentDuration;
            LookingTimer = LookingTimer % LookingNextTime;

            LookingNextTime = UnityEngine.Random.Range(LookingMinInterval, LookingMaxInterval);
            LookingCurrentDuration = UnityEngine.Random.Range(LookingMinDuration, LookingMaxDuration);
        }

        if(detectionGauge.isFull)
        deathScreen.SetActive(true);

        if (!isLooking)
        {
            StopGauge();
        }

        detectionGauge.Update();
        cutieAnimator.Update();

        shakingTimer += Time.deltaTime;

        if (shakingTimer > shakingInterval)
        {
            shakingTimer = shakingTimer % shakingInterval;
            Shake();
        }

        transform.position = new Vector3(basePosition.x + shakingVector.x,
            basePosition.y + shakingVector.y + floatAmplitude * (cutieAnimator.value - 0.5f),
            basePosition.z);

        transform.localScale = new Vector3(baseScale.x + xStretchRange * (cutieAnimator.value - 0.5f),
            baseScale.y + yStretchRange * (cutieAnimator.valueInv - 0.5f),
            baseScale.z);

        if(!isLooking && detectionGauge.value == 0)
        {
            cutieRenderer.sprite = cutieIsNotLooking;
        }
        else if (detectionGauge.value < firstThreshold)
        {
            cutieRenderer.sprite = cutiePhaseZero;
        }
        else if (detectionGauge.value < secondThreshold)
        {
            cutieRenderer.sprite = cutiePhaseOne;
        }
        else
        {
            cutieRenderer.sprite = cutiePhaseTwo;
        }
    }
}
