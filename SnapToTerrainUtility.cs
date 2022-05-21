#if UNITY_EDITOR
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Namespace
{
    public static class SnapToTerrainUtility
    {
        [MenuItem("GameObject/Snap to Terrain %&q")]
        public static void SnapToTerrain()
        {
            foreach (var transform in Selection.transforms)
            {
                var terrainHits = Physics
                                    .RaycastAll(transform.position + Vector3.up * 100f, Vector3.down, float.MaxValue)
                                    .OrderBy(hit => (transform.position - hit.point).sqrMagnitude)
                                    .Where(hit => hit.collider is TerrainCollider)
                                    .ToArray();

                if (terrainHits.Any())
                {
                    transform.position = terrainHits.First().point;
                }
            }
        }
    }
}
#endif
