
#pragma warning disable EPS06 // this doesn't happen as the latest version of ReadOnlySpan`1
#pragma warning disable S6966 // we'll not use this because it's an exit call so waiting is to no use
#pragma warning disable CS1633 //

// ##################################################################################################################################
// This is the main method script file. Its used to interpret the command-line arguments and initialize the user requested commands |
//                                                                                                                                  |
//                                                                                                                                  |
// ##################################################################################################################################

#if DEBUG // we'll try attach the debugger if its requested
if (Environment.GetEnvironmentVariable("ATTACH_DEBUGGER", EnvironmentVariableTarget.Process) == "TRUE"
&& !System.Diagnostics.Debugger.IsAttached) { _ = System.Diagnostics.Debugger.Launch(); }
#endif

// in this first section will pay attion to the situations where the user didn't gave us an action to
// perform or if he used one of the following possible arguments:
// NONE or h or help or -h or --h or -help or --help or ? or -? or --?



var wasHelpArgumentHit = args.Length is 0;
Lazy<string> getHelp = !wasHelpArgumentHit
    ? new(() => uTF8.GetString(Resc.GetHelp))
    : new(uTF8.GetString(Resc.GetHelp));

if (!wasHelpArgumentHit)
{
    var ghelpPattern = Resc.HelpPattern.AsSpan();
    var ghelpArguments = ghelpPattern.Split(',');

    string ghelpAsComparableString = new(default, 16);
    var pGhelpAsComparableString = MMrshl.CreateSpan
        ( ref MMrshl.GetReference(ghelpAsComparableString.AsSpan())
        , /* sizeof */ ghelpAsComparableString.Length )
    ;

    while (!wasHelpArgumentHit == ghelpArguments.MoveNext())
    {
        var grabArgument = ghelpPattern[ghelpArguments.Current];
        grabArgument.CopyTo(pGhelpAsComparableString);
        wasHelpArgumentHit = args.Any(ghelpAsComparableString.Contains);
    }
}

/*EXIT*/ if (wasHelpArgumentHit) { cnsle_Ok(getHelp.Value); return; }

// now we'll look for invalid arguments, invalid argument count and unexpected input

const int NOT_FOUND = -1;
const int LENOF_MAX_EXPECTED_ARGS = 2;
var expectedFunctionArguments = Resc.ExpectedFunctionArguments;
var argsLen = args.Length;

/*EXIT*/ if (argsLen > LENOF_MAX_EXPECTED_ARGS) { cnsle_Err(ErrFmt.I0(argsLen, LENOF_MAX_EXPECTED_ARGS, expectedFunctionArguments)); return; }
/*EXIT*/ if (Array.FindIndex(args, expectedFunctionArguments.Contains) is int indexofFunctionArgument and not NOT_FOUND) { cnsle_Err(ErrFmt.I1()); return;}
Unsfe.SkipInit(out indexofFunctionArgument);

#pragma var indexofPathArgument = Enumerable.Range(0, argsLen - 1).FirstOrDefault(availableIndex => availableIndex != indexofFunctionArgument, NOT_FOUND);
#pragma TODO: Add implementations to use the function and the path