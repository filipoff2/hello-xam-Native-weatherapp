﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WeatherApp.Resources {
    using System;
    using System.Reflection;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class LocalizedStrings {
        
        private static System.Resources.ResourceManager resourceMan;
        
        private static System.Globalization.CultureInfo resourceCulture;
        
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal LocalizedStrings() {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public static System.Resources.ResourceManager ResourceManager {
            get {
                if (object.Equals(null, resourceMan)) {
                    System.Resources.ResourceManager temp = new System.Resources.ResourceManager("WeatherApp.Resources.LocalizedStrings", typeof(LocalizedStrings).GetTypeInfo().Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public static System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        public static string CitySelectTitle {
            get {
                return ResourceManager.GetString("CitySelectTitle", resourceCulture);
            }
        }
        
        public static string SearchTextFieldPlaceholder {
            get {
                return ResourceManager.GetString("SearchTextFieldPlaceholder", resourceCulture);
            }
        }
        
        public static string SearchButtonTitle {
            get {
                return ResourceManager.GetString("SearchButtonTitle", resourceCulture);
            }
        }
        
        public static string ErrorDialogTitle {
            get {
                return ResourceManager.GetString("ErrorDialogTitle", resourceCulture);
            }
        }
        
        public static string ErrorDialogMessage {
            get {
                return ResourceManager.GetString("ErrorDialogMessage", resourceCulture);
            }
        }
        
        public static string ErrorDialogMessageNotImplemented {
            get {
                return ResourceManager.GetString("ErrorDialogMessageNotImplemented", resourceCulture);
            }
        }
        
        public static string OK {
            get {
                return ResourceManager.GetString("OK", resourceCulture);
            }
        }
    }
}
