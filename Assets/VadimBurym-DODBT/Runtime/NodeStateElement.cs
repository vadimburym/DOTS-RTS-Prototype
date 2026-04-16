//License
//- Repository: https://github.com/vadimburym/DOTS-Battle-Simulator-Prototype/tree/main/Assets/VadimBurym-DODBT
//- Copyright (c) 2026 vadimburym (Vadim Burym)
//- The repository root is licensed under a custom source-available license in LICENSE.md.
//- Assets/VadimBurym-DODBT is licensed separately under Assets/VadimBurym-DODBT/LICENSE.md.
//- Third-party assets and packages remain under their respective owners’ terms.

using System;
using Unity.Entities;
using UnityEngine;

namespace VadimBurym.DodBehaviourTree
{
    [Serializable]
    [InternalBufferCapacity(0)]
    public struct NodeStateElement : IBufferElementData
    {
        [SerializeField] internal byte Cursor;
        [SerializeField] internal byte MemoryCursor;
        [SerializeField] internal byte CachedStatus;
        [SerializeField] internal byte TmpA;
        [SerializeField] internal byte TmpB;
#if DODBT_SMALL_SIZE
        [SerializeField] public byte LeafStateIndex;
#else
        [SerializeField] public ushort LeafStateIndex;
#endif
    }
}
