
// global framework importations & aliases file
// used to center library and namespace usage to
// a higher scope

#pragma warning disable RCS1110, S101, S3903  // This is a special IDE syntax file and may not be held inside namespace

global using MMrshl = System.Runtime.InteropServices.MemoryMarshal;
global using Unsfe = System.Runtime.CompilerServices.Unsafe;
global using static __global;
global using Dink;

static class __global
{
    internal const byte ARGS_INDEXOF_FUNCTION = 0;
    internal const byte ARGS_INDEXOF_PATH = 0;

    internal static readonly System.Text.Encoding uTF8 = System.Text.Encoding.UTF8;
    internal static readonly Action<string> cnsle_Err = Console.Error.WriteLine;
    internal static readonly Action<string> cnsle_Ok = Console.WriteLine;
}