using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodDollMgr : MonoBehaviour {


    public int sortingOrder = 0;
    public int sortingOrderOrigine = 0;
    public SpriteRenderer[] SpriteGroup;

    Animator Animator;
    // Use this for initialization
    void Start () {
        Animator = this.transform.GetComponent<Animator>();
        SpriteGroup = this.transform.GetComponentsInChildren<SpriteRenderer>(true);

        spriteOrderController();

    }


    void spriteOrderController()
    {
        sortingOrder = Mathf.RoundToInt(this.transform.position.y * 100);
        //Debug.Log("y::" + this.transform.position.y);
        //  Debug.Log("sortingOrder::" + sortingOrder);
        for (int i = 0; i < SpriteGroup.Length; i++)
        {

            SpriteGroup[i].sortingOrder = sortingOrderOrigine - sortingOrder;

        }

    }

    public void  SwordHitted()
    {
        Animator.Play("Hit");
    }
}
