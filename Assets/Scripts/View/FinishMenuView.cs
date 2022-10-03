using UnityEngine.UI;
using UnityEngine;
using TMPro;


public sealed class FinishMenuView : MonoBehaviour 
{
    [SerializeField]
    private Button _restart;

    [SerializeField]
    private Button _exit;

    [SerializeField]
    private TextMeshProUGUI _score;

    public Button Restart => _restart;

    public Button Exit => _exit;

    public TextMeshProUGUI Score => _score;
}
