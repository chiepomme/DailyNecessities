using UnityEngine;

namespace Namespace
{
    public static class CloneComponentExtensions
    {
        public static T Clone<T>(this T source) where T : Component
        {
            var clone = Object.Instantiate(source);
            var sourceTrans = source.transform;
            var cloneTrans = clone.transform;

            cloneTrans.SetParent(sourceTrans.parent, false);
            cloneTrans.SetPositionAndRotation(sourceTrans.position, sourceTrans.rotation);
            cloneTrans.localScale = sourceTrans.localScale;

            return clone;
        }

        public static T Clone<T>(this T source, bool active) where T : Component
        {
            var clone = source.Clone();
            clone.gameObject.SetActive(active);
            return clone;
        }
    }
}
