using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when a player collides with a token.
    /// </summary>
    /// <typeparam name="PlayerCollision"></typeparam>
    public class PlayerMaskCollision : Simulation.Event<PlayerMaskCollision>
    {
        public PlayerController player;
        public MaskInstance mask;

        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            //AudioSource.PlayClipAtPoint(token.tokenCollectAudio, token.transform.position);
        }
    }
}