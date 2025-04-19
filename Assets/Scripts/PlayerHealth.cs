using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public int maxHealth = 3;
    [SerializeField] public int currentHealth;

    GameManager gm;

    public int Health
    {
        get { return currentHealth; }
        set
        {
            currentHealth = Mathf.Clamp(value, 0, maxHealth);

            if (currentHealth <= 0)
            {   
                gameObject.SetActive(false);
                GameManager.Instance.GameOver();
            }
        }
    }

    private void Start()
    {
        currentHealth = maxHealth;
        gm = GameManager.Instance;
    }

    public void TakeDamage(int damageAmount)
    {
        if (gm.isFired)
        {
            if(Health - (damageAmount + 1) <= 0 && gm.isShield){
                damageAmount-=1;
                gm.EndShield();
            }

            Health -= damageAmount + 1;
        }
        else
        {
            if(Health - damageAmount <= 0 && gm.isShield){
                damageAmount-=1;
                gm.EndShield();
            }
                

            Health -= damageAmount;
        }

    }

    public void Heal(int healthAmount)
    {
        Health += healthAmount;
    }

}
