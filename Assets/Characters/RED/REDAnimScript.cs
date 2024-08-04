// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class REDAnimScript : MonoBehaviour
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

    // Option B: Directly play the animation by name
    private void PlayAnimationDirectly()
    {
        animator.Play("AimingGun");
    }

    // Option A: Play the animation using a trigger
    public void PlayAnimationWithTrigger()
    {
        animator.SetTrigger("playRedAnimation");
    }

    public void ResetState()
    {
        animator.SetTrigger("resetRedState");
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Option A: Use a trigger to activate the animation
            animator.SetTrigger("playRedAnimation");

            // Option B: Directly play the animation by name
            // PlayAnimationDirectly();
        }
        else if (Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.B))
        {
            animator.SetTrigger("resetRedState");
        }
        */
    }
}
