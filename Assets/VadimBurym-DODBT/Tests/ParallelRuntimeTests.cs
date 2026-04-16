//License
//- Repository: https://github.com/vadimburym/DOTS-Battle-Simulator-Prototype/tree/main/Assets/VadimBurym-DODBT
//- Copyright (c) 2026 vadimburym (Vadim Burym)
//- The repository root is licensed under a custom source-available license in LICENSE.md.
//- Assets/VadimBurym-DODBT is licensed separately under Assets/VadimBurym-DODBT/LICENSE.md.
//- Third-party assets and packages remain under their respective owners’ terms.

using NUnit.Framework;

namespace VadimBurym.DodBehaviourTree.Tests
{
    public sealed class ParallelRuntimeTests
    {
        [Test]
        public void Parallel_WhenSuccessThresholdIsReached_ReturnsSuccess()
        {
            using var runner = TestTreeFactory.CreateRunner(
                TestNodeSpec.Parallel(
                    successThreshold: 2,
                    failsThreshold: 2,
                    cacheChildStatus: true,
                    TestNodeSpec.RecordingLeaf("A", NodeStatus.Success),
                    TestNodeSpec.RecordingLeaf("B", NodeStatus.Success),
                    TestNodeSpec.RecordingLeaf("C", NodeStatus.Success)));

            var status = runner.Tick();

            Assert.That(status, Is.EqualTo(NodeStatus.Success));
            Assert.That(runner.Recording("A").TickCount, Is.EqualTo(1));
            Assert.That(runner.Recording("B").TickCount, Is.EqualTo(1));
            Assert.That(runner.Recording("C").TickCount, Is.EqualTo(1));
        }

        [Test]
        public void Parallel_WhenFailsThresholdIsReached_ReturnsFailure()
        {
            using var runner = TestTreeFactory.CreateRunner(
                TestNodeSpec.Parallel(
                    3,
                    1,
                    false,
                    TestNodeSpec.RecordingLeaf("A", NodeStatus.Success),
                    TestNodeSpec.RecordingLeaf("B", NodeStatus.Failure),
                    TestNodeSpec.RecordingLeaf("C", NodeStatus.Success)));

            var status = runner.Tick();
            Assert.That(status, Is.EqualTo(NodeStatus.Failure));
        }

        [Test]
        public void Parallel_WhenResultBecomesSuccess_AbortsRunningChildren()
        {
            using var runner = TestTreeFactory.CreateRunner(
                TestNodeSpec.Parallel(
                    successThreshold: 2,
                    failsThreshold: 3,
                    cacheChildStatus: false,
                    TestNodeSpec.RecordingLeaf("A", NodeStatus.Running),
                    TestNodeSpec.RecordingLeaf("B", NodeStatus.Success),
                    TestNodeSpec.RecordingLeaf("C", NodeStatus.Success)));

            var status = runner.Tick();

            Assert.That(status, Is.EqualTo(NodeStatus.Success));
            Assert.That(runner.Recording("A").TickCount, Is.EqualTo(1));
            Assert.That(runner.Recording("A").AbortCount, Is.EqualTo(1));
            Assert.That(runner.Recording("B").TickCount, Is.EqualTo(1));
            Assert.That(runner.Recording("C").TickCount, Is.EqualTo(1));
        }

        [Test]
        public void Parallel_WithCacheChildStatusTrue_DoesNotRetickCompletedChildrenOnNextTick()
        {
            using var runner = TestTreeFactory.CreateRunner(
                TestNodeSpec.Parallel(
                    3,
                    3,
                    true,
                    TestNodeSpec.RecordingLeaf("A", NodeStatus.Success),
                    TestNodeSpec.RecordingLeaf("B", NodeStatus.Running, NodeStatus.Success),
                    TestNodeSpec.RecordingLeaf("C", NodeStatus.Success)));

            var firstTick = runner.Tick();
            var secondTick = runner.Tick();

            Assert.That(firstTick, Is.EqualTo(NodeStatus.Running));
            Assert.That(secondTick, Is.EqualTo(NodeStatus.Success));
            Assert.That(runner.Recording("A").TickCount, Is.EqualTo(1));
            Assert.That(runner.Recording("B").TickCount, Is.EqualTo(2));
            Assert.That(runner.Recording("C").TickCount, Is.EqualTo(1));
        }

        [Test]
        public void Parallel_WithCacheChildStatusFalse_ReticksCompletedChildrenOnNextTick()
        {
            using var runner = TestTreeFactory.CreateRunner(
                TestNodeSpec.Parallel(
                    3,
                    3,
                    false,
                    TestNodeSpec.RecordingLeaf("A", NodeStatus.Success, NodeStatus.Success),
                    TestNodeSpec.RecordingLeaf("B", NodeStatus.Running, NodeStatus.Success),
                    TestNodeSpec.RecordingLeaf("C", NodeStatus.Success, NodeStatus.Success)));

            var firstTick = runner.Tick();
            var secondTick = runner.Tick();

            Assert.That(firstTick, Is.EqualTo(NodeStatus.Running));
            Assert.That(secondTick, Is.EqualTo(NodeStatus.Success));
            Assert.That(runner.Recording("A").TickCount, Is.EqualTo(2));
            Assert.That(runner.Recording("B").TickCount, Is.EqualTo(2));
            Assert.That(runner.Recording("C").TickCount, Is.EqualTo(2));
        }

        [Test]
        public void Parallel_Abort_WhenChildIsRunning_AbortsRunningLeaf_AndClearsCachedStatus()
        {
            using var runner = TestTreeFactory.CreateRunner(
                TestNodeSpec.Parallel(
                    3,
                    3,
                    true,
                    TestNodeSpec.RecordingLeaf("A", NodeStatus.Success, NodeStatus.Success),
                    TestNodeSpec.RecordingLeaf("B", NodeStatus.Running, NodeStatus.Running),
                    TestNodeSpec.RecordingLeaf("C", NodeStatus.Success, NodeStatus.Success)));

            var firstTick = runner.Tick();
            runner.Abort();
            var secondTick = runner.Tick();

            Assert.That(firstTick, Is.EqualTo(NodeStatus.Running));
            Assert.That(secondTick, Is.EqualTo(NodeStatus.Running));
            Assert.That(runner.Recording("A").TickCount, Is.EqualTo(2));
            Assert.That(runner.Recording("B").TickCount, Is.EqualTo(2));
            Assert.That(runner.Recording("C").TickCount, Is.EqualTo(2));
            Assert.That(runner.Recording("B").AbortCount, Is.EqualTo(1));
        }
    }
}
