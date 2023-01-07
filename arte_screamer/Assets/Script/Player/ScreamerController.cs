using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamerController : MonoBehaviour
{
    public Vector3 targetPosition;
    public Vector3 velocity = Vector3.zero;

    public float characterXPosition;

    public float movementSmoothTime = 0.3f;
    public float characterSpeed = 5.0f;

    public float minVertPos;
    public float maxVertPos;

    public float minHorPos;
    public float maxHorPos;

    public float minFOV;
    public float maxFOV;

    public float XOffset;
    public float YOffset;

    public float targetFOV;
    public float velocityFOV;
    public float smoothTimeFOV;

    public float bobUpDownRatio;

    public Camera CharacterCam;

    public LoopAnimator motionAnimator;

    float Mapping(float value, float leftMin, float leftMax, float rightMin, float rightMax)
    {
        value = Mathf.Min(leftMax, value);
        value = Mathf.Max(leftMin, value);

        return rightMin + (value - leftMin) * (rightMax - rightMin) / (leftMax - leftMin);
    }

    // Start is called before the first frame update
    void Start()
    {
        characterXPosition = transform.position.x;
        motionAnimator.LaunchAnim();
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;
        motionAnimator.Update();

        targetPosition = new Vector3(
            characterXPosition,
            Mapping(Input.mousePosition.y + (Screen.height/ bobUpDownRatio) * (motionAnimator.value - 0.5f), 0, Screen.height, minVertPos, maxVertPos),
            Mapping(Input.mousePosition.x, 0, Screen.width, maxHorPos, minHorPos)
        );

        XOffset = Mathf.Abs(Input.mousePosition.x - Screen.width / 2) / (Screen.width / 2);
        YOffset = Mathf.Abs(Input.mousePosition.y - Screen.height / 2) / (Screen.height / 2);
        targetFOV = -Mapping(XOffset + YOffset, 0, 2, -maxFOV, -minFOV);
        CharacterCam.fieldOfView = Mathf.SmoothDamp(CharacterCam.fieldOfView, targetFOV, ref velocityFOV, smoothTimeFOV);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, movementSmoothTime);

        if (Input.GetKey(KeyCode.Mouse0))
        {
            motionAnimator.ResumeAnim();
            characterXPosition += characterSpeed * Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            motionAnimator.PauseAnim();
        }
    }
}