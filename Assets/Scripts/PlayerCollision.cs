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
                if (!gm.isAppled)
                {
                    gm.playerHealth.TakeDamage(1);
                    Destroy(other.gameObject);
                }
                else
                {
                    Destroy(other.gameObject);
                }

                break;


            case "Bear":
                if (!gm.isHoneyed)
                {
                    gm.playerHealth.TakeDamage(1);
                    Destroy(other.gameObject);
                }
                else
                {
                    Destroy(other.gameObject);
                    GameManager.Instance.currentScore += gm.killScore;
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
                Destroy(other.gameObject);
                gm.playerHealth.TakeDamage(1);
                break;

            case "Fire":
                Destroy(other.gameObject);
                gm.playerHealth.TakeDamage(1);
                gm.Fired();
                break;

            case "Dragon":
                Destroy(other.gameObject);
                gm.playerHealth.TakeDamage(1);
                break;

            case "Knight":
                Destroy(other.gameObject);
                gm.playerHealth.TakeDamage(2);
                break;
            case "Sword":
                Destroy(other.gameObject);
                gm.playerHealth.TakeDamage(1);
                break;
            default:
                break;
        }


    }


}
