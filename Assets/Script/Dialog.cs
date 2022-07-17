using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialog : MonoBehaviour
{
    [SerializeField]
    private Speaker[]       speakers;   // ��ȭ�ϴ� ���
    [SerializeField]
    private DialogData[]    dialogs;
    [SerializeField]
    private bool    isAutoStart = true;
    private bool    isFirst = true;
    private int     currentDialogIndex = -1; // ���� ��� ����
    private int     currentSpeakerIndex = 0; // ���� ���� �ϴ� ȭ���� speakers �迭 ����
    private float   typingSpeed = 0.1f;
    private bool    isTypingEffect = false;
    private void Awake()
    {
        Setup();
    }

    private void Setup()
    {
        for (int i = 0; i < speakers.Length; ++i)
        {
            SetActiveObjects(speakers[i], false);
            // ĳ���� �̹����� ���̵��� ����
            speakers[i].spriteRenderer.gameObject.SetActive(true);
        }
    }

    public void Update()
    {
        UpdateDialog();
    }

    public bool UpdateDialog()
    {
        if (isFirst == true)
        {
            //�ʱ�ȭ, ĳ���� �̹����� Ȱ��ȭ�ϰ�, ��� ���� UI�� ��� ��Ȱ��ȭ
            Setup();

            if (isAutoStart) SetNextDialog();

            isFirst = false;
        }
        return false;
    }

    public void OnClick()
    {
            if (isTypingEffect == true)
            {
                isTypingEffect = false;

                StopCoroutine("OnTypingText");
                speakers[currentSpeakerIndex].textDialouge.text = dialogs[currentDialogIndex].dialogue;
                speakers[currentDialogIndex].objectArrow.SetActive(true);

            }
            if (dialogs.Length > currentDialogIndex + 1)
            {
                SetNextDialog();

            }
            else
            {
                for (int i = 0; i < speakers.Length; ++i)
                {
                    SetActiveObjects(speakers[i], false);

                    speakers[i].spriteRenderer.gameObject.SetActive(false);
                }
            }
    }

    private void SetNextDialog()
    {
        SetActiveObjects(speakers[currentSpeakerIndex], false);
        
        currentDialogIndex ++;

        currentDialogIndex = dialogs[currentDialogIndex].speakerIndex;

        SetActiveObjects(speakers[currentSpeakerIndex], true);

        speakers[currentSpeakerIndex].textName.text = dialogs[currentDialogIndex].name;

        speakers[currentSpeakerIndex].textDialouge.text = dialogs[currentDialogIndex].dialogue;

        StartCoroutine("OnTypingText");
    }

    private void SetActiveObjects(Speaker speaker, bool visible)
    {
        speaker.panel.gameObject.SetActive(visible);
        speaker.textName.gameObject.SetActive(visible);
        speaker.textDialouge.gameObject.SetActive(visible);
    }

    private IEnumerator OnTypingText()
    {
        int index = 0;
        isTypingEffect = true;

        while (index <= dialogs[currentDialogIndex].dialogue.Length)
        {
            speakers[currentSpeakerIndex].textDialouge.text = dialogs[currentDialogIndex].dialogue.Substring(0, index);
            index++;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTypingEffect = false;

        speakers[currentSpeakerIndex].objectArrow.SetActive(true);
    }
}



[System.Serializable]
public struct Speaker
{
    public SpriteRenderer spriteRenderer; // ĳ���� �̹���
    public GameObject panel;            // ��ȭâ Image UI

    public TextMeshProUGUI textName;      // ĳ���� �̸�
    public TextMeshProUGUI textDialouge;  // ���
    public GameObject objectArrow;        // ��� ��� �� �Ϸ� �� ��µǴ� Ŀ�� ������Ʈ
}

[System.Serializable]
public struct DialogData
{
    public int speakerIndex;  // �̸��� ��縦 ����� ���� DialogSystem�� speakers �迭 ����
    public string name;       // ĳ���� �̸�
    [TextArea(3, 5)]
    public string dialogue;   // ���
     
}

