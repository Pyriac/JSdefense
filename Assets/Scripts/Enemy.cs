using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
public float speed = 10f;
public float startHealth = 100;
public int value = 50;
public GameObject deathEffect;
public Image healthBar;

private float health;
private Transform target;
private int waypointIndex = 0;
private bool isDead = false;

void Start() {
    target = Wapyoints.points[0];
    health = startHealth;
}

public void takeDamage(int amount)
{
    health -= amount;
    healthBar.fillAmount = health / startHealth;

    if (health <= 0 && !isDead)
    {   
      
        Die();
    }
}

void Die()
{
    isDead = true;
    GameObject deathParticles = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
    Destroy(deathParticles, 2f);
    Destroy(gameObject);
    WaveSpawner.EnemiesAlive--;
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
     WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
   
}
}
