//License
//- Repository: https://github.com/vadimburym/DOTS-Battle-Simulator-Prototype/tree/main/Assets/VadimBurym-DODBT
//- Copyright (c) 2026 vadimburym (Vadim Burym)
//- The repository root is licensed under a custom source-available license in LICENSE.md.
//- Assets/VadimBurym-DODBT is licensed separately under Assets/VadimBurym-DODBT/LICENSE.md.
//- Third-party assets and packages remain under their respective owners’ terms.

using Unity.Collections;
using Unity.Entities;

namespace VadimBurym.DodBehaviourTree
{
    public struct BehaviourTreeBlob
    {
        public int RootIndex;
        public BlobArray<Node> Nodes;
        internal BlobArray<SelectorNode> SelectorNodes;
        internal BlobArray<SequenceNode> SequenceNodes;
        internal BlobArray<MemorySelectorNode> MemorySelectorNodes;
        internal BlobArray<MemorySequenceNode> MemorySequenceNodes;
        internal BlobArray<ParallelNode> ParallelNodes;
        public BlobArray<LeafData> Leafs;
    }
}
