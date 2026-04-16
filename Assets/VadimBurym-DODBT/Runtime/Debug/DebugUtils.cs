//License
//- Repository: https://github.com/vadimburym/DOTS-Battle-Simulator-Prototype/tree/main/Assets/VadimBurym-DODBT
//- Copyright (c) 2026 vadimburym (Vadim Burym)
//- The repository root is licensed under a custom source-available license in LICENSE.md.
//- Assets/VadimBurym-DODBT is licensed separately under Assets/VadimBurym-DODBT/LICENSE.md.
//- Third-party assets and packages remain under their respective owners’ terms.

using System;
using System.Collections.Generic;

namespace VadimBurym.DodBehaviourTree
{
    #if UNITY_EDITOR
    internal static class DebugUtils
    {
        private const string Suffix = "Leaf";

        private static readonly Dictionary<Type, string> _cache = new();

        public static string GetLeafName(ILeaf leaf)
        {
            if (leaf == null)
                return string.Empty;
            var type = leaf.GetType();
            if (_cache.TryGetValue(type, out var cached))
                return cached;
            string name = type.Name;
            if (name.EndsWith(Suffix))
                name = name.Substring(0, name.Length - Suffix.Length);
            _cache[type] = name;
            return name;
        }
    }
    #endif
}
