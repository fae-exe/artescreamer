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
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;

        targetPosition = new Vector3(
            characterXPosition,
            Mapping(Input.mousePosition.y, 0, Screen.height, minVertPos, maxVertPos),
            Mapping(Input.mousePosition.x, 0, Screen.width, maxHorPos, minHorPos)
        );

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, movementSmoothTime);

        if (Input.GetKey(KeyCode.Mouse0))
        {
            characterXPosition += characterSpeed * Time.deltaTime;
        }
    }
}
