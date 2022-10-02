using System.Collections.Generic;
using UnityEngine;

public sealed class EnemyController : IExecute
{
    private List<BalistaController> _balistaControllers= new List<BalistaController>();

    public EnemyController(List<BalistaView> balistaViews, Transform charector)
    {
        for (int i = 0; i < balistaViews.Count; i++)
        {
            _balistaControllers.Add(new BalistaController(balistaViews[i], charector));
        }
    }

    public void Execute()
    {
        foreach (BalistaController balistaController in _balistaControllers)
        {
            balistaController.Execute();
        }
    }
}
