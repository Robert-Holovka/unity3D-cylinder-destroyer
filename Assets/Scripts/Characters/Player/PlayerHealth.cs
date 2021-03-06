﻿using Assignment.Core.Game;
using UnityEngine;
using UnityEngine.UI;

namespace Assignment.Characters.Player
{
    public class PlayerHealth : MonoBehaviour, IDamageable, IRestorable
    {
        [SerializeField] float maxHealth = 100f;
        [SerializeField] Image healthFillImage = default;

        public bool IsDead { get; set; }

        private float currentHealth;

        private void Start() => currentHealth = maxHealth;
        private void UpdateHealthUI() => healthFillImage.fillAmount = currentHealth / maxHealth;
        private void Die() => FindObjectOfType<GameManager>().GetComponent<ILevelEventHandler>().OnPlayerDeath();

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                Die();
            }
            else
            {
                UpdateHealthUI();
            }
        }

        public void RestoreHealth(float healthPoints)
        {
            currentHealth += healthPoints;
            currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
            UpdateHealthUI();
        }
    }
}