﻿#pragma checksum "..\..\..\..\Pages\Authorization\Page_Authorization_User.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F9C5E6C175F2576BBE0BEDD133C760D8BBB57D983B999DB6B873E1F0CACB2ECD"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using ООО__5ELEMENT_.Pages.Authorization;


namespace ООО__5ELEMENT_.Pages.Authorization {
    
    
    /// <summary>
    /// Page_Authorization_User
    /// </summary>
    public partial class Page_Authorization_User : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\..\Pages\Authorization\Page_Authorization_User.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox_Login;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\Pages\Authorization\Page_Authorization_User.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox_Password;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Pages\Authorization\Page_Authorization_User.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_Auth;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\Pages\Authorization\Page_Authorization_User.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_ChangePage;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ООО «5ELEMENT»;component/pages/authorization/page_authorization_user.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\Authorization\Page_Authorization_User.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.TextBox_Login = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.TextBox_Password = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Button_Auth = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\..\Pages\Authorization\Page_Authorization_User.xaml"
            this.Button_Auth.Click += new System.Windows.RoutedEventHandler(this.Button_Auth_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Button_ChangePage = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\..\Pages\Authorization\Page_Authorization_User.xaml"
            this.Button_ChangePage.Click += new System.Windows.RoutedEventHandler(this.Button_ChangePage_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

