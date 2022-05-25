using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyClass : MonoBehaviour
{
    private Vector2 randomPos;
    private Vector2 p;

    
    public LayerMask targetLayer;
    public bool follow, shoot;
    public float minDistance;

    public bool atk;
    public enum types{
        shoot,
        meelee,
    }
    //INIT FIRST DIRECTION 
    public virtual void InitRandomPosition(Vector2 pos){
        randomPos = new Vector2 (Random.Range(pos.x - 10, pos.x + 10),Random.Range(pos.y - 10, pos.y + 10));
    }
    //FOLLOW TARGET
    public virtual void Follow(Vector2 pos, Vector2 targetPos, float velocity, float attackRange, types type, GameObject projectile, float bulletSpeed){
        
        if(Vector2.Distance(pos, targetPos) < minDistance + .5f){  
            if(!atk && type == types.meelee)
                StartCoroutine(AttackRotine(pos, targetPos, attackRange));
            else if(type == types.meelee)
                Attack(pos,targetPos);

            if(!shoot && type == types.shoot){
                StartCoroutine(ShootRotine(pos,targetPos,projectile, bulletSpeed));
            }
        }    
        else
        {
            transform.position = Vector3.Lerp(pos, targetPos - GetDirectionToTarget(pos, targetPos).normalized * minDistance , velocity / 100);
        }
    }
    //DETECT TARGET
    public virtual Vector3 GetTargetByLowerDistance(Vector3 pos, float radius){
        if(Physics2D.OverlapCircle(pos, radius) != null) //returns any tarnsform found inside the radius
            return Physics2D.OverlapCircle(pos, radius, targetLayer).transform.position;
        else{
            return Vector2.zero;
        }
    }
    // PATROL MOVEMENT
    public virtual void Patrol(Vector2 pos, float velocity){
        if(Vector2.Distance(pos, randomPos) < .5f)        
            randomPos = new Vector2 (Random.Range(pos.x - 10, pos.x + 10),Random.Range(pos.y - 10, pos.y + 10));
        transform.position = Vector2.Lerp(pos,randomPos,velocity/100);
    }
    public virtual Vector2 GetDirectionToTarget(Vector2 pos, Vector2 targetPos){
        Vector2 dir = (targetPos - pos);
        return dir;
    }
    public virtual void Attack(Vector2 pos, Vector2 targetPos){
        transform.position = Vector2.Lerp(transform.position, p, .15f);
    }
    public virtual void SetScale(float posX, float targetPosX){
        transform.localScale = (posX < targetPosX)?  new Vector3(1,1,1) : (posX > targetPosX)? new Vector3(-1,1,1) : transform.localScale;
    }
    IEnumerator AttackRotine(Vector2 pos, Vector2 targetPos, float attackRange){
        atk = true;
        p = (Vector2) transform.position + GetDirectionToTarget(pos, targetPos).normalized * minDistance * attackRange;
        yield return new WaitForSeconds(3);
        atk = false;
    }
    IEnumerator ShootRotine(Vector2 pos, Vector2 targetPos,GameObject pref, float speed){
        shoot = true;
        GameObject bullet =  Instantiate(pref, transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().Setup(speed, GetDirectionToTarget(pos,targetPos));
        yield return new WaitForSeconds(0.3f);
        shoot = false;
    }
}
