using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScManager : MonoBehaviour //�б��� �� ��ȯ
{
    [SerializeField]
    private Dialog[] dialogSystem;

    private IEnumerator Start()
    {

        for (int i = 0; i < dialogSystem.Length; ++i)
        {

            if (dialogSystem.Length > i)
            {
                yield return new WaitUntil(() => dialogSystem[i].UpdateDialog());

            }

        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }



    public void Onclick() //�б��� �� ��ȯ 
    {
        switch(this.gameObject.name)
        {
            case "Yes":
                SceneManager.LoadScene("Select Yes");
                break;
            case "No":
                SceneManager.LoadScene("Select No");
                break;
        }
    }
}
