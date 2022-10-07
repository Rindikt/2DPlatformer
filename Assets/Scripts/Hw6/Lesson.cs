using UnityEngine;

public class Lesson : MonoBehaviour
{
    [SerializeField]
    private GenerationView _generationView;

    private GeneratorLevelController _generatorLevel;

    private void Awake()
    {
        _generatorLevel = new GeneratorLevelController(_generationView);
        _generatorLevel.Awake();        
    }
}
