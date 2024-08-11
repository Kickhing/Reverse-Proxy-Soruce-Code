using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace FireSocks.Properties
{
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (FireSocks.Properties.Resources.resourceMan == null)
          FireSocks.Properties.Resources.resourceMan = new ResourceManager("FireSocks.Properties.Resources", typeof (FireSocks.Properties.Resources).Assembly);
        return FireSocks.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => FireSocks.Properties.Resources.resourceCulture;
      set => FireSocks.Properties.Resources.resourceCulture = value;
    }

    internal static byte[] proxclient => (byte[]) FireSocks.Properties.Resources.ResourceManager.GetObject(nameof (proxclient), FireSocks.Properties.Resources.resourceCulture);

    internal Resources()
    {
    }
  }
}
