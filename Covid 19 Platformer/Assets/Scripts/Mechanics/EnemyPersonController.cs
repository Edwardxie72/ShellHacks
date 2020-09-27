using System.Collections;
using System.Collections.Generic;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// A simple controller for enemies. Provides movement control over a patrol path.
    /// </summary>
    ///[RequireComponent(typeof(AnimationController), typeof(Collider2D))]
    public class EnemyPersonController : MonoBehaviour
    {
        // Return position vector
        public Vector3 getPosition()
        {
            return transform.position;
        }

        // Return distance from a position
        public double getDistance(Vector3 pos)
        {
            double x = transform.position.x - pos.x;
            double y = transform.position.y - pos.y;
            return System.Math.Sqrt(x * x + y * y);
        }
    }
}