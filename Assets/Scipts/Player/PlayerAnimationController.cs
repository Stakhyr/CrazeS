using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    Animator anim;
    private string currentState;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ChangeAnimationState(string newState) 
    {
        // stop the same animation from interrupting itself
        if (currentState == newState) return;

        //play animation
        anim.Play(newState);

        //reasign the current state
        currentState = newState;
    } 

    
}
