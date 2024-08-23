using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 冲刺技能，通过Skill的CanUseSkill函数判断技能cd是否可以使用，之前实现在了Player上，在此不作更改
public class DashSkill :Skill
{
    public override void UseSkill()
    {
        base.UseSkill();
        Debug.Log("dashskill");
    }
}
