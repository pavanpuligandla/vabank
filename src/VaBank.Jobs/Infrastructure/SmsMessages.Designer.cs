﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VaBank.Jobs.Infrastructure {
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
    internal class SmsMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal SmsMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("VaBank.Jobs.Infrastructure.SmsMessages", typeof(SmsMessages).Assembly);
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
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Vasha karta {0} zablokirovana cherez internet-banking &quot;Va-bank&quot;..
        /// </summary>
        internal static string CardBlocked {
            get {
                return ResourceManager.GetString("CardBlocked", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Karta: {0}. Na vash schet zachisleno {1}. {2}, {3}. Ostatok: {4}..
        /// </summary>
        internal static string CardDeposit {
            get {
                return ResourceManager.GetString("CardDeposit", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Karta: {0}. Oshibka operacii: {1}. {2}, {3}. Ostatok: {4}..
        /// </summary>
        internal static string CardError {
            get {
                return ResourceManager.GetString("CardError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Karta: {0}. S vashego scheta spisano {1}. {2}, {3}. Ostatok: {4}..
        /// </summary>
        internal static string CardWithdrawal {
            get {
                return ResourceManager.GetString("CardWithdrawal", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Vash odnorazovyj parol dlya internet-bankinga: {0}..
        /// </summary>
        internal static string SecurityCode {
            get {
                return ResourceManager.GetString("SecurityCode", resourceCulture);
            }
        }
    }
}
