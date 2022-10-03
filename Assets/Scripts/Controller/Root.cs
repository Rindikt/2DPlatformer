using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public sealed class Root : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private SpriteRenderer _backGround;

    [SerializeField]
    private CharacterView _charecterView;

    [SerializeField]
    private List<BalistaView> _balistaView;

    [SerializeField]
    private List<CoinView> _coinViews;

    [SerializeField]
    private List<LevelObjectView> _deadZone;

    [SerializeField]
    private LevelObjectView _finishZona;

    [SerializeField]
    private Transform _startPosition;

    [SerializeField]
    private ScoreView _scoreView;

    [SerializeField]
    private FinishMenuView finishMenuView;

    [SerializeField]
    private List<LiftView> _liftView;

    private CameraController _cameraController;
    private SpriteAnimation _spriteAnimator;
    private PlayerController playerController;
    private ParalaxManager _paralaxManager;
    private InputController _inputController;
    private BalistaController _balistaController;
    private CoinsManager _coinsManager;
    private EnemyController _enemyController;
    private LiftManager _liftManager;

    private LevelCompleteManager _levelCompleteManager;


    private void Start()
    {
        _inputController = new InputController();
        _paralaxManager = new ParalaxManager(_camera, _backGround.transform);
        SpriteAnimationsConfig config = Resources.Load<SpriteAnimationsConfig>(StringManager.SO_SPRITE_ANIMATIONS_CONFIG);
        _spriteAnimator = new SpriteAnimation(config);
        playerController = new PlayerController(_inputController, _charecterView, _spriteAnimator);
        _cameraController = new CameraController(_camera, _charecterView.transform);
        _coinsManager = new CoinsManager(_coinViews, _spriteAnimator, _scoreView);
        _levelCompleteManager = new LevelCompleteManager(_startPosition.position, _charecterView, _deadZone, _finishZona, finishMenuView, _coinsManager, playerController._health);
        _enemyController = new EnemyController(_balistaView, _charecterView.gameObject.transform);
        _liftManager = new LiftManager(_liftView);

    }

    private void Update()
    {
        _paralaxManager.Update();
        _spriteAnimator.Update();
        _cameraController.Execute();
        _inputController.FixedUpdate();
        _enemyController.Execute();
    }

    private void FixedUpdate()
    {
        playerController.FixedUpdate();
        _liftManager.FixedUpdate();
    }

    private void OnDestroy()
    {
        _coinsManager.Dispose();
        _levelCompleteManager.Dispose();
    }
}
