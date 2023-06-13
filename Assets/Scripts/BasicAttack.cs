using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{
    
    public float BasicAttackSpeed;
    public float Radius;
    public BasicBullet Bullet;
    private float timer;
  

  
    void Update()
    {
        DoShoot();
    }
    void DoShoot()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            
            Collider2D[] colliders = Physics2D.OverlapCircleAll(this.transform.position , Radius);
            Collider2D nearestCollider = null;
            float minSqrDistance = Mathf.Infinity;
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].CompareTag("Enemy"))
                {
                    float sqrDistanceToCenter = (this.transform.position - colliders[i].transform.position).sqrMagnitude;
                    if (sqrDistanceToCenter < minSqrDistance)
                    {
                        minSqrDistance = sqrDistanceToCenter;
                        nearestCollider = colliders[i];
                        Bullet.Target = nearestCollider.gameObject;
                        Instantiate(Bullet,this.transform.position,Quaternion.identity);
                        timer = BasicAttackSpeed;
                        return;
                    }
                }
            }
           
           
        }
    }
}
