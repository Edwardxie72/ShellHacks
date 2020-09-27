using System;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;
using UnityEngine.UI;

namespace Platformer.Mechanics
{
    /// <summary>
    /// Represebts the current vital statistics of some game entity.
    /// </summary>
    public class Health : MonoBehaviour
    {
        /// <summary>
        /// The maximum hit points for the entity.
        /// </summary>
        public int maxHP = 3;
		public int maskHP = 0;

        /// <summary>
        /// Indicates if the entity should be considered 'alive'.
        /// </summary>
        public bool IsAlive => currentHP > 0;

        public int currentHP;

        public Image[] hearts;
        public Sprite filledHeart;
        public Sprite emptyHeart;
		
		public Image mask;
		public Sprite filledMask;
		public Sprite emptyMask;

        public void setMax() {
            currentHP = maxHP;
        }
        /// <summary>
        /// Increment the HP of the entity.
        /// </summary>
        public void Increment()
        {
            currentHP = Mathf.Clamp(currentHP + 1, 0, maxHP);
        }

        public void IncrementMask()
        {
            maskHP = 1;
        }

        /// <summary>
        /// Decrement the HP of the entity. Will trigger a HealthIsZero event when
        /// current HP reaches 0.
        /// </summary>
        public void Decrement()
        {
			if (maskHP > 0) {
				maskHP = Mathf.Clamp(maskHP - 1, 0, maskHP);
                maskHP = 0;
			}
			else {
				currentHP = Mathf.Clamp(currentHP - 1, 0, maxHP);
				if (currentHP == 0)
				{
					var ev = Schedule<HealthIsZero>();
					ev.health = this;
				}
			}
        }

        /// <summary>
        /// Decrement the HP of the entitiy until HP reaches 0.
        /// </summary>
        public void Die()
        {
            while (currentHP > 0) Decrement();
        }

        void Awake()
        {
            currentHP = maxHP;
        }

        void Update() {
            for (int i = 0; i < hearts.Length; i++) {
                if (i < currentHP) {
                    hearts[i].sprite = filledHeart;
                }
                else {
                    hearts[i].sprite = emptyHeart;
                }
            }
			
			if (maskHP > 0) {
				mask.sprite = filledMask;
			}
			else {
				mask.sprite = emptyMask;
			}
        }
    }
}
