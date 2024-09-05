using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// 复制技能，在冲刺的时候留下克隆体和残影图像
public class CloneSkill : Skill
{
    [Header("Clone info")]
    [SerializeField] private GameObject clonePrefab;
    [SerializeField] private float cloneDuration;
    [Space]
    [SerializeField] private bool canAttack;

    [SerializeField] private bool createCloneOnDashStart;
    [SerializeField] private bool createCloneOnDashOver;
    [SerializeField] private bool createCloneOnCounterAttack;

    [Header("Clone can duplicate")]
    [SerializeField] private bool canDuplicateClone;
    [SerializeField] private float chanceToDuplicate;

    [Header("Crystal instead of clone")]
    public bool crystalInsteadOfClone;

    public void CreatClone(Transform _clonePosition, Vector3 _offset)
    {
        if (crystalInsteadOfClone)
        {
            SkillManager.instance.crystal.CreateCrystal();
            return;
        } 

        GameObject newClone = Instantiate(clonePrefab);
        // 先设定好克隆体位置，再让他面向最近的敌人
        CloneSkillController newCloneScript = newClone.GetComponent<CloneSkillController>();
        newCloneScript.SetupClone(_clonePosition, cloneDuration, canAttack, _offset, canDuplicateClone, chanceToDuplicate, player);
        newCloneScript.FaceClosestTarget(FindClosestEnemy(newClone.transform));
    }

    public void CreatCloneOnDashStart()
    {
        if (createCloneOnDashStart)
        {
            CreatClone(player.transform, Vector3.zero);
        }
    }

    public void CreatCloneOnDashOver()
    {
        if (createCloneOnDashOver)
        {
            CreatClone(player.transform, Vector3.zero);
        }
    }

    public void CreateCloneOnCounterAttack(Transform _enemyTransform)
    {
        if (createCloneOnCounterAttack)
            StartCoroutine(CreateCloneWithDelay(_enemyTransform, new Vector3(1 * player.facingDir, 0)));
    }

    private IEnumerator CreateCloneWithDelay(Transform _transform, Vector3 _offset)
    {
        yield return new WaitForSeconds(.4f);
            CreatClone(_transform, _offset);
    }

}
