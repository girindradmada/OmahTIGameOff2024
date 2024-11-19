using UnityEngine;
using UnityEngine.UI;

public class HealthBarHandler : MonoBehaviour
{
    [SerializeField] GameManager playerStats;
    [SerializeField] Image healthBar;

    public void takeDamage (float damage)
    {
        playerStats.healthPoints -= damage;
        healthBar.fillAmount = playerStats.healthPoints / playerStats.maxHP;
    }
}
