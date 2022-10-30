using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem; 

public class AnimateHand : MonoBehaviour
{
    public InputActionProperty pinchAnimation;
    public InputActionProperty gripAnimation;
    public Animator handAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float triggerVal = pinchAnimation.action.ReadValue<float>();
        handAnimator.SetFloat("Trigger", triggerVal);

        float gripVal = gripAnimation.action.ReadValue<float>();
        handAnimator.SetFloat("Grip", gripVal);
    }
}
