using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public enum Sound {
    Bgm,
    Effect,
    MaxCount,
}
    private AudioSource[] audioSources;

    public AudioClip move;
    public AudioClip click;
    public AudioClip damage;
    public AudioClip heal;
    public AudioClip coin;
    public AudioClip finish;

    // Singleton 처리
    public static SoundManager Instance;
    private void Awake()
    {
        Instance = this;
        //Initialize();
    }
/*
    PlayBGM() {
        Play(bgm, Sound.Bgm);
    }
*/
    void PlayMoveSound() {
        Play(move);
    }

    void PlayClickSound() {
        Play(click);
    }

    void PlayDamageSound(){
        Play(damage);
    }

    void PlayHealSound(){
        Play(heal);
    }

    void PlayCoinSound(){
        Play(coin);
    }

    void PlayFinishSound(){
        Play(finish);
    }

    void Play(AudioClip audioClip, Sound soundType = Sound.Effect, int pitch = 1) {
        if (!audioClip) return;

        AudioSource audioSource  = audioSources[(int)soundType];
        audioSource.pitch = pitch;

        if (soundType == Sound.Bgm) {
            if (audioSource.isPlaying) audioSource.Stop();
            audioSource.clip = audioClip;
            audioSource.Play();
        }

        if (soundType == Sound.Effect) {
            audioSource.PlayOneShot(audioClip);
        }
    }
/*
    void Initialize() {
        GameObject root = GameObject.Find("Sound");
        if (root == null) {
            root = new GameObject("Sound");
            for (int i = 0; i < (int)Sound.MaxCount; i++) {
                GameObject g = new GameObject(Sound[i].ToString());
                g.transform.parent = root.transform;
                audioSources.push(g.AddComponent<AudioSource>());
            }

            audioSources[Sound.Bgm].loop = true;
        }
    }
    */
}
