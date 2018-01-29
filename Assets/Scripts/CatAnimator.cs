using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAnimator : MonoBehaviour
{
    Animator anim;

    // Use this for initialization
    protected void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void CatAttack()
    {
        anim.SetTrigger("Attack");
    }

    void CatGroom()
    {
        anim.SetTrigger("Groom");

    }

    void CatLeave()
    {
        anim.SetTrigger("Leave");
    }
}
