using UnityEngine;
using TMPro;
using Unity.VisualScripting;
public class PlayerCollision : MonoBehaviour
{


    GameManager gm;

    private void Start()
    {

        gm = GameManager.Instance;

        GameManager.Instance.onPlay.AddListener(ActivatePlayer);
    }

    private void ActivatePlayer()
    {
        gameObject.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        switch (other.transform.tag)
        {
            case "Bush":

                if (gm.isAppled)
                {
                    Destroy(other.gameObject);
                }


                else
                {
                    gm.playerHealth.TakeDamage(1);
                    Destroy(other.gameObject);
                }

                break;


            case "Bear":

                if (gm.isHoneyed)
                {
                    Destroy(other.gameObject);
                    gm.currentScore += gm.killScore;
                }

                else if (gm.isSworded)
                {
                    Destroy(other.gameObject);
                    gm.playerHealth.Heal(1);
                    gm.EndSworded();
                }

                else
                {
                    gm.playerHealth.TakeDamage(1);
                    Destroy(other.gameObject);
                }

                break;


            case "Honey":
                Destroy(other.gameObject);
                gm.Honeyed();
                break;

            case "Apple":
                Destroy(other.gameObject);
                gm.Appled();
                break;

            case "Bat":
                if (gm.isSworded)
                {
                    Destroy(other.gameObject);
                    gm.playerHealth.Heal(1);
                    gm.EndSworded();
                }

                else
                {
                    gm.playerHealth.TakeDamage(1);
                    Destroy(other.gameObject);
                }

                break;

            case "Fire":

                {
                    Destroy(other.gameObject);
                    gm.Fired();
                }

                break;

            case "Dragon":
                if (gm.isSworded)
                {
                    Destroy(other.gameObject);
                    gm.playerHealth.Heal(1);
                    gm.EndSworded();
                }

                else
                {
                    gm.playerHealth.TakeDamage(1);
                    Destroy(other.gameObject);
                }

                break;

            case "Knight":
                if (gm.isCrowned)
                {
                    Destroy(other.gameObject);
                    gm.currentScore += gm.killScore;
                }

                else if (gm.isSworded)
                {
                    Destroy(other.gameObject);
                    gm.playerHealth.Heal(1);
                    gm.EndSworded();
                }

                else
                {
                    gm.playerHealth.TakeDamage(2);
                    Destroy(other.gameObject);
                }

                break;

            case "Sword":

                if (gm.isCrowned)
                {
                    Destroy(other.gameObject);
                    gm.currentScore += gm.killScore;
                }
                else if (gm.isSworded)
                {
                    Destroy(other.gameObject);
                    gm.playerHealth.Heal(1);
                    gm.EndSworded();
                }

                else
                {
                    gm.playerHealth.TakeDamage(1);
                    Destroy(other.gameObject);
                }

                break;

            case "SwordBuff":
                gm.Sworded();
                Destroy(other.gameObject);
                break;

            case "Crown":
                gm.Crowned();
                Destroy(other.gameObject);
                break;

            case "Devil":
               
                if (gm.isSworded)
                {
                    Destroy(other.gameObject);
                    gm.playerHealth.Heal(1);
                    gm.EndSworded();
                }

                else
                {
                    gm.playerHealth.TakeDamage(2);
                    Destroy(other.gameObject);
                }

                break;

            case "DevilChild":
               
                if (gm.isSworded)
                {
                    Destroy(other.gameObject);
                    gm.playerHealth.Heal(1);
                    gm.EndSworded();
                }

                else
                {
                    gm.playerHealth.TakeDamage(1);
                    Destroy(other.gameObject);
                }

                break;

            case "Wings":
                gm.Fly();
                Destroy(other.gameObject);
                break;
            
            case "Shield":
                gm.Shield();
                Destroy(other.gameObject);
                break;

            default:
                break;
        }


    }


}
