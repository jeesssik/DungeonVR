using UnityEngine;
using System;

public class VRPlayerLogic : MonoBehaviour, IDamagable
{
    [Header("Vida del jugador")]
    [SerializeField] private int maxLife = 100;
    private int currentLife;

    [Header("Audio Opcional")]
    [SerializeField] private AudioEvent deathSound;
    [SerializeField] private AudioEvent receiveHitSound;

    // Eventos públicos para UI u otros sistemas
    public Action<int, int> OnLifeUpdated;
    public Action OnPlayerDeath;

    private bool isDead = false;

    private void Start()
    {
        currentLife = maxLife;
        OnLifeUpdated?.Invoke(currentLife, maxLife);
    }

    public void Damage(int damageAmount)
    {
        if (isDead) return;

        currentLife -= damageAmount;
        currentLife = Mathf.Clamp(currentLife, 0, maxLife);

        if (currentLife <= 0)
        {
            Die();
        }
        else
        {
            if (receiveHitSound != null)
                GameManager.Instance.AudioManager.PlayAudio(receiveHitSound);
        }

        OnLifeUpdated?.Invoke(currentLife, maxLife);
    }

    public void Heal(int healAmount)
    {
        if (isDead) return;

        currentLife += healAmount;
        currentLife = Mathf.Clamp(currentLife, 0, maxLife);

        OnLifeUpdated?.Invoke(currentLife, maxLife);
    }

    private void Die()
    {
        isDead = true;
        if (deathSound != null)
            GameManager.Instance.AudioManager.PlayAudio(deathSound);

        OnPlayerDeath?.Invoke();
        // Podés agregar una transición o reinicio acá si querés.
    }

    public void ResetPlayer(int? overrideLife = null)
    {
        isDead = false;
        currentLife = overrideLife ?? maxLife;
        OnLifeUpdated?.Invoke(currentLife, maxLife);
    }
}
