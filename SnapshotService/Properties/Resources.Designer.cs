﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SnapshotService.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("SnapshotService.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Client: {0} Message: {1}.
        /// </summary>
        public static string ClientMessage {
            get {
                return ResourceManager.GetString("ClientMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Running in Console Mode press any key to stop....
        /// </summary>
        public static string ConsoleMode {
            get {
                return ResourceManager.GetString("ConsoleMode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SnapshotService.
        /// </summary>
        public static string EventSourceName {
            get {
                return ResourceManager.GetString("EventSourceName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to New Client: {0} Message: {1}.
        /// </summary>
        public static string NewClientMessage {
            get {
                return ResourceManager.GetString("NewClientMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Starting Windows Service....
        /// </summary>
        public static string StartingWindowsService {
            get {
                return ResourceManager.GetString("StartingWindowsService", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Stoping Windows Service....
        /// </summary>
        public static string StopingWindowsService {
            get {
                return ResourceManager.GetString("StopingWindowsService", resourceCulture);
            }
        }
    }
}
