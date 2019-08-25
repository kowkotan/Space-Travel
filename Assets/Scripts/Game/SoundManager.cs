using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField]
    private AudioSource soundFX;
    [SerializeField]
    private AudioClip uiClip, deathClip, collectableItemClip;

    private void Awake() {
        if(instance == null) instance = this;
    }

    public void UiClip() {
        soundFX.clip = uiClip;
        soundFX.Play();
    }

    public void DeathClip() {
        soundFX.clip = deathClip;
        soundFX.Play();
    }

    public void CollectableItemClip() {
        soundFX.clip = collectableItemClip;
        soundFX.Play();
    }

}
