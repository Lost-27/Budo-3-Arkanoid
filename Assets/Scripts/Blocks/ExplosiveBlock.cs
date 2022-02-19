using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBlock : Block
{
    #region Variables

    [Header(nameof(ExplosiveBlock))] 
    [SerializeField] private float _radius;

    [SerializeField] private LayerMask _layerMask;
    

    #endregion

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }

    protected override void ApplyInternalActions()
    {
        base.ApplyInternalActions();
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _radius, _layerMask);

        foreach (Collider2D col in colliders)
        {
            if (col.gameObject == gameObject)
                continue;

            Block des = col.gameObject.GetComponent<Block>(); //?
            des.GetHit();
        }
    }
}