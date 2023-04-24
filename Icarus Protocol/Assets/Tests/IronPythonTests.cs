using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class IronPythonTests
{
    GameObject IPContainer;
    IronPythonContainer IPRef;
    PhaseDefinition PhaseRef;
    (int, string) ExitData;
    bool actionCalled;

    /// <summary>
    /// Sets up the framework for the IronPythonContainer and a test phase.
    /// </summary>
    [SetUp]
    public void SetUp() 
    {
        ExitData = (-2, "");
        actionCalled = false;

        //Init test GameObject
        IPContainer = new GameObject("IPContainer");
        IPRef = IPContainer.AddComponent<IronPythonContainer>();

        //Init test phase
        PhaseRef = IPContainer.AddComponent<PhaseDefinition>();
        PhaseRef.TestFile = new TextAsset(@"
shouldPass = False
privateShouldPass = False
shouldFail = False

def simulate():
    global shouldPass
    global privateShouldPass
    global shouldFail

    try:
        parent.execute_user_code()
    except Exception as e: 
        parent.end_simulation(-1, repr(e))
        return

    environment.trigger_action_group(0)
    parent.pull_user_scope()

    if shouldFail:
        parent.end_simulation(2)
    elif shouldPass or privateShouldPass:
        parent.end_simulation(0)
    else:
        parent.end_simulation(1)

def simulate_tick():
    return 0
");
        PhaseRef.ScriptFile = new TextAsset("Empty Script");
        PhaseRef.ID = "test";
        PhaseRef.FastTickSpeed = 0.1f;
        PhaseRef.CodeLoopDuration = 0.1f;
        PhaseRef.ActionGroups = new List<UnityEngine.Events.UnityEvent>();
        PhaseRef.ResetGroup = new UnityEngine.Events.UnityEvent();
        PhaseRef.ExposedMembers = new List<string>() {"shouldPass", "shouldFail"};
        PhaseRef.FriendlyVariableNames = new List<string>();
    }

    /// <summary>
    /// Tests that the IronPythonContainer can be initialized with a test phase, which gets properly cached.
    /// </summary>
    [Test]
    public void IronPython_WhenInitialized_PhaseCached()
    {
        IPRef.InitializeLevel(PhaseRef);
        Assert.AreEqual("test", IPRef.mCachedLevel.ID);
    }

    /// <summary>
    /// Tests that utilities can fetch values from the Python simulation
    /// </summary>
    [Test]
    public void IronPython_WhenGetPythonValue_CorrectValueFetched()
    {
        IPRef.InitializeLevel(PhaseRef);
        Assert.AreEqual(false, (bool)IPRef.GetPythonValue("shouldPass"));
    }

    /// <summary>
    /// Tests that malformed (exceptional) user code returns -1 and gives you an error message
    /// </summary>
    [UnityTest]
    public IEnumerator IronPython_WhenBadUserCode_ReturnsException()
    {
        IPRef.InitializeLevel(PhaseRef);
        IPRef.OnSimulationExit += IPRef_OnSimulationExit;
        IPRef.Simulate("blah = blah blah");
        LogAssert.Expect(LogType.Exception, "SyntaxErrorException: unexpected token 'blah'");

        while (ExitData == (-2,"")) 
        {
            yield return null;
        }

        Assert.AreEqual(-1, ExitData.Item1);
    }

    /// <summary>
    /// Tests that infinite loops are caught by the detector and return -1 with the correct response message
    /// </summary>
    [UnityTest]
    public IEnumerator IronPython_WhenInfiniteLoop_ExitsCorrectly()
    {
        IPRef.InitializeLevel(PhaseRef);
        IPRef.OnSimulationExit += IPRef_OnSimulationExit;
        IPRef.Simulate(@"while True: pass");

        while (ExitData == (-2, ""))
        {
            yield return null;
        }

        Assert.AreEqual(-1, ExitData.Item1);
        Assert.AreEqual("This code locks up longer than it should. The most likely culprit is an infinite loop somewhere in the logic.", ExitData.Item2);
    }

    /// <summary>
    /// Tests that the user isn't able to call forbidden functions like end_simulation from their isolated code
    /// </summary>
    [UnityTest]
    public IEnumerator IronPython_WhenUserCallsForbiddenFunctions_ExitsWithError()
    {
        IPRef.InitializeLevel(PhaseRef);
        IPRef.OnSimulationExit += IPRef_OnSimulationExit;
        IPRef.Simulate(@"parent.end_simulation(0)");
        LogAssert.Expect(LogType.Exception, "UnboundNameException: name 'parent' is not defined");

        while (ExitData == (-2, ""))
        {
            yield return null;
        }

        Assert.AreEqual(-1, ExitData.Item1);
    }

    /// <summary>
    /// Tests that successful code works and passes with exit code 0
    /// </summary>
    [UnityTest]
    public IEnumerator IronPython_WhenUserIsCorrect_SimulationSucceeds()
    {
        IPRef.InitializeLevel(PhaseRef);
        IPRef.OnSimulationExit += IPRef_OnSimulationExit;
        IPRef.Simulate(@"shouldPass = True");

        while (ExitData == (-2, ""))
        {
            yield return null;
        }

        Assert.AreEqual(0, ExitData.Item1);
    }

    /// <summary>
    /// Tests that successful code works and passes with exit code 0
    /// </summary>
    [UnityTest]
    public IEnumerator IronPython_WhenUserUsesPrivateVars_NothingHappens()
    {
        IPRef.InitializeLevel(PhaseRef);
        IPRef.OnSimulationExit += IPRef_OnSimulationExit;
        IPRef.Simulate(@"privateShouldPass = True");

        while (ExitData == (-2, ""))
        {
            yield return null;
        }

        Assert.AreEqual(1, ExitData.Item1);
    }

    /// <summary>
    /// Tests that expected logical failures return the correct error code
    /// </summary>
    [UnityTest]
    public IEnumerator IronPython_WhenUserHasLogicError_ExpectedCodeReturned()
    {
        IPRef.InitializeLevel(PhaseRef);
        IPRef.OnSimulationExit += IPRef_OnSimulationExit;
        IPRef.Simulate(@"shouldFail = True");

        while (ExitData == (-2, ""))
        {
            yield return null;
        }

        Assert.AreEqual(2, ExitData.Item1);
    }

    /// <summary>
    /// Tests that action groups get called
    /// </summary>
    [UnityTest]
    public IEnumerator IronPython_WhenCodeRun_ActionGroupCalled()
    {
        IPRef.InitializeLevel(PhaseRef);
        IPRef.OnSimulationExit += IPRef_OnSimulationExit;
        PhaseRef.ActionGroups.Add(new UnityEngine.Events.UnityEvent());
        PhaseRef.ActionGroups[0].AddListener(TestAction);
        IPRef.Simulate(@"");

        while (ExitData == (-2, ""))
        {
            yield return null;
        }

        Assert.IsTrue(actionCalled);
    }

    /// <summary>
    /// A callback function used to cache the return values of the IronPython simulation.
    /// </summary>
    private void IPRef_OnSimulationExit(object sender, (int, string) e)
    {
        ExitData = e;
    }

    /// <summary>
    /// Used to pass tests if this action is called
    /// </summary>
    private void TestAction() 
    {
        actionCalled = true;
    }
}
