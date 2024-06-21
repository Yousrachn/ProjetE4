using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogMangager : MonoBehaviour
{

    [SerializeField] GameObject dialogBox;
    [SerializeField] TMPro.TextMeshProUGUI dialogText;

    [SerializeField] int lettersPerSecond;

    Dialog dialog;
    bool isActive = false;
    bool lineFinished = false;
    int currentLine = 0;

    public static DialogMangager Instance { get; private set;}

    private void Awake() {
        Instance = this;
    }

    public void ShowDialog(Dialog dialog) {
        if (dialogBox == null) {
            dialogBox = GameObject.FindGameObjectWithTag("Dialog Box");
        }
        dialogBox.SetActive(true);
        this.dialog = dialog;
        if (!isActive) {
            StartCoroutine(TypeDialog(dialog.Lines[0]));
        }
    }

    public IEnumerator TypeDialog(string dialog) {
        isActive = true;
        dialogText.text = "";
        foreach (var letter in dialog.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }
        lineFinished = true;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive) {
            if (Input.GetKeyDown(KeyCode.Space) && lineFinished) {
                lineFinished = false;
                ++currentLine;
                if (currentLine < dialog.Lines.Count) {
                    StartCoroutine(TypeDialog(dialog.Lines[currentLine]));
                } else {
                    currentLine = 0;
                    isActive = false;
                    dialogBox.SetActive(false);
                }
            } else if (Input.GetKeyDown(KeyCode.Space)) {
                StopAllCoroutines();
                dialogText.text = dialog.Lines[currentLine];
                lineFinished = true;
            }
        }
    }
}
