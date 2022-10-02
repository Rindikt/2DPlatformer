using UnityEngine;
internal sealed class CameraController : IExecute
{
    private Camera _camera;
    private Transform _charector;
    private float _offsetSmoothing =2;
    private float _offset =-4;
    private float _minX = - 12f;
    private float _minY = 0;

    public CameraController(Camera camera, Transform charector)
    {
        _charector = charector;
        _camera = camera;
    }

    public void Execute()
    {
        var playerposition = new Vector3(_charector.position.x, _charector.position.y, _charector.position.z + _offset);
        if (_charector.position.x < _minX)
        {
            playerposition.x = _minX;
        }
        if (_charector.position.y < _minY)
        {
            playerposition.y = _minY;
        }
        _camera.transform.position = Vector3.Lerp(_camera.transform.position, playerposition, _offsetSmoothing * Time.deltaTime);
    }
}

