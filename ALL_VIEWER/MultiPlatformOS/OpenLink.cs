using System;

namespace MultiPlatformOS
{
    public static class OpenLink
    {
        //https://stackoverflow.com/questions/4580263/how-to-open-in-default-browser-in-c-sharp
        public static void To(string url)
        {
            if (PlatformUtils.GetPlaformOS == PlaformOS.MonoLinux)
            {
                try { System.Diagnostics.Process.Start("xdg-open", url); } catch (Exception) { }
            }
            else
            {
                try { System.Diagnostics.Process.Start("explorer.exe", url); } catch (Exception) { }
            }
        }
    }
}
