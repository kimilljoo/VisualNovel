using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialog : MonoBehaviour
{
    [SerializeField]
    private Speaker[]       speakers;   // 대화하는 사람
    [SerializeField]
    private DialogData[]    dialogs;
    [SerializeField]
    private bool isAutoStart = true;
    private bool isFirst = true;
    private int currentDialogIndex = -1; // 현재 대사 순번
    private int currentSpeakerIndex = 0; // 현재 말을 하는 화자의 speakers 배열 순번

    private void Awake()
    {
        Setup();
    }

    private void Setup()
    {
        for (int i = 0; i < speakers.Length; ++i)
        {
            SetActiveObjects(speakers[i], false);
            // 캐릭터 이미지는 보이도록 설정
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
            //초기화, 캐릭터 이미지는 활성화하고, 대사 관련 UI는 모두 비활성화
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
    public SpriteRenderer spriteRenderer; // 캐릭터 이미지
    public GameObject panel;            // 대화창 Image UI

    public TextMeshProUGUI textName;      // 캐릭터 이름
    public TextMeshProUGUI textDialouge;  // 대사
    public GameObject objectArrow;        // 대사 출력 후 완료 시 출력되는 커서 오브젝트
}

[System.Serializable]
public struct DialogData
{
    public int speakerIndex;  // 이름과 대사를 출력할 현재 DialogSystem의 speakers 배열 순번
    public string name;       // 캐릭터 이름
    [TextArea(3, 5)]
    public string dialogue;   // 대사
     
}

