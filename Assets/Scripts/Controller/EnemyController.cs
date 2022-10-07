using System.Collections.Generic;
using UnityEngine;

public sealed class EnemyController : IExecute, IFixedUpdate
{
    private SpriteAnimation _spriteAnimation;
    private List<BalistaController> _balistaControllers= new List<BalistaController>();
    private List<EnemyBatController> _enemyFlyViews= new List<EnemyBatController>();
    private TrollController _trollController;

    public EnemyController(List<BalistaView> balistaViews, Transform charector, List<EnemyView> enemyFly, SpriteAnimation spriteAnimation, EnemyTrollView enemyTroll)
    {

        for (int i = 0; i < balistaViews.Count; i++)
        {
            _balistaControllers.Add(new BalistaController(balistaViews[i], charector));
        }

        for (int i = 0; i < enemyFly.Count; i++)
        {
            _enemyFlyViews.Add(new EnemyBatController(enemyFly[i], charector, spriteAnimation));

        }

        _trollController = new TrollController(enemyTroll, spriteAnimation);
    }

    public void Execute()
    {
        if (_balistaControllers!=null)
        {
            foreach (BalistaController balistaController in _balistaControllers)
            {
                balistaController.Execute();
            }
        }
    }

    public void FixedUpdate()
    {
        if (_enemyFlyViews!=null)
        {
            foreach (var item in _enemyFlyViews)
            {
                item.FixedUpdate();
            }
        }
            _trollController.FixedUpdate();
    }
}
