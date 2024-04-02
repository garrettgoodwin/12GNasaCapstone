using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.U2D.Animation;
using TMPro;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Animator playerMovementAnims;

    [Header("Statistics")]
    [SerializeField] private int maxHealth;
    private int currentHealth;
    private SelfDestructor selfDestructor;
    [SerializeField] protected AudioSource[] playerHurtSounds;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float inVulnerabilityDuration;

    public bool inVulnerable;

    [SerializeField] private TMP_Text healthText;


    public UnityEvent OnPlayerDeath;



    [SerializeField] private ScoreManager scoreRef;
    [SerializeField] private Image damageEffect;

    

    private void Start()
    {
        //initialize Vulnerability
        playerMovementAnims.SetBool("isInvulnerable", false);

        //Initialize Health
        currentHealth = maxHealth;
    }
    
    public void DecreaseHealth(int amount)
    {

        if(!playerMovementAnims.GetBool("isInvulnerable") && !playerMovementAnims.GetBool("shieldUp"))
        {
            currentHealth -= amount;
            int randNumb = Random.Range(0, playerHurtSounds.Length);
            Instantiate(playerHurtSounds[randNumb]);
            healthText.text = currentHealth.ToString();
            StartCoroutine(FreezeTime(.05f));
            StartCoroutine(InvulnerabilityEffect(inVulnerabilityDuration));

            StartCoroutine(DamageEffectCoroutine());
            if (currentHealth <= 0)
            {
                if(damageEffect.gameObject.activeInHierarchy)
                {
                    damageEffect.gameObject.SetActive(false);
                }

                Die();
            }
        }
        else if (playerMovementAnims.GetBool("shieldUp"))
        {
            StartCoroutine(shieldHit(59));
        }

    }

    IEnumerator shieldHit(float duration)
    {
        float timer = 0;
        
        //sets player invulnerable and then recharges
        playerMovementAnims.SetBool("shieldUp", false);
        playerMovementAnims.SetBool("isInvulnerable", true);
        float colorFlickerTime = 1f;

        //invulnerability timer
        float invTime = 1;
        while (timer < invTime)
        {
            yield return new WaitForSecondsRealtime(colorFlickerTime);
            timer++;
        }
        playerMovementAnims.SetBool("isInvulnerable", false);

        //recharging shield timer
        timer = 0;
        while (timer < duration)
        {
            yield return new WaitForSecondsRealtime(colorFlickerTime);
            timer++;
        }
        playerMovementAnims.SetBool("shieldUp", true);
        print("shieldUP");

    }
    private IEnumerator FreezeTime(float timeDuration)
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(timeDuration);
        Time.timeScale = 1f;
    }

    private IEnumerator DamageEffectCoroutine()
    {
        damageEffect.gameObject.SetActive(true);
        yield return new WaitForSeconds(.15f);
        damageEffect.gameObject.SetActive(false);

    }

    public void IncreaseHealth(int amount)
    {
        //if (currentHealth < maxHealth)
        //{
            currentHealth += amount;
           // if (currentHealth > maxHealth)
            //{
               // currentHealth = maxHealth;
           // }
             healthText.text = currentHealth.ToString();

        //}
    }
    


    IEnumerator InvulnerabilityEffect(float invulnerabilityTime)
    {
        playerMovementAnims.SetBool("isInvulnerable", true);
        float timer = 0;
        float colorFlickerTime = .1f;

        while(timer < inVulnerabilityDuration)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(colorFlickerTime);
            
            //spriteRenderer.color = Color.red;
            //yield return new WaitForSeconds(colorFlickerTime);
            //spriteRenderer.color = Color.white;
            //yield return new WaitForSeconds(colorFlickerTime);
            timer += (colorFlickerTime);
        }

        spriteRenderer.enabled = true;
        playerMovementAnims.SetBool("isInvulnerable", false); 
        
    }


    public void Die()
    {
        //Doesnt technically need to happen if the scene is just reset
        //selfDestructor.DestroyOneself();
        OnPlayerDeath?.Invoke();

        int highscore = PlayerPrefs.GetInt("HighScore", 0);

        if(scoreRef.score > highscore)
        {
            PlayerPrefs.SetInt("HighScore", scoreRef.score);
            PlayerPrefs.Save();
        }
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
