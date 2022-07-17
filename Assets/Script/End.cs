using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{


    private IEnumerator Start()
    {
        yield return new WaitForSeconds(2);

        UnityEditor.EditorApplication.ExitPlaymode();

    }

}
