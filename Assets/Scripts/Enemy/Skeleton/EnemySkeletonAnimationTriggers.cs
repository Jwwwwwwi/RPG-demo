using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 动画触发器事件
public class EnemySkeletonAnimationTriggers : MonoBehaviour
{
    private EnemySkeleton enemySkeleton => GetComponentInParent<EnemySkeleton>();

    private void AnimationTrigger()
    {
        enemySkeleton.AnimationFinishTrigger();
    }

    // 受击检测，造成伤害
    private void AttackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(enemySkeleton.attackCheck.position, enemySkeleton.attackCheckRadius);

        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Player>() != null)
                hit.GetComponent<Player>().Damage();
        }
    }

    // 开启关闭允许反击窗口
    private void OpenCounterAttackWindow() => enemySkeleton.OpenCounterAttackWindow();
    private void CloseCounterAttackWindow() => enemySkeleton.CloseCounterAttackWindow();

}
