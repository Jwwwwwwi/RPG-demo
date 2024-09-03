using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 复制体控制器，用于控制生成的复制体位置、颜色等信息
public class CloneSkillController : MonoBehaviour
{
    private SpriteRenderer sr;
    private Animator anim;
    [SerializeField] private float colorLoosingSpeed;

    private float cloneTimer;
    [SerializeField] private Transform attackCheck;
    [SerializeField] private float attackCheckRadius = .8f;
    private Transform closestEnemy;

    public void SetupClone(Transform _newtransform, float _cloneDuration, bool _canAttack, Vector3 _offset, Transform _closestEnemy)
    {
        
        if (_canAttack)
            anim.SetInteger("AttackNumber", Random.Range(1,4));
        transform.position = _newtransform.position + _offset;
        cloneTimer = _cloneDuration;
        closestEnemy = _closestEnemy;

        FaceClosestTarget();

    }

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    
    private void Update()
    {
        cloneTimer -= Time.deltaTime;
        if (cloneTimer < 0)
        {
            sr.color = new Color(1, 1, 1, sr.color.a - (Time.deltaTime * colorLoosingSpeed));
            if (sr.color.a < 0)
                Destroy(gameObject);
        }

    }

    private void AnimationTrigger()
    {
        cloneTimer = -.1f;
    }

    private void AttackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackCheck.position, attackCheckRadius);

        foreach(var hit in colliders)
        {
            if (hit.GetComponent<Enemy>() != null)
                hit.GetComponent<Enemy>().Damage();
        }
    }

    private void FaceClosestTarget()
    {
        
        if (closestEnemy != null)
        {
            if (transform.position.x > closestEnemy.position.x)
                transform.Rotate(0, 180, 0);
        }
    }


}
