namespace MapEditor.Properties
{
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.Resources;
    using System.Runtime.CompilerServices;

    [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0"), CompilerGenerated, DebuggerNonUserCode]
    internal class Resources
    {
        private static CultureInfo resourceCulture;
        private static System.Resources.ResourceManager resourceMan;

        internal Resources()
        {
        }

        internal static Bitmap Block
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("Block", resourceCulture);
            }
        }

        internal static Bitmap City
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("City", resourceCulture);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static CultureInfo Culture
        {
            get
            {
                return resourceCulture;
            }
            set
            {
                resourceCulture = value;
            }
        }

        internal static Bitmap Forest
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("Forest", resourceCulture);
            }
        }

        internal static Bitmap Grassland
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("Grassland", resourceCulture);
            }
        }

        internal static Bitmap Marsh
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("Marsh", resourceCulture);
            }
        }

        internal static Bitmap Mountain
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("Mountain", resourceCulture);
            }
        }

        internal static Bitmap None
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("None", resourceCulture);
            }
        }

        internal static Bitmap Plain
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("Plain", resourceCulture);
            }
        }

        internal static Bitmap Port
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("Port", resourceCulture);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    System.Resources.ResourceManager manager = new System.Resources.ResourceManager("MapEditor.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = manager;
                }
                return resourceMan;
            }
        }

        internal static Bitmap Ridge
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("Ridge", resourceCulture);
            }
        }

        internal static Bitmap River
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("River", resourceCulture);
            }
        }
    }
}

