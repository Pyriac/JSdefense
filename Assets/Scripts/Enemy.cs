
using UnityEngine;

public class Enemy : MonoBehaviour
{
public float speed = 10f;

public int health = 100;

public int value = 50;

public GameObject deathEffect;

private Transform target;

private int waypointIndex = 0;

void Start() {
    target = Wapyoints.points[0];
}

public void takeDamage(int amount)
{
    health -= amount;
    if (health <= 0)
    {   
      
        Die();
    }
}

void Die()
{
    GameObject deathParticles = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
    Destroy(deathParticles, 2f);
    Destroy(gameObject);
    
    PlayerStats.money += value;
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
        EndPath();
        return;
    }
    waypointIndex++;
    target = Wapyoints.points[waypointIndex];
}

private void EndPath()
{
    PlayerStats.lives --;
        Destroy(gameObject);
}
}
