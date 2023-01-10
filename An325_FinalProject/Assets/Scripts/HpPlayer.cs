using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HpPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public GameManager gameManager;//เรียกใช้ Script GameManager
    public Animator animator;
    [SerializeField] private int maxHp = 5;
    [SerializeField] private int currentHp;

    public TextMeshProUGUI textHp;


    private void Start()
    {
        currentHp = maxHp;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Water")
        {
            currentHp = currentHp - 5;
        }
        if (other.gameObject.tag == "Enemy")
        {
            animator.SetTrigger("IsHit");
            Debug.Log("Ooop");
            currentHp--;
        }
    }

    private void Update()
    {
        textHp.text = "X" + currentHp;
        if (currentHp <= 0)
        {

            Debug.Log("I'm Dead");
            gameManager.GameOver();
            gameManager.RestartButton.SetActive(true);
            //animator.SetTrigger("IsDead");
            Destroy(this.gameObject);
        }

    }

    IEnumerator secondHit(float secondHit)
    {
        yield return new WaitForSeconds(secondHit);
        //this.GetComponent<Player_Movement>().enabled = true;

    }
}

