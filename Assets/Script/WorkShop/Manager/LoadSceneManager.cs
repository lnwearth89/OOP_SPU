using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; // �Ӥѭ�ҡ����Ѻ Scene Management

public sealed class LoadSceneManager : MonoBehaviour
{
    // 1. Singleton Instance
    private static LoadSceneManager _instance;

    // 2. Global Access Point
    public static LoadSceneManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("LoadSceneManager instance is null! Is it in the scene?");
            }
            return _instance;
        }
    }

    [Header("Loading Screen Reference")]
    public GameObject loadingScreenPanel; // ��ҧ�ԧ�֧ Panel �������˹�Ҩ���Ŵ

    // 3. Singleton Initialization
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            // ��ͧ�ѹ������ Object ���١������������Ŵ Scene ����
            DontDestroyOnLoad(gameObject);

            // ��͹˹�Ҩ���Ŵ����͹
            if (loadingScreenPanel != null)
            {
                loadingScreenPanel.SetActive(false);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // ------------------- Core Functionality -------------------

    /// <summary>
    /// ���ʹ��ѡ����Ѻ��Ŵ�ҡ����Ẻ�ԧ�ù��
    /// </summary>
    public void LoadNewScene(string sceneName)
    {
        StartCoroutine(LoadSceneCoroutine(sceneName));
    }

    /// <summary>
    /// Coroutine ��ѡ����Ѻ�����Ŵ�ҡẺ Asynchronous
    /// </summary>
    private IEnumerator LoadSceneCoroutine(string sceneName)
    {
        // 1. ����������Ŵ
        if (loadingScreenPanel != null)
        {
            loadingScreenPanel.SetActive(true); // �ʴ�˹�Ҩ���Ŵ
        }

        // 2. ����������ŴẺ Asynchronous
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        // ��ͧ�ѹ������ҡ�����ʴ������Ҩж١���
        // (�ջ���ª������ͤس��ͧ������ҡ��ҫ�͹���仡�͹ �����ͨ�������Ŵ���� 90% ���Ǥ������)
        // operation.allowSceneActivation = false; 

        // 3. ǹ�ٻ��Ǩ�ͺ�����׺˹��
        while (!operation.isDone)
        {
            // operation.progress �դ�ҵ���� 0.0 �֧ 0.9 (����;����������¹�ҡ)
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            // ��˹�������͹��Ǩ�ͺ���
            yield return null;
        }

        // 4. ����ش�����Ŵ
        // 㹢�鹵͹��� operation.isDone �� true ���� (100% ��������ó�)

        // 5. ��͹˹�Ҩ���Ŵ
        if (loadingScreenPanel != null)
        {
            loadingScreenPanel.SetActive(false);
        }

        Debug.Log($"Scene '{sceneName}' loaded and activated successfully.");
    }

    /// <summary>
    /// ���ʹ����Ѻ��͹˹�Ҩ���Ŵ (�Ҩ�١���¡�ҡ�ҡ����)
    /// </summary>
    public void HideLoadingScreen()
    {
        if (loadingScreenPanel != null)
        {
            loadingScreenPanel.SetActive(false);
        }
    }

    // ------------------- Utility -------------------

    public string GetCurrentSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }
}