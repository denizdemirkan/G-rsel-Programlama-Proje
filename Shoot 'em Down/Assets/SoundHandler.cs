using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour
{
    public AudioSource shootingSound;
    public AudioSource deathSound;

    public void ShootSound()
    {
        shootingSound.Play();
    }

    public void DeathSound()
    {
        deathSound.Play();
    }

}
