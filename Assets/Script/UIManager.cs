using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonPanel;

    private void Update()
    {
        if(Input.anyKeyDown)
        {
            buttonPanel.SetActive(true);
        }
    }


}
