﻿#pragma checksum "..\..\..\UI\UserAdminControl.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "AEC38D6A022A3F4BD3080BFE5D870AFFC8D63F8ABC470FF8B1B3AB9A0D585936"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
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
using WaveWpf.UI;


namespace WaveWpf.UI {
    
    
    /// <summary>
    /// UserAdminControl
    /// </summary>
    public partial class UserAdminControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\UI\UserAdminControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_email_user_admin;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\UI\UserAdminControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox checkbox_is_admin;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\UI\UserAdminControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button update_role_user;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\UI\UserAdminControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid datagridUsersList;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\UI\UserAdminControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button delete_user;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\UI\UserAdminControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_id_user_admin;
        
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
            System.Uri resourceLocater = new System.Uri("/WaveWpf;component/ui/useradmincontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UI\UserAdminControl.xaml"
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
            this.txt_email_user_admin = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            
            #line 14 "..\..\..\UI\UserAdminControl.xaml"
            ((System.Windows.Controls.TextBox)(target)).TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SearchUserAdmin);
            
            #line default
            #line hidden
            return;
            case 3:
            this.checkbox_is_admin = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 4:
            this.update_role_user = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\UI\UserAdminControl.xaml"
            this.update_role_user.Click += new System.Windows.RoutedEventHandler(this.update_role_user_btn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.datagridUsersList = ((System.Windows.Controls.DataGrid)(target));
            
            #line 18 "..\..\..\UI\UserAdminControl.xaml"
            this.datagridUsersList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.getDataFromRowDataGrid);
            
            #line default
            #line hidden
            return;
            case 6:
            this.delete_user = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\UI\UserAdminControl.xaml"
            this.delete_user.Click += new System.Windows.RoutedEventHandler(this.delete_user_btn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.txt_id_user_admin = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
