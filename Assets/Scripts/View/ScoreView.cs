using TMPro;
using UnityEngine;

public sealed class ScoreView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _score;

    public TextMeshProUGUI Score { get => _score; set => _score = value; }
}
