using Custom.Internal;
using Iuliia;

namespace Custom
{
    public static class CustomSchemes
    {
        public static Scheme Custom1 { get; } = SchemeReader.Read(Properties.Resources.custom1);
        public static Scheme Custom2 { get; } = SchemeReader.Read(Properties.Resources.custom2);
        public static Scheme Custom3 { get; } = SchemeReader.Read(Properties.Resources.custom3);
        public static Scheme Custom4 { get; } = SchemeReader.Read(Properties.Resources.custom4);
    }
}
