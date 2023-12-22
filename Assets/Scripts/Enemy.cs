using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public float speed;
    public float startSpeed = 10f;
    public float startHp;
    private float hp;
    public int moneyGain = 50;
    [SerializeField] GameObject enemyDeathEffet;
    [SerializeField] Image enemyHpBar;

    private void Start()
    {
        speed = startSpeed;
        hp = startHp;
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        enemyHpBar.fillAmount = hp / startHp;
        if (hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        PlayerStats.Money += moneyGain;
        GameObject effect = Instantiate(enemyDeathEffet, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        WaveSpawner.enemiesAlive--;
    }

    public void Slow( float slowPercentage)
    {
        speed = startSpeed * (1f - slowPercentage);
    }
  
}
