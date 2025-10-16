using TMPro;
using UnityEngine;
using UnityEngine.UI;

// ��˹������ sealed ���ͻ�ͧ�ѹ����׺�ʹ
public sealed class GameManager : MonoBehaviour
{
    // 1. Private Static Field (The Singleton Instance)
    // �� backing field ���ͤǺ��������Ҷ֧
    private static GameManager _instance;

    // 2. Public Static Property (Global Access Point)
    public static GameManager Instance
    {
        get
        {
            // ��� Instance �ѧ�� null (�óն١���¡���͹ Awake)
            if (_instance == null)
            {
                Debug.LogError("GameManager instance is null! Is it in the scene?");
            }
            return _instance;
        }
    }

    [Header("Game State")]
    public int currentScore = 0;
    public bool isGamePaused = false;

    [Header("UI Game")]
    public GameObject pauseMenuUI;
    public TMP_Text scoreText;
    public Slider HPBar;

    // 3. Private Constructor Logic (�� Awake() ᷹ Constructor ����� Unity)
    private void Awake()
    {
        // ��Ǩ�ͺ����� Instance ���������������
        if (_instance == null)
        {
            // ��˹���� Instance ����� Singleton
            _instance = this;

            // ��ͧ�ѹ������ Object ���١�����������ա����Ŵ Scene ����
            DontDestroyOnLoad(gameObject);

            Debug.Log("GameManager Singleton Initialized.");
        }
        else
        {
            // ����� Instance ����������� (�Ҩҡ Scene ��͹˹��) ������µ���ͧ���
            Debug.Log("Duplicate GameManager found. Destroying self.");
            Destroy(gameObject);
        }
    }

    // ------------------- Singleton Functionality -------------------

    public void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        if (HPBar != null)
        {
            HPBar.maxValue = maxHealth;
            HPBar.value = currentHealth;
            Debug.Log($"Health updated: {currentHealth}/{maxHealth}");
        }
        else
        {
            Debug.LogWarning("HPBar reference is missing in GameManager.");
        }
    }
    public void AddScore(int amount)
    {
        currentScore += amount;
        scoreText.text = currentScore.ToString();
        Debug.Log($"Score updated: {currentScore}");
        // ������Ѻ�ѻവ UI, �ѹ�֡��ṹ ���
    }

    public void TogglePause()
    {
        isGamePaused = !isGamePaused;
        Time.timeScale = isGamePaused ? 0f : 1f;
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(isGamePaused);
        }
        Debug.Log($"Game Paused: {isGamePaused}");
    }
}