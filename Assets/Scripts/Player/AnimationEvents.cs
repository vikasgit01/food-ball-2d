using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    private Animator _animator;
    private int _kickAnimatorId;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _kickAnimatorId = Animator.StringToHash("Kick");
    }

    public void ResetAnimation()
    {
        _animator.SetBool(_kickAnimatorId, false);
    }
}
