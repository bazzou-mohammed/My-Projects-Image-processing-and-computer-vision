using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed = 10f;
    private Transform target;
    private int waypointIndex = 0;
    void Start(){
        target = Waypoints.points[0];
    }
    private void Update(){
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * Speed * Time.deltaTime, Space.World);
        if(Vector3.Distance(transform.position, target.position)<= 0.3f){
            GetNextWaypoint();
        }
    }
    private void GetNextWaypoint(){
        if(waypointIndex >= Waypoints.points.Length -1){
           Destroy(gameObject);
           return;
        }
        waypointIndex++;
        target = Waypoints.points[waypointIndex];

    }
}
