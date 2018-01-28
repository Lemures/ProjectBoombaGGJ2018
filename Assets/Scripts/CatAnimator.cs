using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAnimator : MonoBehaviour {

    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
    void CatAttack()
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

    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CatAttack();
        }
    }*/
}
