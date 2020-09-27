using System.Collections;
using System.Collections.Generic;
using Platformer.Core;
//using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine;

using System;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when the player has died.
    /// </summary>
    /// <typeparam name="PlayerDeath"></typeparam>
    public class PlayerDeath : Simulation.Event<PlayerDeath>
    {
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();
        // public PlayerController player;

        public override void Execute()
        {
            if (model.player == null)
                Debug.Log("null");
            var player = model.player;
			/*
            if (model.player.controlEnabled)
            {
                Debug.Log("reeeeeee");
            }
            else
            {
                //Debug.Log(player.controlEnabled);
                //Debug.Log(model);
                Debug.Log("????");
                //if (player.controlEnabled)
                //{
                    //Debug.Log("ddddds");
                //}
            }*/

            
            if (player.health.IsAlive)
            {
                player.health.Die();
                
            }
            
			model.virtualCamera.m_Follow = null;
			model.virtualCamera.m_LookAt = null;
		    // player.collider.enabled = false;
			player.controlEnabled = false;

			if (player.audioSource && player.ouchAudio)
				player.audioSource.PlayOneShot(player.ouchAudio);
			player.animator.SetTrigger("hurt");
			player.animator.SetBool("dead", true);
			Simulation.Schedule<PlayerSpawn>(2);
        }
    }
}