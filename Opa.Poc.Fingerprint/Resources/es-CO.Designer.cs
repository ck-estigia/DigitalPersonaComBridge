﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Opa.Poc.Fingerprint.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class es_CO {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal es_CO() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Opa.Poc.Fingerprint.Resources.es-CO", typeof(es_CO).Assembly);
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
        ///   Looks up a localized string similar to La captura resultante no tiene la suficiente calidad.
        /// </summary>
        public static string BadCapture {
            get {
                return ResourceManager.GetString("BadCapture", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No se puede iniciar el lector.
        /// </summary>
        public static string CannotOpenReader {
            get {
                return ResourceManager.GetString("CannotOpenReader", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Correctamente capturado.
        /// </summary>
        public static string Captured {
            get {
                return ResourceManager.GetString("Captured", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El proceso de captura ha fallado.
        /// </summary>
        public static string CaptureFail {
            get {
                return ResourceManager.GetString("CaptureFail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Se han encontrado multiples lectores conectados.
        /// </summary>
        public static string MultipleReaders {
            get {
                return ResourceManager.GetString("MultipleReaders", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El lector no esta preparado para iniciar la captura.
        /// </summary>
        public static string ReaderNotReady {
            get {
                return ResourceManager.GetString("ReaderNotReady", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No se han detectado lectores conectados.
        /// </summary>
        public static string WithoutReader {
            get {
                return ResourceManager.GetString("WithoutReader", resourceCulture);
            }
        }
    }
}
