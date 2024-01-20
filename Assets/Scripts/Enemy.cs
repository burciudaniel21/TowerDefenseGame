using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public float speed;
    public float startSpeed = 10f;
    public float startHp;
    public float currentHp;
    private float currentScaledUpHp;
    public int moneyGain = 50;
    [SerializeField] GameObject enemyDeathEffet;
    [SerializeField] Image enemyHpBar;

    private void Start()
    {
        speed = startSpeed;
        Spawn();
        currentScaledUpHp = currentHp;
    }

    private void Spawn()
    {
        currentHp = (float)(startHp * (1 + (PlayerStats.roundsSurvived * 0.1)));
    }

    public void TakeDamage(float damage)
    {
        currentHp -= damage;
        enemyHpBar.fillAmount = currentHp / currentScaledUpHp;
        if (currentHp <= 0)
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
