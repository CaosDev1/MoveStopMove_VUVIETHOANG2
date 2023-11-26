using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private DynamicJoystick joystick;

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(joystick.Horizontal * moveSpeed, rb.velocity.y, joystick.Vertical * moveSpeed);

        if (Mathf.Abs(joystick.Horizontal) > 0.1f || Mathf.Abs(joystick.Vertical) > 0.1f)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
            ChangeAnim(CacheString.ANIM_RUN);
        }
        else
        {
            ChangeAnim(CacheString.ANIM_IDLE);
        }
    }
}
