using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Statistics")]
    [SerializeField] private int maxHealth;
    private int currentHealth;
    private SelfDestructor selfDestructor;
    [SerializeField] protected AudioSource[] playerHurtSounds;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float inVulnerabilityDuration;

    private bool inVulnerable;

    [SerializeField] private TMP_Text healthText;

    public UnityEvent OnPlayerDeath;

    [SerializeField] private ScoreManager scoreRef;
    [SerializeField] private Image damageEffect;

    private bool hasDied = false;

    private void Start()
    {
        //Initialize Health
        currentHealth = maxHealth;
    }

    public void DecreaseHealth(int amount)
    {
        if(!inVulnerable)
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
        inVulnerable = true;

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
        inVulnerable = false;
    }


    public void Die()
    {
        if (hasDied) return;

        hasDied = true;
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
