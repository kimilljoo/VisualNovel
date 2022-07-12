using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Test : MonoBehaviour
{
    [SerializeField]
    private Dialog DialogSystem01;
    [SerializeField]
    private TextMeshProUGUI textCountdown;
    [SerializeField]
    private Dialog dialogSystem02;

    private IEnumerator Start()
    {
        textCountdown.gameObject.SetActive(false);
        
        //ù ��° ��� �б���� 
        yield return new WaitUntil(() => DialogSystem01.UpdateDialog());

        //��� �б� ���̿� ���ϴ� �ൿ�� �߰��� �� �ִ�.
        //ĳ���͸� �����̰ų� �������� ȹ���ϴ� ���� .. ����� 5-4-3-2-1 ī��Ʈ �ٿ� ����

        textCountdown.gameObject.gameObject.SetActive(true);
        int count = 5;
        while (count > 0)
        {
            textCountdown.text = count.ToString();
            count--;

            yield return new WaitForSeconds(1);
        }
        textCountdown.gameObject.SetActive(false);

        //�� ��° ��� �б� ����
        yield return new WaitUntil(()=>dialogSystem02.UpdateDialog()); 

        textCountdown.gameObject.SetActive(true);
        textCountdown.text = "The End";

        yield return new WaitForSeconds(2);
        UnityEditor.EditorApplication.ExitPlaymode();

    } 


}
