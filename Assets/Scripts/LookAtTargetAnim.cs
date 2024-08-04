// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class LookAtTargetAnim : MonoBehaviour
{

    // Public field to store the reference to the GameObject
    public GameObject[] gameObjectsRefs;

    GameObject gameObjectToLookAt = null;
    GameObject thisCameraObject = null;
    Camera mainCamera;

    public REDAnimScript redAnimScript;
    public GREENAnimScript greenAnimScript;
    public BLUEAnimScript blueAnimScript;

    public Transform target;

    // Rotation speed of the camera
    public float rotationSpeed = 2.0f;
    public float moveSpeed = 5.0f;
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;
    Vector3 offsetToTarget = new Vector3(2.0f, 0.0f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
        thisCameraObject = this.gameObject;
        mainCamera = thisCameraObject.GetComponent<Camera>();
    }

// Update is called once per frame
void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            gameObjectToLookAt = gameObjectsRefs[0];
            target = gameObjectsRefs[0].transform;
            offsetToTarget = new Vector3(3.0f, 1.5f, 0.0f);
            
            redAnimScript.PlayAnimationWithTrigger();
            greenAnimScript.ResetState();
            blueAnimScript.ResetState();
        }

        if (Input.GetKey(KeyCode.G))
        {
            gameObjectToLookAt = gameObjectsRefs[1];
            target = gameObjectsRefs[1].transform;
            offsetToTarget = new Vector3(3.0f, 1.5f, 0.0f);

            greenAnimScript.PlayAnimationWithTrigger();
            blueAnimScript.ResetState();
            redAnimScript.ResetState();
        }

        if (Input.GetKey(KeyCode.B))
        {
            gameObjectToLookAt = gameObjectsRefs[2];
            target = gameObjectsRefs[2].transform;
            offsetToTarget = new Vector3(-3.0f, 1.5f, 0.0f);

            blueAnimScript.PlayAnimationWithTrigger();
            greenAnimScript.ResetState();
            redAnimScript.ResetState();
        }

        if (Input.GetKey(KeyCode.Backspace))
        {
            gameObjectToLookAt = null;
            target = null;
        }

        if (gameObjectToLookAt != null)
        {
            // Calculate the direction from the camera to the target
             // Vector3 direction = gameObjectToLookAt.transform.position - transform.position;
            Vector3 direction = gameObjectToLookAt.transform.position + new Vector3(0f, 1f, 0f) - transform.position;

            // Calculate the target rotation
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // Smoothly rotate towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            MoveCamTowardsTarget();
        }

    }

    void MoveCamTowardsTarget()
    {
        // Check if target is assigned
        if (target != null)
        {
            // Vector3 offsetToTarget = new Vector3(-2.0f, 0.0f, 0.0f);
            // Calculate the target position (offset if needed)
            Vector3 targetPosition = target.position + offsetToTarget;

            // Smoothly move the camera towards the target position
            // Using Vector3.SmoothDamp for smoother movement with damping
            // transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime, moveSpeed, Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
        else
        {
            Debug.LogWarning("Target is not assigned.");
        }
    }
}
