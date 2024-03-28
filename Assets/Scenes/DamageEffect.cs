using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffect : MonoBehaviour
{

    [SerializeField] private GameObject damageEffect;

    public void DamageEffectTrigger()
    {
        StartCoroutine(DamageEffectCoroutine());
    }
    
    private IEnumerator DamageEffectCoroutine()
    {
        damageEffect.gameObject.SetActive(true);
        yield return new WaitForSeconds(.15f);
        damageEffect.gameObject.SetActive(false);
    }
}
