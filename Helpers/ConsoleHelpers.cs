namespace Helpers
{
    public static class ConsoleHelpers
    {
        public static void Dump(object o) => ConsoleDump.Extensions.DumpObject(o);
    }
}