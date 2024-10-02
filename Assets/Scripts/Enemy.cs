
using UnityEngine;

public class Enemy : MonoBehaviour
{
public float speed = 10f;

private Transform target;

private int waypointIndex = 0;

void Start() {
    target = Wapyoints.points[0];
}

void Update() {
    Vector3 dir = target.position - transform.position;
    transform.Translate(dir.normalized *  speed * Time.deltaTime, Space.World);

    if(Vector3.Distance(transform.position, target.position) <= 0.3f) {
        GetNextWaypoint();
    };
}

private void GetNextWaypoint(){
    if(waypointIndex >= Wapyoints.points.Length - 1) {
        Destroy(gameObject);
        return;
    }
    waypointIndex++;
    target = Wapyoints.points[waypointIndex];
}
}
