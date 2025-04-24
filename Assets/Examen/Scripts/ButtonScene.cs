using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScene : MonoBehaviour
{
    [Header("Atributtes")]
    [SerializeField] private string scene;
    Button myButton;

    private void Awake()
    {
        myButton = GetComponent<Button>();
    }

    private void Start()
    {
        Time.timeScale = 1.0f;
        myButton.onClick.AddListener(Interactue);
    }
    void Interactue()
    {
        SceneManager.LoadScene(scene);
    }
}

