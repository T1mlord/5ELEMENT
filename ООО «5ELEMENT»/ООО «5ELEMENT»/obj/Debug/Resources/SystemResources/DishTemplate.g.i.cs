﻿#pragma checksum "..\..\..\..\Resources\SystemResources\DishTemplate.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5E0323F1D8453F80D605B25022ADCD56A9CC6EFA4B9E4CDF23617620154BA7BB"
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
using ООО__5ELEMENT_.Resources.SystemResources;


namespace ООО__5ELEMENT_.Resources.SystemResources {
    
    
    /// <summary>
    /// DishTemplate
    /// </summary>
    public partial class DishTemplate : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\Resources\SystemResources\DishTemplate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlock_Name;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\Resources\SystemResources\DishTemplate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Image_Dish;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\Resources\SystemResources\DishTemplate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox_Quantity;
        
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
            System.Uri resourceLocater = new System.Uri("/ООО «5ELEMENT»;component/resources/systemresources/dishtemplate.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Resources\SystemResources\DishTemplate.xaml"
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
            
            #line 11 "..\..\..\..\Resources\SystemResources\DishTemplate.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.Label_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TextBlock_Name = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.Image_Dish = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.TextBox_Quantity = ((System.Windows.Controls.TextBox)(target));
            
            #line 14 "..\..\..\..\Resources\SystemResources\DishTemplate.xaml"
            this.TextBox_Quantity.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TextBox_PreviewTextInput_VerificationNumbers);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

