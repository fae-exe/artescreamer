using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamerController : MonoBehaviour
{
    public Vector3 targetPosition;
    public Vector3 velocity = Vector3.zero;
    public float characterDepthPosition;

    public float movementSmoothTime = 0.3f;
    public float characterSpeed = 5.0f;
    
    public Vector2 worldMousePosV3 = new Vector2();

    // Start is called before the first frame update
    void Start()
    {
        characterDepthPosition = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        worldMousePosV3 = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, characterDepthPosition));
        targetPosition = new Vector3(worldMousePosV3.x, worldMousePosV3.y, characterDepthPosition);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, movementSmoothTime);

        if (Input.GetKey(KeyCode.Mouse0))
        {
            characterDepthPosition -= characterSpeed * Time.deltaTime;
        }
    }
}
