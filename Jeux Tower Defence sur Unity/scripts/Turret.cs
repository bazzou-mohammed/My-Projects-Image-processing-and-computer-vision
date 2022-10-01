using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    public float range = 15f;
    public string enmeyTag = "Enemy";

    public Transform PartToRotate;
    private float turnSpeed = 6.5f;
    public float fireRate = 1f;
    public float fireCountdown  = 0f;
    public GameObject BulletPrefab;
    public Transform firePoint;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget(){
        GameObject[] ennemies = GameObject.FindGameObjectsWithTag(enmeyTag); 
        float ShortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in ennemies){
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < ShortestDistance){
                ShortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if(nearestEnemy != null && ShortestDistance <= range){
           target = nearestEnemy.transform;
        }
        else 
        {
            target = null;
        }
    }  
    void Update()
    {
       if (target == null){
           return;
       }
       Vector3 dir = target.position - transform.position;
       Quaternion lookRotation = Quaternion.LookRotation(dir);
       Vector3 rotation = Quaternion.Lerp(PartToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
       PartToRotate.rotation = Quaternion.Euler(0f, rotation.y , 0f);

       if(fireCountdown <= 0f){
           Shoot();
           fireCountdown = 1/fireRate;
       }
       fireCountdown -= Time.deltaTime;
    }
     void Shoot(){
          GameObject BulletGo = (GameObject)Instantiate(BulletPrefab, firePoint.position, firePoint.rotation);
          Bullet bullet = BulletGo.GetComponent<Bullet>();

          if(bullet != null){
              bullet.Seek(target);
          }
     }

    private void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    
    }
}
