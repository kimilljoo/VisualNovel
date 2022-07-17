using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Dialog dialogSystem01;

    [SerializeField]
    private GameObject SelectPanel;


    private IEnumerator Start()
    {
        SelectPanel.gameObject.SetActive(false);

        yield return new WaitUntil(() => dialogSystem01.UpdateDialog());

        SelectPanel.gameObject.SetActive(true);

       

    }



}
