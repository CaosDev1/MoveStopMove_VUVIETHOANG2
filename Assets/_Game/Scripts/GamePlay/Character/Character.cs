using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected Rigidbody rb;
    [SerializeField] protected float moveSpeed;
    [SerializeField] Animator anim;
    private string currentAnimName = CacheString.ANIM_IDLE;

    private void Start()
    {
        ChangeAnim(CacheString.ANIM_IDLE);
    }

    public void ChangeAnim(string animName)
    {
        if (currentAnimName != animName)
        {
            anim.ResetTrigger(currentAnimName);
            currentAnimName = animName;
            anim.SetTrigger(currentAnimName);
        }
    }
}
