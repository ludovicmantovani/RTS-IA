using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineAnimationParticle : MonoBehaviour
{
        [SerializeField] private ParticleSystem particleLeft;
        [SerializeField] private ParticleSystem particleRight;


        public void Sprinkle()
        {
            particleLeft.Play();
            particleRight.Play();
        }
}
