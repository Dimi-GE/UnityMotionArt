// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class BLUEAnimScript : MonoBehaviour
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
        animator.SetTrigger("playBlueAnimation");
    }

    public void ResetState()
    {
        animator.SetTrigger("resetBlueState");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
