using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 动画触发器事件
public class PlayerAnimationTriggers : MonoBehaviour
{
   private Player player => GetComponentInParent<Player>();

   private void AnimationTrigger()
   {
        player.AnimationTrigger();
   }

   private void AttackTrigger()
   {
      Collider2D[] colliders = Physics2D.OverlapCircleAll(player.attackCheck.position, player.attackCheckRadius);

      foreach(var hit in colliders)
      {
         if (hit.GetComponent<Enemy>() != null)
            hit.GetComponent<Enemy>().Damage();
      }
   }
   
   private void ThrowSword()
   {
      SkillManager.instance.sword.CreatSword();
   }

}
