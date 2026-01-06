using UnityEngine;
using TMPro;

public class ExhibitInfoPopup : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject infoCanvasRoot; // the world-space canvas root
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text bodyText;

    [Header("Content")]
    [SerializeField] private string exhibitTitle;
    [TextArea(3, 10)]
    [SerializeField] private string exhibitDescription;

    [Header("Detection")]
    [SerializeField] private string playerTag = "Player";
    // alternatively use a Layer and compare layers

    private void Awake()
    {
        if (infoCanvasRoot != null)
            infoCanvasRoot.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(playerTag)) return;

        Show();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag(playerTag)) return;

        Hide();
    }

    private void Show()
    {
        if (infoCanvasRoot == null) return;

        if (titleText != null) titleText.text = exhibitTitle;
        if (bodyText != null) bodyText.text = exhibitDescription;

        infoCanvasRoot.SetActive(true);

        var cam = Camera.main;
        if (cam != null)
        {
            Vector3 toCam = infoCanvasRoot.transform.position - cam.transform.position;
            toCam.y = 0f; // keep it level
            infoCanvasRoot.transform.rotation = Quaternion.LookRotation(toCam);
        }

    }

    private void Hide()
    {
        if (infoCanvasRoot == null) return;
        infoCanvasRoot.SetActive(false);
    }
}
