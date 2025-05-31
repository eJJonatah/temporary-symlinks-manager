namespace Dink;

static class ErrFmt
{
    internal static string I0(params ReadOnlySpan<object> args)
    {   return new System.Text.StringBuilder(Resc.ERRI0)
            .Replace("%0", args[0].ToString())
            .Replace("%1", args[1].ToString())
            .Replace("%2", args[2].ToString())
            .ToString()
    ;}
    internal static string I1()
    {   return Resc.ERRI1
    ;}
}
