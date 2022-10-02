using System.Collections.Generic;
using UnityEngine;

public sealed class LevelCompleteManager
{
    private Vector3 _startPosition;
    private CharacterView _charecterView;

    private List<LevelObjectView> _deathZone;
    private LevelObjectView _winZona;
    private ControllerFinishMenu _controllerFinishMenu;
    private CoinsManager _coinsManager;

    public LevelCompleteManager(Vector3 startPosition, CharacterView characterView, List<LevelObjectView> deathZone, LevelObjectView winZona, FinishMenuView finishMenu, CoinsManager coinsManager, Health healthplayer)
    {

        _startPosition = startPosition;
        _charecterView = characterView;
        _deathZone = deathZone;
        _winZona = winZona;
        _winZona.OnLevelObjectContact += FinishLevel;
        healthplayer.ZeroHp += OnLevelObjectContact;
        foreach (LevelObjectView obj in _deathZone)
        {
            obj.OnLevelObjectContact += OnLevelObjectContact;
        }
        _controllerFinishMenu = new ControllerFinishMenu(finishMenu);
        _coinsManager = coinsManager;
    }

    private void OnLevelObjectContact()
    {
        _charecterView.transform.position = _startPosition;
    }

    private void FinishLevel()
    {
        Time.timeScale = 0f;
        _controllerFinishMenu.OnFinishMenu(_coinsManager.ScoreCoins);

    }
    public void Dispose()
    {
        foreach (LevelObjectView obj in _deathZone)
        {
            obj.OnLevelObjectContact -= OnLevelObjectContact;
        }
       
    }
}
