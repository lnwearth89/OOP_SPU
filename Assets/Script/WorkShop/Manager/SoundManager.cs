using UnityEngine;
using System.Collections.Generic;

// ��˹������ sealed ���ͻ�ͧ�ѹ����׺�ʹ
public sealed class SoundManager : MonoBehaviour
{
    // 1. Singleton Instance
    private static SoundManager _instance;

    // 2. Public Static Property (Global Access Point)
    public static SoundManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("SoundManager instance is null! Is it in the scene?");
            }
            return _instance;
        }
    }

    [Header("Audio Sources")]
    // Audio Source ����Ѻ�ŧ��Сͺ (Looping)
    public AudioSource musicSource;
    // Audio Source ����Ѻ�Ϳ࿡�����§ (Non-Looping)
    public AudioSource sfxSource;

    [Header("Default Audio Clips")]
    public AudioClip defaultButtonClick;
    public AudioClip defaultBackgroundMusic;

    // 3. Singleton Initialization
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);

            // ��Ǩ�ͺ������� Audio Source �ҡ�ѧ�����
            if (musicSource == null) musicSource = gameObject.AddComponent<AudioSource>();
            if (sfxSource == null) sfxSource = gameObject.AddComponent<AudioSource>();

            // ��駤�Ҿ�鹰ҹ
            musicSource.loop = true; // �ŧ��Сͺ�ѡ��ǹ���

            PlayMusic(defaultBackgroundMusic);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // ------------------- Music Controls -------------------

    /// <summary>
    /// ����ŧ��Сͺ����
    /// </summary>
    public void PlayMusic(AudioClip clip)
    {
        if (clip == null || musicSource == null) return;

        musicSource.clip = clip;
        musicSource.Play();
    }

    public void StopMusic()
    {
        if (musicSource != null)
        {
            musicSource.Stop();
        }
    }

    // ------------------- SFX Controls -------------------

    /// <summary>
    /// ����Ϳ࿡�����§Ẻ�������Ǩ� (One-Shot)
    /// </summary>
    public void PlaySFX(AudioClip clip)
    {
        if (clip == null || sfxSource == null) return;

        // �� PlayOneShot �����������������§�Ѻ��͹�ѹ��
        sfxSource.PlayOneShot(clip);
    }

    // ------------------- Volume Controls -------------------

    /// <summary>
    /// ��˹��дѺ���§��ѡ�ͧ�ŧ��Сͺ (0.0 �֧ 1.0)
    /// </summary>
    public void SetMusicVolume(float volume)
    {
        if (musicSource != null)
        {
            musicSource.volume = volume;
        }
    }

    /// <summary>
    /// ��˹��дѺ���§��ѡ�ͧ�Ϳ࿡�����§ (0.0 �֧ 1.0)
    /// </summary>
    public void SetSFXVolume(float volume)
    {
        if (sfxSource != null)
        {
            sfxSource.volume = volume;
        }
    }
}