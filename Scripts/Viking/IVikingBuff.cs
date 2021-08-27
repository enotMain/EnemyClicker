using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IVikingBuff
{
    public int BuffScale { get; set; }
    public float TimerBuffScale { get; set; }
    public float TimeToBuff { get; set; }
    public float LowBorderOfSpawnTime { get; set; }
    public float SpawnScale { get; set; }

    public void VikingBuffByScale(GameObject vikingGO, int scale);
    public void BuffController(bool isTimeToBuff, ref float timeToSpawn);
    public bool IsTimeToBuff();
}
