using Entities;
using Paint;
using UnityEngine;

public class EntitiesPaintGlue : MonoBehaviour
{
    private PaintSpawner paintSpawner;

    private void Start()
    {
        paintSpawner = FindAnyObjectByType<PaintSpawner>();
    }

    private void OnEnable()
    {
        EntityPaintHandler.OnPaintSpawned += SpawnPaint;
        ParticlePaintHandler.OnPaintSpawned += SpawnPaint;
    }
    private void OnDisable()
    {
        EntityPaintHandler.OnPaintSpawned -= SpawnPaint;
        ParticlePaintHandler.OnPaintSpawned -= SpawnPaint;
    }

    public void SpawnPaint(Vector2 position)
    {
        paintSpawner.SpawnPaint(position);
    }
}