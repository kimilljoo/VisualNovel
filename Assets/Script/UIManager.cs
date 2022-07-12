using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonPanel;

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            buttonPanel.SetActive(true);

            StartCoroutine(UIFunction.Instance.MoveUI(buttonPanel, buttonPanel.transform.position, new Vector3(960.0f,540.0f,0.0f)));

        }
    }

    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void GameQuit()
    {
        Application.Quit(); 
    }
}