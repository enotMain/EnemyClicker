using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VikingSpawner : MonoBehaviour
{
    [System.Serializable]
    private struct BuffData
    {
        [SerializeField] private int _buffScale;
        [SerializeField] private float _timeToBuff;
        [SerializeField] private float _lowBorderOfSpawnTime;
        [SerializeField] private float _spawnScale;

        public int BuffScale { get => _buffScale; set => _buffScale = value; }
        public float TimeToBuff { get => _timeToBuff; set => _timeToBuff = value; }
        public float LowBorderOfSpawnTime { get => _lowBorderOfSpawnTime; set => _lowBorderOfSpawnTime = value; }
        public float SpawnScale { get => _spawnScale; set => _spawnScale = value; }
    }

    [SerializeField] private GameObject _vikingPrefab;
    [SerializeField] private float _playGroundScaleRate;
    [SerializeField] private float _startTimeToSpawn;
    [SerializeField] private BuffData _buffData;
    private float _spawnTimer;
    private Camera _camera;
    private IVikingBuff _vikingBuff;

    public float SpawnTimer
    { 
        get => _spawnTimer; 
        set
        {
            if (_spawnTimer == value) return;
            _spawnTimer = value;
            if (_spawnTimer >= _startTimeToSpawn && OnTimeToSpawn != null) 
            {
                _spawnTimer = 0f;
                OnTimeToSpawn();
            } 
        } 
    }

    private delegate void OnTimeToSpawnDelegate();
    private event OnTimeToSpawnDelegate OnTimeToSpawn;

    private void Awake()
    {
        _camera = Camera.main;
        _spawnTimer = 0;
        _vikingBuff = new VikingBuff();
        _vikingBuff.BuffScale = _buffData.BuffScale;
        _vikingBuff.TimerBuffScale = 0f;
        _vikingBuff.TimeToBuff = _buffData.TimeToBuff;
        _vikingBuff.LowBorderOfSpawnTime = _buffData.LowBorderOfSpawnTime;
        _vikingBuff.SpawnScale = _buffData.SpawnScale;

        OnTimeToSpawn += SpawnController;
    }

    private void Start()
    {
        SpawnViking(_vikingPrefab, CalcRandomPosOnCamera(_camera, _playGroundScaleRate),
            _vikingBuff.BuffScale);
    }

    private void Update()
    {
        _vikingBuff.TimerBuffScale += Time.deltaTime;
        SpawnTimer += Time.deltaTime;
        _vikingBuff.BuffController(_vikingBuff.IsTimeToBuff(), ref _startTimeToSpawn);
    }

    private void SpawnController()
    {
        SpawnViking(_vikingPrefab, CalcRandomPosOnCamera(_camera, _playGroundScaleRate),
            _vikingBuff.BuffScale);
    }

    private Vector3 CalcRandomPosOnCamera(Camera camera, float playGroundScaleRate)
    {
        float height = camera.orthographicSize;
        float width = height * camera.aspect;

        return new Vector3(Random.Range(-width * playGroundScaleRate, width * playGroundScaleRate),
            Random.Range(-height * playGroundScaleRate, height * playGroundScaleRate),
            0);
    }

    private void SpawnViking(GameObject viking, Vector3 placeToSpawn, int buffScale)
    {
        GameObject.FindGameObjectWithTag("EnemiesCount").GetComponent<EnemiesCountText>().EnemiesCount++;
        GameObject newVikingGO = Instantiate(viking, 
            new Vector3(placeToSpawn.x, placeToSpawn.y, 0), 
            Quaternion.Euler(Vector3.zero));
        _vikingBuff.VikingBuffByScale(newVikingGO, buffScale);
    }
}