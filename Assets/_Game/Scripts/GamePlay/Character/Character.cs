using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected Rigidbody rb;
    [SerializeField] protected float moveSpeed;
    [SerializeField] Animator anim;
    protected string currentAnimName = CacheString.ANIM_IDLE;

    protected Character mainTarget;
    protected List<Character> otherTarget = new List<Character>();

    [SerializeField] protected WeaponType characterWeaponType;
    protected WeaponData characterWeaponData;

    private void Start()
    {
        ChangeAnim(CacheString.ANIM_IDLE);
        characterWeaponData = DataManager.Ins.GetWeaponData(characterWeaponType);
        
    }

    private void SpawnBullet()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(CacheString.BOT_TAG) || other.CompareTag(CacheString.PLAYER_TAG))
        {
            Character target = other.GetComponent<Character>();     
            if(target != this)
            {
                
                if(mainTarget == null)
                {
                    mainTarget = target;
                    //Debug.Log("Find target");
                }
                else
                {
                    otherTarget.Add(target);
                    //Debug.Log("Add bot to list");
                }
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer(CacheString.CHARACTER_LAYER))
        {
            //TO DO: Delete target form list
            Character targetout = other.GetComponent<Character>();
            
            if(mainTarget == targetout)
            {
                if(otherTarget.Count > 0)
                {
                    mainTarget = otherTarget[0];
                    otherTarget.RemoveAt(0);
                }
                else
                {
                    mainTarget = null;
                }
                
            }
            else
            {
                otherTarget.Remove(targetout);
            }

        }
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
