#pragma checksum "..\..\..\..\..\..\Pages\Employees\Admin\BackUp\Page_BackUp.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "03F9C42482EF834547D9FD5DAAEEB648C8FF63A709864D41F266F036C03A0805"
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
using ООО__5ELEMENT_.Pages.Employees.Admin.BackUp;


namespace ООО__5ELEMENT_.Pages.Employees.Admin.BackUp {
    
    
    /// <summary>
    /// Page_BackUp
    /// </summary>
    public partial class Page_BackUp : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\..\..\..\Pages\Employees\Admin\BackUp\Page_BackUp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox_RecoveryPath;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\..\..\Pages\Employees\Admin\BackUp\Page_BackUp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_SelectRecoveryPath;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\..\..\Pages\Employees\Admin\BackUp\Page_BackUp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_BeginRecovery;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\..\..\Pages\Employees\Admin\BackUp\Page_BackUp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox_BackUpPath;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\..\..\Pages\Employees\Admin\BackUp\Page_BackUp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_BeginBackUp;
        
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
            System.Uri resourceLocater = new System.Uri("/ООО «5ELEMENT»;component/pages/employees/admin/backup/page_backup.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\Pages\Employees\Admin\BackUp\Page_BackUp.xaml"
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
            this.TextBox_RecoveryPath = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.Button_SelectRecoveryPath = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\..\..\..\Pages\Employees\Admin\BackUp\Page_BackUp.xaml"
            this.Button_SelectRecoveryPath.Click += new System.Windows.RoutedEventHandler(this.Button_SelectRecoveryPath_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Button_BeginRecovery = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\..\..\..\Pages\Employees\Admin\BackUp\Page_BackUp.xaml"
            this.Button_BeginRecovery.Click += new System.Windows.RoutedEventHandler(this.Button_BeginRecovery_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TextBox_BackUpPath = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.Button_BeginBackUp = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\..\..\..\Pages\Employees\Admin\BackUp\Page_BackUp.xaml"
            this.Button_BeginBackUp.Click += new System.Windows.RoutedEventHandler(this.Button_BeginBackUp_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

