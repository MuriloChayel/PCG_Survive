using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mini : EnemyClass
{
    Vector2 direction;
    private Vector2 targetPos;

    public float velocity, radius;
    public float attackRange;
    
    public GameObject bullet;
    public float bulletSpeed;
    public types type;
    private void Start(){
        base.InitRandomPosition(transform.position);
    }
    private void Update(){
        targetPos = base.GetTargetByLowerDistance(transform.position, radius) ;
        if( targetPos !=  Vector2.zero)
            base.follow = true;
        else
            base.follow = false;
    }
    private void FixedUpdate(){
        if(!base.follow)
            base.Patrol(transform.position,velocity);
        else
            base.Follow(transform.position, base.GetTargetByLowerDistance(transform.position, radius), velocity, attackRange, type, bullet, bulletSpeed);
        base.SetScale(transform.position.x,targetPos.x);
    }
    private void OnDrawGizmosSelected(){
        direction = base.GetDirectionToTarget(transform.position,base.GetTargetByLowerDistance(transform.position, radius));        
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere (transform.position, radius);
        Gizmos.DrawRay(transform.position,direction);
    }
  //public override void Follow(Vector3 pos, Vector3 targetPos, float velocity){}
}
