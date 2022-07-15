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
    private bool isAutoStart = true;
    private bool isFirst = true;
    private int currentDialogIndex = -1; // ���� ��� ����
    private int currentSpeakerIndex = 0; // ���� ���� �ϴ� ȭ���� speakers �迭 ����

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

        if (Input.GetMouseButtonDown(0))
        {
            if (dialogs.Length > currentDialogIndex + 1)
            {
                SetNextDialog();

            }
            else
            {
                for(int i = 0; i < speakers.Length; ++ i)
                {
                    SetActiveObjects(speakers[i], false);

                    speakers[i].spriteRenderer.gameObject.SetActive(false);
                }
                return true;
            }
        }
        return false;
    }

    private void SetNextDialog()
    {
        SetActiveObjects(speakers[currentSpeakerIndex], false);
        
        currentDialogIndex ++;

        currentDialogIndex = dialogs[currentDialogIndex].speakerIndex;

        SetActiveObjects(speakers[currentSpeakerIndex], true);

        speakers[currentSpeakerIndex].textName.text = dialogs[currentDialogIndex].name;

        speakers[currentSpeakerIndex].textDialouge.text = dialogs[currentDialogIndex].dialogue;

    }

    private void SetActiveObjects(Speaker speaker, bool visible)
    {
        speaker.panel.gameObject.SetActive(visible);
        speaker.textName.gameObject.SetActive(visible);
        speaker.textDialouge.gameObject.SetActive(visible);
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

