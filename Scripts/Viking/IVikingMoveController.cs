using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IVikingMoveController
{
    public void VikingMove(Transform viking, float speed, Vector2 direction);
    public Vector2 CalcRandomVikingDirection();
    public Vector2 ReverseDirectionYAxis(Vector2 direction);
    public Vector2 ReverseDirectionXAxis(Vector2 direction);
}
