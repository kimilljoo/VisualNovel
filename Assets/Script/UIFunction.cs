using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFunction
{
    private static UIFunction instance;

    public static UIFunction Instance
    { 
        get 
        {
            if (instance == null)
                instance = new UIFunction();

            return instance;
        } 
    }

    public IEnumerator MoveUI(GameObject target, Vector3 from, Vector3 to)
    {
        Vector3 fixedFrom = Camera.main.WorldToScreenPoint(from);
        Vector3 fixedTo = Camera.main.WorldToScreenPoint(to);

        float timer = 0.0f;

        while(true)
        {
            yield return null;

            timer += Time.deltaTime * 5;
            target.transform.position = Vector3.Lerp(from, to, timer);

            if (timer >= 1.0f)
            {
                yield break;
            }
        }
    }
}
