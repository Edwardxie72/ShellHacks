using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;


namespace Platformer.Mechanics
{
    /// <summary>
    /// This class contains the data required for implementing token collection mechanics.
    /// It does not perform animation of the token, this is handled in a batch by the 
    /// TokenController in the scene.
    /// </summary>
    [RequireComponent(typeof(Collider2D))]
    public class MaskInstance : MonoBehaviour
    {
        //public AudioClip tokenCollectAudio;
        //[Tooltip("If true, animation will start at a random position in the sequence.")]
        //public bool randomAnimationStartTime = false;
        //[Tooltip("List of frames that make up the animation.")]
        //public Sprite[] idleAnimation, collectedAnimation;

        //internal Sprite[] sprites = new Sprite[0];
        internal Sprite sprite;
        internal SpriteRenderer _renderer;

        //unique index which is assigned by the TokenController in a scene.
        internal int maskIndex = -1;
        internal MaskController controller;
        //active frame in animation, updated by the controller.
        internal int frame = 0;
        internal bool collected = false;

        void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            //only exectue OnPlayerEnter if the player collides with this token.
            var player = other.gameObject.GetComponent<PlayerController>();
            
            
            if (player != null) OnPlayerEnter(player);
        }

        void OnPlayerEnter(PlayerController player)
        {
            if (collected) return;
            Debug.Log("here");
            if (controller != null)
            {
                collected = true;
                player.health.IncrementMask();
            }
            if (collected) Debug.Log("test");
            //send an event into the gameplay system to perform some behaviour.
            var ev = Schedule<PlayerMaskCollision>();
            ev.mask = this;
            ev.player = player;
        }
    }
}