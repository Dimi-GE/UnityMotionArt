// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class GREENAnimScript : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Animator component attached to this GameObject
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError("Animator component is missing on the GameObject.");
        }
        else
        {
            Debug.Log(animator.name);
        }
    }

    // Option A: Play the animation using a trigger
    public void PlayAnimationWithTrigger()
    {
        animator.SetTrigger("playGreenAnimation");
    }

    public void ResetState()
    {
        animator.SetTrigger("resetGreenState");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            // Option A: Use a trigger to activate the animation
            animator.SetTrigger("playGreenAnimation");
        }
        else if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.B))
        {
            animator.SetTrigger("resetGreenState");
        }
    }
}
