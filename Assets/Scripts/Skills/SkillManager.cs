using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

// 技能管理器，单例模式管理技能，直接调用管理器实例下的技能并使用
public class SkillManager : MonoBehaviour
{
    public static SkillManager instance;
    public DashSkill dash {get; private set;}
    public CloneSkill clone {get; private set;}
    public SwordSkill sword {get; private set;}
    public BlackholeSkill blackhole {get; private set;}

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        dash = GetComponent<DashSkill>();
        clone = GetComponent<CloneSkill>();
        sword = GetComponent<SwordSkill>();
        blackhole = GetComponent<BlackholeSkill>();
    }
}
