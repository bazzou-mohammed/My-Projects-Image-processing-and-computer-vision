using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float Speed = 70f;
    public GameObject impactEffect;

    public void Seek(Transform _target){
        target = _target;

    }


    // Update is called once per frame
    void Update()
    {
        if(target == null){
            Destroy(gameObject);
        }
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = Speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame){
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }
    void HitTarget(){
            GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(effectIns, 2f);
            Destroy(target.gameObject);
            Destroy(gameObject);
    }
}
