using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected Rigidbody rb;
    [SerializeField] protected float moveSpeed;
    [SerializeField] Animator anim;
    protected string currentAnimName = CacheString.ANIM_IDLE;

    protected Character mainTarget;
    protected List<Character> listTarget = new List<Character>();

    [SerializeField] protected WeaponType characterWeaponType;
    protected WeaponData characterWeaponData;

    private void Start()
    {
        ChangeAnim(CacheString.ANIM_IDLE);
        characterWeaponData = DataManager.Ins.GetWeaponData(characterWeaponType);

    }

    private void Update()
    {
        FindClosestTarget(transform.position, listTarget);
        if (mainTarget != null)
        {
            transform.LookAt(mainTarget.transform.position);

        }
    }

    private void Attack()
    {

    }


    private void SpawnBullet()
    {

    }

    //Find close target form list
    private void FindClosestTarget(Vector3 playerPosition, List<Character> listTarget)
    {
        float closestDistance = Mathf.Infinity;
        if (listTarget.Count > 0)
        {
            foreach (Character target in listTarget)
            {
                float distance = Vector3.Distance(playerPosition, target.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    mainTarget = target;
                }
            }
        }
        else
        {
            mainTarget = null;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        //Add target on list when target enter range
        if (other.CompareTag(CacheString.BOT_TAG) || other.CompareTag(CacheString.PLAYER_TAG))
        {
            Character target = other.GetComponent<Character>();
            if (target != this)
            {
                listTarget.Add(target);
                //Take firt enemy you collect to main target
                //If enmy in range > 1, add enemy to list target
                //if(this.mainTarget == null)
                //{
                //    this.mainTarget = target;
                //    //Debug.Log("Find target");
                //}
                //else
                //{
                //    listTarget.Add(target);
                //    //Debug.Log("Add bot to list");
                //}
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        //Remove target form list when target exit range
        if (other.gameObject.layer == LayerMask.NameToLayer(CacheString.CHARACTER_LAYER))
        {
            Character targetout = other.GetComponent<Character>();
            listTarget.Remove(targetout);
            //Enemy exit range will be remove form list or main target
            //if(mainTarget == targetout)
            //{
            //    if(listTarget.Count > 0)
            //    {
            //        mainTarget = listTarget[0];
            //        listTarget.RemoveAt(0);
            //    }
            //    else
            //    {
            //        mainTarget = null;
            //    }
            //}
            //else
            //{
            //    listTarget.Remove(targetout);
            //}
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
