using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Hand : MonoBehaviour
{
    Animator animator;
    SkinnedMeshRenderer mesh;
    private float gripTarget;
    private float triggerTarget;
    private float gripCurrent;
    private float triggerCurrent;
    public float speed;
    private string animatorGripParam = "Grip";
    private string animatorTriggerParam = "Trigger";

    void Start()
    {
       animator = GetComponent<Animator>(); 
       mesh = GetComponentInChildren<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    //A
    void Update()
    {
        AnimateHand();
    }
    
    internal void SetGrip(float value)
    {
        gripTarget = value;
    }
    internal void SetTrigger(float value)
    {
        triggerTarget = value;
    }
    void AnimateHand()
    {
        if(gripCurrent != gripTarget)
        {
            gripCurrent = Mathf.MoveTowards(gripCurrent, gripTarget, Time.deltaTime * speed);
            animator.SetFloat(animatorGripParam, gripCurrent);
        }
        if(triggerCurrent != triggerTarget)
        {
            triggerCurrent = Mathf.MoveTowards(triggerCurrent, triggerTarget, Time.deltaTime * speed);
            animator.SetFloat(animatorTriggerParam, triggerCurrent);
        }
    }
    public void ToggleVisibility()
    {
        mesh.enabled = !mesh.enabled;
    }
}
